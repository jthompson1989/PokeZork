using PokeZork.Common;
using PokeZork.Common.Enum;
using System;
using System.Collections.Generic;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace PokeZork.TUIEngine
{
    enum ScreenMode
    {
        TITLE,
        HELP,
        GAME,
        BATTLE,
        GAMEOVER
    }
    public class Screen : IScreen
    {
        internal int _xSize = 800;
        internal int _ySize = 600;
        ScreenMode CurrentScreenMode { get; set; } = ScreenMode.TITLE;

        public void Clear()
        {
            System.Console.Clear();
        }

        public bool IsTitleScreen()
        {
            return this.CurrentScreenMode == ScreenMode.TITLE;
        }

        public bool IsGameScreen()
        {
            return this.CurrentScreenMode == ScreenMode.GAME;
        }

        public bool IsBattleScreen()
        {
            return this.CurrentScreenMode == ScreenMode.BATTLE;
        }

        public bool IsHelpScreen()
        {
            return this.CurrentScreenMode == ScreenMode.HELP;
        }

        public bool IsGameOverScreen()
        {
            return this.CurrentScreenMode == ScreenMode.GAMEOVER;
        }

        //Can only be called on Windows
        //Also doesn't work, will circle back
        public void MaximizeScreen()
        {
            try
            {
                // If output is redirected (e.g. running under test harness or redirected stdout)
                // resizing the console has no effect.
                if (System.Console.IsOutputRedirected)
                    return;

                try
                {
                    using var searcher = new ManagementObjectSearcher("SELECT CurrentHorizontalResolution, CurrentVerticalResolution FROM Win32_VideoController");
                    foreach (ManagementObject record in searcher.Get())
                    {
                        var hObj = record["CurrentHorizontalResolution"];
                        var vObj = record["CurrentVerticalResolution"];
                        if (hObj is null || vObj is null)
                            continue;

                        _xSize = Convert.ToInt32(hObj);
                        _ySize = Convert.ToInt32(vObj);

                        // Use the first adapter found
                        break;
                    }
                }
                catch
                {
                    // ignore management failures and fall back to console limits
                }
                // LargestWindowWidth/Height may be 0 or limited depending on host (Windows Terminal, VS)
                int maxWidth = System.Console.LargestWindowWidth;
                int maxHeight = System.Console.LargestWindowHeight;

                if (maxWidth <= 0) maxWidth = System.Console.BufferWidth;
                if (maxHeight <= 0) maxHeight = System.Console.BufferHeight;

                int targetWidth = Math.Min(_xSize, maxWidth);
                int targetHeight = Math.Min(_ySize, maxHeight);

                // Console.SetWindowSize requires WindowWidth <= BufferWidth and WindowHeight <= BufferHeight.
                // Ensure buffer is at least as large as target window.
                try
                {
                    int newBufferWidth = Math.Max(System.Console.BufferWidth, targetWidth);
                    int newBufferHeight = Math.Max(System.Console.BufferHeight, targetHeight);
                    if (newBufferWidth != System.Console.BufferWidth || newBufferHeight != System.Console.BufferHeight)
                        System.Console.SetBufferSize(newBufferWidth, newBufferHeight);
                }
                catch
                {
                    // Some hosts disallow changing buffer size.
                }

                // Clamp to actual buffer in case buffer change failed.
                targetWidth = Math.Min(targetWidth, System.Console.BufferWidth);
                targetHeight = Math.Min(targetHeight, System.Console.BufferHeight);

                // Finally set window size and position.
                System.Console.SetWindowSize(Math.Max(1, targetWidth), Math.Max(1, targetHeight));
                System.Console.SetWindowPosition(0, 0);
            }
            catch (PlatformNotSupportedException)
            {
                // Running on non-Windows platform — leave defaults or handle fallback
            }
            catch (Exception)
            {
                // Optional: log or handle other errors
            }
        }

        public void Write(string message)
        {
            System.Console.WriteLine(message);
        }

        public int PrintTitleMenu()
        {
            this.CurrentScreenMode = ScreenMode.TITLE;
            System.Console.OutputEncoding = Encoding.Unicode;
            System.Console.WriteLine("==============================================================");
            System.Console.WriteLine("                        PokeZork Adventure                    ");
            System.Console.WriteLine("==============================================================");
            System.Console.WriteLine(""" 
                            ⡈⢆⡑⢲⢻⣌⡳⣌⢶⣠⢃⠘⠤⢊⠔⡡⢊⠤⢃⠜⡰⢈⠆⡱⢈⠆⡱⢈⠆⡱⢈⠜⣿⣿⣿⣿⣿⣿⣿⣿⢯⣟⣯⣟⡯⢆
                            ⡐⢂⠀⡀⠁⢚⠿⣽⣻⢾⣭⠎⡐⢣⠘⡄⢣⠘⡄⢎⠰⡁⢎⠰⡁⢎⠰⡁⢎⠰⡁⠆⢿⡿⣿⣿⣿⣿⡿⣯⣿⣻⢾⣽⣛⡆
                            ⡘⢄⣀⠀⠸⣿⣿⣶⣭⡛⢾⣓⠈⢆⠱⡈⢆⠱⡈⢆⠱⡈⢆⠱⡈⢆⠱⡈⢆⠱⣈⠱⡘⠿⡽⢻⡞⣷⢻⢯⠷⣟⠿⠾⠝⠂
                            ⠌⣸⣿⢿⡄⢻⣿⣿⣿⣿⣷⣦⣉⠢⡑⢌⠢⡑⢌⠢⡑⢌⠢⡑⢌⠢⡑⢌⠢⡑⠤⢃⠄⠰⢀⠃⡐⠠⠂⣀⣢⣴⣶⣿⡇⠀
                            ⢲⣿⢯⣟⣷⡘⣿⣿⣿⣿⣿⣿⣿⣷⣮⡀⢇⡘⢄⠣⡘⢄⠣⡘⢄⠣⡘⢢⢑⡘⡰⢉⠜⠀⡌⣤⣴⣶⣿⣿⣿⣿⣿⣿⠇⠀
                            ⣿⢯⣟⡿⣞⠳⡘⢿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡘⠄⢣⣜⣀⣃⣘⣂⣡⣑⣂⣈⢐⣁⣎⣶⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⡐
                            ⣿⢯⡿⣽⢏⢣⠐⡈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⣀⠔⡠
                            ⠌⢋⡙⠤⠋⢄⠃⠤⠁⠙⢿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⣡⣾⢯⣟⡔
                            ⠀⠂⠀⠄⢁⠂⠌⠤⢁⠂⠀⢡⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⡻⢋⣥⣾⡿⣯⣟⡾⡐
                            ⠀⠀⠀⠀⠀⡈⠰⢈⠆⡘⢠⣿⣿⣿⣿⡿⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⢿⣿⣿⣿⣿⣿⣷⡜⢯⣷⣻⢷⡻⣜⠡
                            ⠀⠀⠀⠀⠀⢀⠡⢊⠔⣉⣾⣿⣿⣿⣿⠘⠛⠀⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠘⠟⠀⣿⣿⣿⣿⣿⣿⣿⡨⢓⡹⢎⡱⢌⠡
                            ⠀⠀⠀⠀⠀⠀⠂⠥⡚⣼⣿⣿⣿⣿⣿⣶⣤⣾⣿⣿⣿⡿⠿⣿⣿⣿⣿⣿⣿⣷⣤⣶⣿⣿⣿⣿⣿⣿⣿⣇⠡⠒⢄⠒⡨⠐
                            ⠀⠀⠀⠀⠀⠠⡉⢦⢡⡿⢟⡻⠟⠿⣿⣿⣿⣿⣿⣿⣿⣷⣤⣾⣿⣿⣿⣿⣿⣿⣿⣿⡿⢟⢻⡛⢻⣿⣿⣿⡄⢡⠊⠤⡑⠌
                            ⢀⡄⣄⢢⣌⡵⣜⣮⢹⣡⠚⣔⢋⢎⣹⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⢿⣿⣿⣿⣿⣿⣿⠔⣊⠦⣍⢣⢾⣿⣿⡧⢮⣝⣲⢡⢊
                            ⣾⣼⣞⡷⣾⣽⣻⢾⣸⣷⣼⣬⣷⣴⣿⣿⣿⣿⣿⣿⡏⣾⣿⣿⣿⣷⢹⣿⣿⣿⣿⣿⣲⣩⣶⣬⣶⣾⣿⣿⣿⠾⣽⣳⣏⠆
                            ⣿⢾⣽⣻⢷⣯⣟⣯⣧⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣙⣿⠿⡿⣏⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣿⣳⢿⡌
                            ⣿⢯⣷⢿⣻⡾⣽⣳⣯⢧⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣾⣽⡻⡔
                            ⣟⡿⣞⣯⢷⣻⣽⣳⢯⡟⣇⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠓⣯⠳⠌
                            ⠸⢹⠙⡎⢏⠳⢍⠫⡙⡜⢄⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⠣⡙⡐
                """);
            System.Console.WriteLine("Select Option:");
            System.Console.WriteLine("1.) New Game");
            System.Console.WriteLine("2.) Load Game");
            System.Console.WriteLine("3.) Exit");
            System.Console.WriteLine("4.) Information");
            Console.Write(">");
            return Console.ReadLine() switch
            {
                "1" => 1,
                "2" => 2,
                "3" => 3,
                "4" => 4,
                _ => 0,
            };
        }

        public void PrintGameInformation()
        {
            this.CurrentScreenMode = ScreenMode.HELP;
            System.Console.WriteLine("""
                Throughout the game, the main inputs will be a number choice or direction choice. 
                But input can take a few commands, as such:
                  POKEDEX -> Opens Pokedex 
                  PARTY -> Opens Party Menu
                  ITEMS -> Opens Item Menu
                  SAVE -> Saves Game 
                  HELP -> Brings up this screen.
                """);
        }

        public void PrintGameOver()
        {
            this.CurrentScreenMode = ScreenMode.GAMEOVER;
            System.Console.WriteLine("""
                ██████   ███████ ███    ███ ███████      ██████  ██    ██ ███████ ██████  
                ██       ██   ██ ████  ████ ██          ██    ██ ██    ██ ██      ██   ██ 
                ██   ███ ███████ ██ ████ ██ █████       ██    ██ ██    ██ █████   ██████  
                ██    ██ ██   ██ ██  ██  ██ ██          ██    ██  ██  ██  ██      ██   ██ 
                 ██████  ██   ██ ██      ██ ███████      ██████    ████   ███████ ██   ██ 
                """);
        }

        public string PrintDialog(DialogModel dialog)
        {
            this.DelayWrite(dialog.DialogText);
            foreach(var choice in dialog.DialogChoices)
            {
                System.Console.WriteLine($"{choice.Key}.) {choice.Value}");
            }
            System.Console.Write(">");
            var input = System.Console.ReadLine();
            if (String.IsNullOrEmpty(input))
            {
                //GameEngine will handle error input
                return "";
            }
            else
            {
                return dialog.DialogChoices.ContainsKey(input) 
                    ? dialog.DialogChoices[input] : "";
            }
            
        }

        public T PrintPlayerQuestion<T>(string question)
        {
            this.DelayWrite(question);
            System.Console.Write(">");
            var input = System.Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                // Return default value for value types, or null for reference types
                return default!;
            }

            return (T)Convert.ChangeType(input, typeof(T));
        }

        public bool PrintYesNoQuestion(string question)
        {
            this.DelayWrite(question);
            System.Console.Write(">(Y/N): ");
            var input = System.Console.ReadLine() ?? "";

            return input.Trim().ToLower() switch
            {
                "y" or "yes" => true,
                "n" or "no" => false,
                _ => false,
            };
        }

        public void DelayWrite(string message, int millisecondsDelayPerCharacter = 15)
        {
            foreach (char c in message)
            {
                System.Console.Write(c);
                System.Threading.Thread.Sleep(millisecondsDelayPerCharacter);
            }
            System.Console.WriteLine();
        }
    }
}
