using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.Common.Enum
{
    public enum Command
    {
        NONE,
        ROLLDICE,
        GIVEITEM,
        TAKEITEM,
        GETPOKEMON,
        HEALPOKEMON,
        //Parameter would be CharacterId, or 0  if it's a player, and Tag Example Player:PORN_ADDICT
        SETCHARACTERTAG, 
        SETITEMTAG,
        //GOTO a dialog: Parameter would be ChapterId:SceneId:DialogId Example 1:2:3
        GOTO,
        POKEMONBATTLE,
        GAMEOVER
    }

    public static class CommandExtensions
    {
        public static string ToFriendlyString(this Command command)
        {
            return command switch
            {
                Command.ROLLDICE => "ROLLDICE",
                Command.GIVEITEM => "GIVEITEM",
                Command.TAKEITEM => "TAKEITEM",
                Command.GETPOKEMON => "GETPOKEMON",
                Command.HEALPOKEMON => "HEALPOKEMON",
                Command.SETCHARACTERTAG => "SETCHARACTERTAG",
                Command.SETITEMTAG => "SETITEMTAG",
                Command.GOTO => "GOTO",
                Command.POKEMONBATTLE => "POKEMONBATTLE",
                Command.GAMEOVER => "GAMEOVER",
                _=> "",
            };
        }
    }
}
