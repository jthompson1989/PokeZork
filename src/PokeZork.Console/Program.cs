using PokeZork.Console;
using System;
using PokeZork.GameEngine;
using PokeZork.TUIEngine;

namespace PokeZork.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Screen mainScreen = new Screen();
            mainScreen.DelayWrite("Welcome to PokeZork! Testing the delay write", 15);
            if (OperatingSystem.IsWindows())
            {
                try
                {
                    mainScreen.MaximizeScreen();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"Resize failed: {ex.GetType()}: {ex.Message}");
                }

            }
            var option = mainScreen.PrintTitleMenu();
            string CampaignJsonPath = @"C:\Users\zombi\source\repos\PokeZork\src\PokeZork.Console\Campaign1.json";
            Game game = new Game(mainScreen, CampaignJsonPath);
            switch (option)
            {
                case 1:
                    //var game = new PokeZork.Game.Game();
                    var playerCreated = game.LoadNewPlayerCharacter();
                    if (playerCreated)
                    {
                        game.StartGame();
                    }
                    else
                    {
                        mainScreen.DelayWrite("Failed to create new player character.", 15);
                        mainScreen.DelayWrite("Failed to start game. Will spam ZombieChan's email with Errors", 15);
                        mainScreen.DelayWrite("Exiting...", 15);
                    }
                    break;
                case 2:
                    //TODO: Show list of characters to load, user input 1 of them. For now, just load character 1.
                    var playerLoaded = game.LoadPlayerCharacter(1);
                    break;
                case 3:
                    System.Console.WriteLine("\nExiting...");
                    break;
                case 4:
                    mainScreen.Clear();
                    break;
                default:
                    mainScreen.Clear();
                    System.Console.WriteLine("Exiting...");
                    break;
            }

        }
    }
}

