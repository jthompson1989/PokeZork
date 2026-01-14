using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.Common.Enum
{
    public enum Tag
    {
        NO_POKEMON, //Haven't gotten starter pokemon yet
        PORN_ADDICT, //Self explanatory
        MOMMY_ISSUE, //Poor relationship with mother
        SLEPT_IN, //Woke Up Late on first day of pokemon adventure
    }

    public static class TagExtensions
    {
        public static string ToFriendlyString(this Tag tag)
        {
            return tag switch
            {
                Tag.NO_POKEMON => "NO_POKEMON",
                Tag.PORN_ADDICT => "PORN_ADDICT",
                Tag.MOMMY_ISSUE => "MOMMY_ISSUE",
                Tag.SLEPT_IN => "SLEPT_IN"
            };
        }

        public static Tag FromFriendlyString(string str)
        {
            return str switch
            {
                "NO_POKEMON" => Tag.NO_POKEMON,
                "PORN_ADDICT" => Tag.PORN_ADDICT,
                "MOMMY_ISSUE" => Tag.MOMMY_ISSUE,
                "SLEPT_IN" => Tag.SLEPT_IN,
            };
        }
    }
}

