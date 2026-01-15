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
            ConsoleScreen mainScreen = new ConsoleScreen();
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
            //string campaignJsonPath = @"C:\Users\zombi\source\repos\PokeZork\src\PokeZork.Console\Campaign1.campaign";
            string campaignJsonPath = @"C:\Users\zombi\source\repos\jthompson1989\PokeZork\src\PokeZork.Console\Campaign1.campaign";
            Game game = new Game(mainScreen, campaignJsonPath);
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

