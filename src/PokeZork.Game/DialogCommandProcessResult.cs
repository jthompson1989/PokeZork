using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.GameEngine
{

    public class DialogCommandProcessResult
    {
        public DialogCommandProcessStatus? Status { get; set; } = DialogCommandProcessStatus.Success;
        public string? Message { get; set; }
        public string? Value { get; set; }

    }
    
    public enum DialogCommandProcessStatus
    {
        Success,
        Error,
        DiceRoll,
        GameOver
    }
}
