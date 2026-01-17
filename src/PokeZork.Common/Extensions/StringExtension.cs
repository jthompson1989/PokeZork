using PokeZork.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PokeZork.Common.Extensions
{
    public static class StringExtension
    {
        /// <summary>  
        /// Determines whether the specified string consists only of numeric characters.  
        /// </summary>  
        /// <param name="value">The input string to check.</param>  
        /// <returns>True if the string contains only numeric characters; otherwise, false.</returns>  
        public static bool IsNumber(this string value)
        {
            return value.All(char.IsDigit) ? true : false;
        }

        /// <summary>  
        /// Converts the specified string to a <see cref="DateTime"/> object.  
        /// </summary>  
        /// <param name="value">The input string to convert.</param>  
        /// <returns>A <see cref="DateTime"/> object if the conversion is successful; otherwise, the default <see cref="DateTime"/> value.</returns>  
        public static DateTime ToDateTime(this string value)
        {
            DateTime result;
            DateTime.TryParse(value, out result);
            return result;
        }

        /// <summary>  
        /// Converts a string to a URL-friendly slug by replacing spaces with underscores and converting to lowercase.  
        /// </summary>  
        /// <param name="value">The input string to be converted.</param>  
        /// <returns>A slugified version of the input string.</returns>  
        public static string ToSlug(this string? value)
        {
            if (value == null)
            {
                return String.Empty;
            }
            return value.ToLower().Replace(" ", "_");
        }

        /// <summary>  
        /// Converts a string to an abbreviation by extracting the first uppercase letter of up to three words.  
        /// </summary>  
        /// <param name="value">The input string to be converted.</param>  
        /// <returns>An abbreviation consisting of up to three uppercase letters, or an empty string if the input is null or does not contain valid words.</returns>  
        public static string ToAbbreviation(this string? value)
        {
            if (value != null)
            {
                return new string(value.Split()
                          .Where(s => s.Length > 0 && char.IsLetter(s[0]) && char.IsUpper(s[0]))
                          .Take(3)
                          .Select(s => s[0])
                          .ToArray());
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>  
        /// Converts a PascalCase string to a string with spaces between words.  
        /// </summary>  
        /// <param name="value">The input PascalCase string.</param>  
        /// <returns>A string with spaces between words extracted from the PascalCase input.</returns>  
        public static string AddWhiteSpaces(this string value)
        {
            return Regex.Replace(value, "(?<!^)([A-Z])", " $1");
        }

        public static bool IsEmpty(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return true;
            }
            if(string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }

        public static Command? ToCommandEnum(this string str)
        {
            return str switch
            {
                "ROLLDICE" => Command.ROLLDICE,
                "GIVEITEM" => Command.GIVEITEM,
                "TAKEITEM" => Command.TAKEITEM,
                "GETPOKEMON" => Command.GETPOKEMON,
                "HEALPOKEMON" => Command.HEALPOKEMON,
                "SETCHARACTERTAG" => Command.SETCHARACTERTAG,
                "SETITEMTAG" => Command.SETITEMTAG,
                "GOTO" => Command.GOTO,
                "POKEMONBATTLE" => Command.POKEMONBATTLE,
                "GAMEOVER" => Command.GAMEOVER,
                "" => Command.NONE,
                _=> null
            };
        }

        public static Tag? ToTagEnum(this string str)
        {
            return str switch
            {
                "NOPOKEMON" => Tag.NOPOKEMON,
                "PORNADDICT" => Tag.PORNADDICT,
                "MOMMYISSUE" => Tag.MOMMYISSUE,
                "SLEPTIN" => Tag.SLEPTIN,
                "TALKEDTOMOM" => Tag.TALKEDTOMOM,
                _=> null
            };
        }

        public static DialogVariable? ToDialogVariable(this string str)
        {
            return str switch
            {
                "@PLAYERNAME" => DialogVariable.PLAYERNAME,
                "@CURRENTLOCATION" => DialogVariable.PLAYERAGE,
                _ => null,
            };
        }
        public static bool IsSystemCommand(this string str)
        {
            foreach (SystemCommand command in System.Enum.GetValues(typeof(SystemCommand)))
            {
                if (str == command.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public static SystemCommand? ToSystemCommand(this string str)
        {
            return str switch
            {
                "POKEDEX" => SystemCommand.POKEDEX,
                "PARTY" => SystemCommand.PARTY,
                "STATS" => SystemCommand.STATS,
                "ITEMS" => SystemCommand.ITEMS,
                "SAVE" => SystemCommand.SAVE,
                "HELP" => SystemCommand.HELP,
                "QUIT" => SystemCommand.QUIT,
                _ => null
            };
        }
    }

}
