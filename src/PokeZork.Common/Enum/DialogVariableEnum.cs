using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.Common.Enum
{
    //Variables that will be in dialogs that can be replaced with dynamic values.
    public enum DialogVariable
    {
        PLAYERNAME,
        PLAYERAGE
    }

    //Show Paramter if true (Parameter is in between ||)
    public enum DialogConditionalVariable
    {
        ISADULTCOND //Conditional variable to check if player is adult (18 or older).
    }

    public static class DialogVariableExtensions
    {
        public static string ToFriendlyString(this DialogVariable dialogVariable)
        {
            return dialogVariable switch
            {
                DialogVariable.PLAYERNAME => "@PLAYERNAME",
                DialogVariable.PLAYERAGE => "@PLAYERAGE"
            };
        }

        public static string ToFriendlyString(this DialogConditionalVariable dialogVariable)
        {
            return dialogVariable switch
            {
                DialogConditionalVariable.ISADULTCOND => "@ISADULTCOND"
            };
        }
    }
}
