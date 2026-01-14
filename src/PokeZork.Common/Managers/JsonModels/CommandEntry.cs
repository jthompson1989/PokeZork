namespace PokeZork.Common.Managers.JsonModels
{
    public class CommandEntry
    {
        /// <summary>
        /// The command name as string (e.g. "GOTO", "GAMEOVER", "SETCHARACTERTAG")
        /// </summary>
        public string Command { get; set; } = string.Empty;

        /// <summary>
        /// Command parameter / value (may be empty)
        /// </summary>
        public string Value { get; set; } = string.Empty;
    }
}