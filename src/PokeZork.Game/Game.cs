using PokeZork.GameEngine.CampaignModels;
using PokeZork.GameEngine.Interface;
using PokeZork.GameEngine.Models;
using PokeZork.TUIEngine;
using PokeZork.Common.Enum;
using System.Xml.Linq;
using PokeZork.Common.Extensions;

namespace PokeZork.GameEngine
{
    public class Game : IGame
    {
        private readonly IScreen _screen;
        private Player? Player;
        private Campaign? Campaign;
        private bool IsGameRunning = false;
        private int SelectedChapter = 0;
        private int SelectedScene = 0;
        private int SelectedDialog = 0;
        public Game(IScreen screen)
        {
            this._screen = screen; 
        }

        public bool LoadNewPlayerCharacter()
        {
            try
            {
                this._screen.Clear();
                this._screen.Write("Creating new player character...");
                this.Player = new Player { Id = 1 };
                this.Player.Tags.Add(Tag.NO_POKEMON);
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
            var gameDataLoaded = LoadCampaignData();
            gameDataLoaded = LoadCurrentSection();
            if (gameDataLoaded)
            {
                this.IsGameRunning = true;
                //Start Game Loop
                while (this.IsGameRunning)
                {
                    this.IsGameRunning = false;
                }
            }

            return true;
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
        private bool LoadCampaignData(int startingPoint = 1)
        {
            try
            {
                //TODO: Add logic to read database to download game data
                //Will just mimic here. 
                this.Campaign = new Campaign() { Id = 1, Name = "Main Campaign" };

                Chapter chapter1 = new Chapter();
                chapter1.Title = "Adventure Start";
                chapter1.Id = 1;

                Scene scene1 = new Scene();
                scene1.Id = 1;
                scene1.Title = "Welcome To the World of Pokemon";

                Dialog dialog1 = new Dialog();
                dialog1.Id = 1; // 1:1:1
                dialog1.Text = $"Hello there! Welcome to the world of POKEMON! My name is Professor Nobody. " +
                    $"\r\nThis world is inhabited by creatures called POKEMON! For some people, POKEMON are pets. Others use them for fights. " +
                    $"\r\nMyself...\r\nWell, I can't legally say. " +
                    $"\r\n \r\n {this.Player!.Name}! Your very own POKEMON legend is about to unfold! A world of dreams and adventures with POKEMON awaits!\r\nLet's go!";

                scene1.Dialogs.Add(dialog1);

                chapter1.Scenes.Add(scene1);

                Scene scene2 = new Scene();
                scene2.Id = 2;
                scene2.Title = "HOME BEDROOM";

                Dialog dialog2 = new Dialog();
                dialog2.Id = 2; // 1:2:2
                dialog2.Text = $"You wake up in your bedroom, today is the day to meetup with Prof Nobody to pick your first POKEMON.\r\nWhat do you do?";
                var dc1 = new DialogChoices();
                dc1.Id = 1;
                dc1.ChoiceKey = "1";
                dc1.ChoiceText = "Get out of bed";
                dc1.Commands.Add(Command.GOTO, "1:2:3");
                var dc2 = new DialogChoices();
                dc2.Id = 2;
                dc2.ChoiceKey = "2";
                dc2.ChoiceText = "Sleep in";
                dc2.Commands.Add(Command.GOTO, "1:2:4");
                dc2.Commands.Add(Command.SETCHARACTERTAG, $"0:{Tag.SLEPT_IN}");
                dialog2.Choices.Add(dc1);
                dialog2.Choices.Add(dc2);
                scene2.Dialogs.Add(dialog2);

                Dialog dialog3 = new Dialog();
                dialog3.Id = 3; // 1:2:3
                dialog3.Text = $"You jump out of the bed ready for your first day as a POKEMON TRAINER. {(this.Player.Age > 18).ConvertToStringFlag()}|Now is a better than later.|";
                dialog3.NextDialog = "1:2:45";

                Dialog dialog4 = new Dialog();
                dialog4.Id = 4; // 1:2:4
                dialog4.Text = $"You sleep in another 2 hours. You get out of bed slowly, you're late for your first day as a POKEMON TRAINER.";
                dialog4.NextDialog = "1:2:45";


                Dialog dialog45 = new Dialog();
                dialog45.Id = 45;//1:2:45
                dialog45.Text = $"Your room consist of the bed you were in, a PC, and a door leading down to the stairs. \r\nWhat do you do?";

                var dc3 = new DialogChoices();
                dc3.Id = 3;
                dc3.ChoiceKey = "1";
                dc3.ChoiceText = "Go to the PC and check it out";
                dc3.Commands.Add(Command.GOTO, "1:1:1");

                var dc4 = new DialogChoices();
                dc4.Id = 4;
                dc4.ChoiceKey = "2";
                dc4.ChoiceText = "Go down the stairs";
                dc4.Commands.Add(Command.GOTO, "1:1:1");

                var dc5 = new DialogChoices();
                dc5.Id = 4;
                dc5.ChoiceKey = "3";
                dc5.ChoiceText = "Make a big jump down the stairs";
                dc5.Commands.Add(Command.GOTO, "1:1:1");

                dialog45.Choices.Add(dc3);
                dialog45.Choices.Add(dc4);
                dialog45.Choices.Add(dc5);

                scene2.Dialogs.Add(dialog3);
                scene2.Dialogs.Add(dialog4);
                scene2.Dialogs.Add(dialog45);

                Dialog dialog5 = new Dialog();
                dialog5.Id = 5; //1:2:5
                dialog5.Text = $"You boot up your PC. \r\nWhat do you do?";

                var dc6 = new DialogChoices();
                dc6.Id = 6;
                dc6.ChoiceKey = "1";
                dc6.ChoiceText = "Check Email";
                dc6.Commands.Add(Command.GOTO, "1:2:6");
                dialog5.Choices.Add(dc6);

                var dc7 = new DialogChoices();
                dc7.Id = 7;
                dc7.ChoiceKey = "2";
                dc7.ChoiceText = "Play Minesweeper";
                dc7.Commands.Add(Command.GOTO, "1:2:7");
                dialog5.Choices.Add(dc7);

                if (this.Player.Age >= 18)
                {
                    var dc8 = new DialogChoices();
                    dc8.Id = 8;
                    dc8.ChoiceKey = "3";
                    dc8.ChoiceText = "Surf Pornhub";
                    dc8.Commands.Add(Command.GOTO, "1:2:5");

                    var dc9 = new DialogChoices();
                    dc8.Id = 9;
                    dc8.ChoiceKey = "4";
                    dc8.ChoiceText = "Leave Computer";
                    dc8.Commands.Add(Command.GOTO, "1:2:45");
                }
                else
                {

                }


                scene2.Dialogs.Add(dialog5);

                Dialog dialog6 = new Dialog();
                dialog6.Id = 6; //1:2:6
                dialog6.Text = "Nobody emails you. You have no friends.";
                dialog6.NextDialog = "1:2:5";

                Dialog dialog7 = new Dialog();
                dialog7.Id = 7; //1:2:7
                dialog7.Text = "You Play Minesweeper.";
                dialog7.NextDialog = "1:2:5";

                this.Campaign.Chapters.Add(chapter1);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
