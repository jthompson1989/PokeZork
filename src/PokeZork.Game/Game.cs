using PokeZork.Common;
using PokeZork.Common.Enum;
using PokeZork.Common.Extensions;
using PokeZork.Common.Managers;
using PokeZork.GameEngine.CampaignModels;
using PokeZork.GameEngine.Interface;
using PokeZork.GameEngine.Models;
using PokeZork.TUIEngine;
using PokeZork.Common.DiceMechanics;
using System.Reflection.Metadata.Ecma335;
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

        public GameEndStatus StartGame()
        {
            try
            {
                if (!LoadCampaignData() || !LoadCurrentSection())
                {
                    return GameEndStatus.Error;
                }

                this.IsGameRunning = true;
                this._screen.Clear();
                while (this.IsGameRunning)
                {
                    var loadedDialog = this.Campaign?.LoadSelectedDialog(SelectedChapter, SelectedScene, SelectedDialog);
                    if (loadedDialog == null)
                    {
                        return GameEndStatus.Error;
                    }

                    if (loadedDialog.Commands.Any())
                    {
                        ProcessCommandsOnDialog(loadedDialog.Commands);
                    }

                    loadedDialog.Text = ProcessDialogLine(loadedDialog.Text);
                    var dialogModel = loadedDialog.ConvertToDialogModel();
                    var choiceKey = this._screen.PrintDialog(dialogModel) ?? string.Empty;

                    if (choiceKey.IsSystemCommand())
                    {
                        var systemCommand = choiceKey.ToSystemCommand();
                        if (systemCommand.HasValue)
                        {
                            switch (systemCommand.Value)
                            {
                                case SystemCommand.QUIT:
                                    this.IsGameRunning = false;
                                    return GameEndStatus.User;
                                case SystemCommand.SAVE:
                                    // Implement save logic here
                                    this._screen.Write("Game saved successfully.");
                                    continue;
                                case SystemCommand.POKEDEX:
                                    // Implement Pokédex display logic here
                                    this._screen.Write("Displaying Pokédex...");
                                    continue;
                                case SystemCommand.PARTY:
                                    // Implement Party display logic here
                                    this._screen.Write("Displaying Party...");
                                    continue;
                                case SystemCommand.ITEMS:
                                    // Implement Items display logic here
                                    this._screen.Write("Displaying Items...");
                                    continue;
                                case SystemCommand.STATS:
                                    // Implement Stats display logic here
                                    this._screen.DelayWrite(this.Player?.GetStatsSummaryString() ?? "");
                                    continue;
                                case SystemCommand.HELP:
                                    this._screen.PrintGameInformation();
                                    continue;
                                default:
                                    break;
                            }
                        }
                    }

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
                        var processedResult = ProcessCommandsOnDialog(chosenDialogChoice.Commands);

                        if(processedResult.Status == DialogCommandProcessStatus.GameOver)
                        {
                            this.IsGameRunning = false;
                            return GameEndStatus.GameOver;
                        }

                        if(processedResult.Status == DialogCommandProcessStatus.DiceRoll)
                        {
                            if(processedResult.Value == null)
                            {
                                this._screen.Write("Dice roll command missing value.");
                                this.IsGameRunning = false;
                                return GameEndStatus.Error;
                            }
                            Dice dice = new Dice(processedResult.Value);
                            dice.Roll();
                            this._screen.RollDiceScreen(dice);
                        }

                        // If no GOTO was present, fall back to NextDialog
                        if (!chosenDialogChoice.Commands.Any(c => c.Key == Command.GOTO))
                        {
                            if (!string.IsNullOrWhiteSpace(loadedDialog.NextDialog))
                            {
                                SetCurrentSection(loadedDialog.NextDialog);
                            }
                            else
                            {
                                this.IsGameRunning = false;
                            }
                        }
                        else
                        {
                            // No choices: go to next dialog if present
                            if (!string.IsNullOrWhiteSpace(loadedDialog.NextDialog))
                            {
                                SetCurrentSection(loadedDialog.NextDialog);
                            }
                            else
                            {
                                this.IsGameRunning = false;
                            }
                        }
                    }
                }

                return GameEndStatus.User;
            }
            catch (Exception)
            {
                return GameEndStatus.Error;
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
                this.Campaign = Converter.ConvertCampaignJsonModelToEngineModel(campaignJsonModel);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private DialogCommandProcessResult ProcessCommandsOnDialog(Dictionary<Command, string> commands)
        {
            DialogCommandProcessResult commandProcess = new DialogCommandProcessResult();
            foreach (var command in commands)
            {
                switch (command.Key)
                {
                    case Command.GOTO:
                        if (!string.IsNullOrWhiteSpace(command.Value))
                        {
                            SetCurrentSection(command.Value);
                        }
                        break;

                    case Command.SETCHARACTERTAG:
                        ApplyCharacterTag(command.Value);
                        break;

                    case Command.GAMEOVER:
                        commandProcess.Status = DialogCommandProcessStatus.GameOver;
                        break;
                    case Command.ROLLDICE:
                        commandProcess.Status = DialogCommandProcessStatus.DiceRoll;
                        commandProcess.Value = command.Value;
                        break;

                    default:
                        // Unknown command
                        break;
                }
            }
            return commandProcess;
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
                else if (conditionalVariable == DialogConditionalVariable.ISNOTADULTCOND)
                {
                    string pattern = $@"{Regex.Escape(conditionalVariable.ToFriendlyString())}\|([^|]+)\|";
                    bool isNotAdult = (this.Player?.Age ?? 0) < 18;
                    processedLine = Regex.Replace(processedLine, pattern, match =>
                        isNotAdult ? match.Groups[1].Value : string.Empty
                    );
                }
            }
            return processedLine;
        }
    }
}
