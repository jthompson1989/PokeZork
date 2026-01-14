using PokeZork.Common;
using PokeZork.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.Common.Managers.JsonModels
{
    public class Dialog
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        /// <summary>
        /// Navigation token (example: "1:2:3"). May be null when not set.
        /// </summary>
        public string? NextDialog { get; set; }
        public List<DialogChoice> Choices { get; set; } = new List<DialogChoice>();
    }
}
