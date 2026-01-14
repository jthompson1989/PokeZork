using PokeZork.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.GameEngine.CampaignModels
{
    internal class Dialog
    {
        internal int Id { get; set; }
        internal string Text { get; set; } = string.Empty;
        //Use if no choices
        internal string NextDialog { get; set; } = string.Empty; //Example: "1:2:3"  

        internal List<DialogChoices> Choices { get; set; } = new List<DialogChoices>();
    }

    internal class  DialogChoices
    {
        internal int Id { get; set; }
        internal string ChoiceKey { get; set; } = string.Empty;
        internal string ChoiceText { get; set; } = string.Empty;
        // Command to execute when this choice is selected, value is parameters.
        internal Dictionary<Command, string> Commands { get; set; } = new Dictionary<Command, string>();

    }
}
