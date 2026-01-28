using PokeZork.Common;
using PokeZork.Common.DiceMechanics;
using PokeZork.Common.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management;
using System.Text;

namespace PokeZork.TUIEngine
{
    /// <summary>
    /// Represents a textual user interface screen with capabilities for rendering
    /// game state, dialogs, and receiving player input.
    /// </summary>
    public interface IScreen
    {
        /// <summary>
        /// Clears the visible contents of the screen.
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines whether the current screen is the title screen.
        /// </summary>
        /// <returns><c>true</c> if the title screen is active; otherwise <c>false</c>.</returns>
        bool IsTitleScreen();

        /// <summary>
        /// Determines whether the current screen is the main game screen.
        /// </summary>
        /// <returns><c>true</c> if the game screen is active; otherwise <c>false</c>.</returns>
        bool IsGameScreen();

        /// <summary>
        /// Determines whether the current screen is a battle screen.
        /// </summary>
        /// <returns><c>true</c> if a battle screen is active; otherwise <c>false</c>.</returns>
        bool IsBattleScreen();

        /// <summary>
        /// Determines whether the current screen is the help screen.
        /// </summary>
        /// <returns><c>true</c> if the help screen is active; otherwise <c>false</c>.</returns>
        bool IsHelpScreen();

        /// <summary>
        /// Determines whether the current screen is the game over screen.
        /// </summary>
        /// <returns><c>true</c> if the game over screen is active; otherwise <c>false</c>.</returns>
        bool IsGameOverScreen();

        /// <summary>
        /// Attempts to maximize the console or window hosting the TUI.
        /// </summary>
        /// <remarks>
        /// This operation is platform-specific and is intended for Windows. Behavior
        /// may be limited or no-op on other platforms.
        /// </remarks>
        void MaximizeScreen();

        /// <summary>
        /// Writes a message to the screen without adding a delay between characters.
        /// </summary>
        /// <param name="message">The message text to write.</param>
        void Write(string message);

        /// <summary>
        /// Writes a message to the screen with a per-character delay to simulate typing.
        /// </summary>
        /// <param name="message">The message text to write.</param>
        /// <param name="millisecondsDelayPerCharacter">
        /// Number of milliseconds to wait between writing each character.
        /// Defaults to 15 ms.
        /// </param>
        void DelayWrite(string message, int millisecondsDelayPerCharacter = 15);

        /// <summary>
        /// Renders the title menu and returns the index or identifier of the selected menu item.
        /// </summary>
        /// <returns>An integer representing the player's menu selection.</returns>
        int PrintTitleMenu();

        /// <summary>
        /// Prints general game information such as player status, location, or other HUD elements.
        /// </summary>
        void PrintGameInformation();

        /// <summary>
        /// Renders the game over screen.
        /// </summary>
        void PrintGameOver();

        /// <summary>
        /// Displays a dialog to the player and returns the resulting text or selection.
        /// </summary>
        /// <param name="dialog">The dialog model containing message, choices, and metadata.</param>
        /// <returns>The selected or resulting string from the dialog interaction.</returns>
        string PrintDialog(DialogModel dialog);

        /// <summary>
        /// Prompts the player with a question and returns the typed response converted to <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The expected return type for the player's response.</typeparam>
        /// <param name="question">The question text to present to the player.</param>
        /// <returns>The player's response converted to <typeparamref name="T"/>.</returns>
        T PrintPlayerQuestion<T>(string question);

        /// <summary>
        /// Asks a yes/no question and returns the player's boolean choice.
        /// </summary>
        /// <param name="question">The yes/no question to present.</param>
        /// <returns><c>true</c> if the player answered yes; otherwise <c>false</c>.</returns>
        bool PrintYesNoQuestion(string question);

        /// <summary>
        /// Displays the dice rolling screen using the specified dice and value.
        /// </summary>
        /// <param name="dice">The dice to be rolled and displayed on the screen. Cannot be null.</param>
        void RollDiceScreen(Dice dice);
    }
}
