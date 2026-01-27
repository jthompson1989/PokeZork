using PokeZork.Common;
using PokeZork.Common.Enum;
using PokeZork.Common.Managers.JsonModels;
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

        internal List<DialogChoice> Choices { get; set; } = new List<DialogChoice>();

        //These are commands that run on dialog load, not choice selection
        internal List<CommandEntry> Commands { get; set; } = new List<CommandEntry>();

        internal DialogModel ConvertToDialogModel()
        {
            DialogModel dialogModel = new DialogModel
            {
                DialogText = this.Text
            };

            foreach (var choice in this.Choices)
            {
                dialogModel.DialogChoices.Add(choice.ChoiceKey, choice.ChoiceText);
            }
            return dialogModel;
        }
    }

    internal class  DialogChoice
    {
        internal int Id { get; set; }
        internal string ChoiceKey { get; set; } = string.Empty;
        internal string ChoiceText { get; set; } = string.Empty;
        // Command to execute when this choice is selected, value is parameters.
        internal Dictionary<Command, string> Commands { get; set; } = new Dictionary<Command, string>();

    }
}
