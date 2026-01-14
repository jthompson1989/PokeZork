using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.Common
{
    public class DialogModel
    {
        public string DialogText { get; set; } = string.Empty;

        //Key: Return Value, Value: Display Text
        public Dictionary<string, string> DialogChoices { get; set; } = new Dictionary<string, string>();
    }
}
