using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.Common.Enum
{
    public enum Tag
    {
        NOPOKEMON, //Haven't gotten starter pokemon yet
        PORNADDICT, //Self explanatory
        MOMMYISSUE, //Poor relationship with mother
        SLEPTIN, //Woke Up Late on first day of pokemon adventure
        TALKEDTOMOM, //Talked to mom before leaving home
    }

    public static class TagExtensions
    {
        public static string ToFriendlyString(this Tag tag)
        {
            return tag switch
            {
                Tag.NOPOKEMON => "NOPOKEMON",
                Tag.PORNADDICT => "PORNADDICT",
                Tag.MOMMYISSUE => "MOMMYISSUE",
                Tag.SLEPTIN => "SLEPTIN",
                Tag.TALKEDTOMOM => "TALKEDTOMOM",
                _ => "",
            };
        }
    }
}

