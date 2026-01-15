using System.Collections.Generic;

namespace PokeZork.Common.Managers.JsonModels
{
    public class DialogChoice
    {
        /// <summary>
        /// Choice key as presented to the player (e.g. "1", "A")
        /// </summary>
        public string Key { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Optional age gating metadata (matches your JSON example).
        /// </summary>
        public int? MinPlayerAge { get; set; }
        public int? MaxPlayerAge { get; set; }

        /// <summary>
        /// List of command entries for this choice. Commands are stored as strings
        /// (e.g. "GOTO", "GAMEOVER", "SETCHARACTERTAG") to avoid coupling to runtime enums.
        /// </summary>
        public List<CommandEntry> Commands { get; set; } = new List<CommandEntry>();
    }
}