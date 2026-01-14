using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.Common.Enum
{
    public enum Command
    {
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
        POKEMONBATTLE
    }
}
