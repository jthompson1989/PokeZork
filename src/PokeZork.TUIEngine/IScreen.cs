using PokeZork.Common;
using PokeZork.Common.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management;
using System.Text;

namespace PokeZork.TUIEngine
{
    public interface IScreen
    {
        void Clear();

        bool IsTitleScreen();

        bool IsGameScreen();

        bool IsBattleScreen();

        bool IsHelpScreen();

        bool IsGameOverScreen();

        //Can only be called on Windows
        //Also doesn't work, will circle back
        void MaximizeScreen();

        void Write(string message);

        void DelayWrite(string message, int millisecondsDelayPerCharacter = 15);

        int PrintTitleMenu();

        void PrintGameInformation();

        void PrintGameOver();

        string PrintDialog(DialogModel dialog);

        T PrintPlayerQuestion<T>(string question);

        bool PrintYesNoQuestion(string question);
    }
}
