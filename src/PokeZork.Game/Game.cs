using PokeZork.Common.Enum;
using PokeZork.Common.Extensions;
using PokeZork.Common.Managers;
using PokeZork.GameEngine.CampaignModels;
using PokeZork.GameEngine.Interface;
using PokeZork.GameEngine.Models;
using PokeZork.TUIEngine;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PokeZork.GameEngine
{
    public class Game : IGame
    {
        private readonly IScreen _screen;
        private Player? Player;
        private Campaign? Campaign;
        private readonly string _campaignJsonPath;

        private bool IsGameRunning = false;
        private int SelectedChapter = 0;
        private int SelectedScene = 0;
        private int SelectedDialog = 0;
        public Game(IScreen screen, string campaignJsonPath)
        {
            this._screen = screen;
            this._campaignJsonPath = campaignJsonPath;
        }

        public bool LoadNewPlayerCharacter()
        {
            try
            {
                this._screen.Clear();
                this._screen.Write("Creating new player character...");
                this.Player = new Player { Id = 1 };
                this.Player.Tags.Add(Tag.NOPOKEMON);
                SetUpNewPlayerCharacter();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        public bool LoadPlayerCharacter(int id)
        {
            throw new NotImplementedException();
        }

        private void SetUpNewPlayerCharacter()
        {
            if (this.Player == null)
            {
                throw new InvalidOperationException("Player must be initialized before setup.");
            }

            while (true)
            {
                this.Player.Name = this._screen.PrintPlayerQuestion<string>("What is your name?")?.Trim() ?? string.Empty;

                int age;
                while (true)
                {
                    try
                    {
                        age = this._screen.PrintPlayerQuestion<int>("What is your age?");
                        if (age > 0) break;
                        this._screen.Write("Please enter a positive age.");
                    }
                    catch
                    {
                        this._screen.Write("Invalid input. Please enter a numeric age.");
                    }
                }
                this.Player.Age = age;
                this.Player.Gender = this._screen.PrintPlayerQuestion<string>("Are you a boy or a girl?")?.Trim() ?? string.Empty;

                bool correct = this._screen.PrintYesNoQuestion(
                    $"{this.Player.Name} is a {this.Player.Gender} who is {this.Player.Age} years old.\nIs this correct?");
                if (correct)
                {
                    break;
                }

                this._screen.Write("Let's try again.");
            }
        }

        public bool StartGame()
        {
            try
            {
                if (!LoadCampaignData() || !LoadCurrentSection())
                {
                    return false;
                }

                this.IsGameRunning = true;
                this._screen.Clear();
                while (this.IsGameRunning)
                {
                    var loadedDialog = this.Campaign?.LoadSelectedDialog(SelectedChapter, SelectedScene, SelectedDialog);
                    if (loadedDialog == null)
                    {
                        return false;
                    }

                    loadedDialog.Text = ProcessDialogLine(loadedDialog.Text);
                    var dialogModel = loadedDialog.ConvertToDialogModel();
                    var choiceKey = this._screen.PrintDialog(dialogModel) ?? string.Empty;

                    if (loadedDialog.Choices.Any())
                    {
                        var chosenDialogChoice = loadedDialog.Choices
                            .FirstOrDefault(c => string.Equals(c.ChoiceKey, choiceKey, StringComparison.OrdinalIgnoreCase));

                        if (chosenDialogChoice == null)
                        {
                            this._screen.Write("Invalid choice. Please try again.");
                            continue;
                        }

                        // Process commands on the chosen choice
                        foreach (var command in chosenDialogChoice.Commands)
                        {
                            switch (command.Key)
                            {
                                case Command.GOTO:
                                    if (!string.IsNullOrWhiteSpace(command.Value))
                                        SetCurrentSection(command.Value);
                                    break;

                                case Command.SETCHARACTERTAG:
                                    ApplyCharacterTag(command.Value);
                                    break;

                                case Command.GAMEOVER:
                                    this.IsGameRunning = false;
                                    break;

                                default:
                                    // Unknown command
                                    break;
                            }
                        }

                        // If no GOTO was present, fall back to NextDialog
                        if (!chosenDialogChoice.Commands.Any(c => c.Key == Command.GOTO))
                        {
                            if (!string.IsNullOrWhiteSpace(loadedDialog.NextDialog))
                                SetCurrentSection(loadedDialog.NextDialog);
                            else
                                this.IsGameRunning = false;
                        }
                    }
                    else
                    {
                        // No choices: go to next dialog if present
                        if (!string.IsNullOrWhiteSpace(loadedDialog.NextDialog))
                            SetCurrentSection(loadedDialog.NextDialog);
                        else
                            this.IsGameRunning = false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Helper to apply SETCHARACTERTAG command (implement according to your model)
        private void ApplyCharacterTag(string value)
        {
            // Example value format: "0:TagName" or similar. Parse and apply to this.Player.Tags.
            // Guard against nulls and malformed input.
            if (this.Player == null || string.IsNullOrWhiteSpace(value)) return;
            // TODO: parse and apply tag(s)
        }

        private void SetCurrentSection(string values)
        {
            if (string.IsNullOrWhiteSpace(values)) return;

            var splitValues = values.Split(':', StringSplitOptions.RemoveEmptyEntries);
            if (splitValues.Length < 3) return;

            this.SelectedChapter = Convert.ToInt32(splitValues[0].IsNumber() ? splitValues[0] : "1");
            this.SelectedScene = Convert.ToInt32(splitValues[1].IsNumber() ? splitValues[1] : "1");
            this.SelectedDialog = Convert.ToInt32(splitValues[2].IsNumber() ? splitValues[2] : "1");
        }

        public bool LoadCurrentSection()
        {
            //Grab where player left off from SQLite

            this.SelectedChapter = 1;
            this.SelectedScene = 1;
            this.SelectedDialog = 1;

            return true;
        }

        //Starting Point is where to start the game at. 
        //default to 1 to start the game at beginning.
        private bool LoadCampaignData(string startingPoint = "1:1:1")
        {
            try
            {
                JsonManager jsonManager = new JsonManager(this._campaignJsonPath);
                var campaignJsonModel = jsonManager.LoadCampaignFromJson();
                this.Campaign = ConvertCampaignJsonModelToEngineModel(campaignJsonModel);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Looking for DialogVariable in dialogLine like @PLAYERNAME and replace with actual value.
        private string ProcessDialogLine(string dialogLine)
        {
            if (string.IsNullOrWhiteSpace(dialogLine)) 
                return dialogLine;

            string processedLine = dialogLine;

            foreach (var variable in Enum.GetValues<DialogVariable>())
            {
                string placeholder = variable.ToFriendlyString();
                string replacement = variable switch
                {
                    DialogVariable.PLAYERNAME => this.Player?.Name ?? "Player",
                    DialogVariable.PLAYERAGE => this.Player?.Age.ToString() ?? "0",
                    _ => placeholder
                };
                processedLine = processedLine.Replace(placeholder, replacement);
            }

            foreach (var conditionalVariable in Enum.GetValues<DialogConditionalVariable>())
            {
                if (conditionalVariable == DialogConditionalVariable.ISADULTCOND)
                {
                    string pattern = $@"{Regex.Escape(conditionalVariable.ToFriendlyString())}\|([^|]+)\|";
                    bool isAdult = (this.Player?.Age ?? 0) >= 18;

                    processedLine = Regex.Replace(processedLine, pattern, match =>
                        isAdult ? match.Groups[1].Value : string.Empty
                    );
                }
            }
            return processedLine;
        }

        private Campaign ConvertCampaignJsonModelToEngineModel(Common.Managers.JsonModels.Campaign campaign)
        {
            try
            {
                Campaign engineCampaign = new Campaign
                {
                    Id = campaign.Id,
                    Name = campaign.Name
                };
                foreach (var chapterJson in campaign.Chapters)
                {
                    Chapter engineChapter = new Chapter
                    {
                        Id = chapterJson.Id,
                        Title = chapterJson.Title
                    };
                    foreach (var sceneJson in chapterJson.Scenes)
                    {
                        Scene engineScene = new Scene
                        {
                            Id = sceneJson.Id,
                            Title = sceneJson.Title
                        };
                        foreach (var dialogJson in sceneJson.Dialogs)
                        {
                            Dialog engineDialog = new Dialog
                            {
                                Id = dialogJson.Id,
                                Text = dialogJson.Text,
                                NextDialog = dialogJson.NextDialog ?? string.Empty
                            };
                            foreach (var choiceJson in dialogJson.Choices)
                            {
                                DialogChoice engineChoice = new DialogChoice
                                {
                                    ChoiceKey = choiceJson.Key,
                                    ChoiceText = choiceJson.Text
                                };
                                foreach (var commandEntry in choiceJson.Commands)
                                {
                                    var command = commandEntry.Command.ToCommandEnum();
                                    if (command.HasValue)
                                    {
                                        engineChoice.Commands.Add(command.Value, commandEntry.Value);
                                    }
                                }
                                engineDialog.Choices.Add(engineChoice);
                            }
                            engineScene.Dialogs.Add(engineDialog);
                        }
                        engineChapter.Scenes.Add(engineScene);
                    }
                    engineCampaign.Chapters.Add(engineChapter);
                }
                return engineCampaign;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
