using PokeZork.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.GameEngine.Models
{
    public class Character
    {
        private Gender _gender;
        private string[] genderMaleKeyword = new string[] { "boy", "man", "male", "dude", "he", "he/him", "him" };
        private string[] genderFemaleKeyword = new string[] { "girl", "woman", "female", "dudette", "she", "she/her", "her" };
        private string[] genderNeutralKeyword = new string[] { "non-binary", "nb", "other", "neither", "both", "nonbinary", "non binary", "they" };
        public required int Id { get; set; }
        public string Name { get; set; } = "Unnamed";
        public int Age { get; set; } = 1;
        public string Gender {
            get
            {
                if (this._gender == Common.Enum.Gender.Man && this.Age >= 18)
                {
                    return "Man";
                }
                else if (this._gender == Common.Enum.Gender.Man && this.Age < 18)
                {
                    return "Boy";
                }
                if (this._gender == Common.Enum.Gender.Woman && this.Age >= 18)
                {
                    return "Woman";
                }
                else if (this._gender == Common.Enum.Gender.Woman && this.Age < 18)
                {
                    return "Girl";
                }
                else if(this._gender == Common.Enum.Gender.NonBinary)
                {
                    return "Non-Binary";
                }
                else
                {
                    return "Eldritch";
                }
            }
            set
            {
                string input = value.Trim().ToLower();
                if (genderMaleKeyword.Contains(input))
                {
                    this._gender = Common.Enum.Gender.Man;
                }
                else if (genderFemaleKeyword.Contains(input))
                {
                    this._gender = Common.Enum.Gender.Woman;
                }
                else if (genderNeutralKeyword.Contains(input))
                {
                    this._gender = Common.Enum.Gender.NonBinary;
                }
                else
                {
                    this._gender = Common.Enum.Gender.Unknown;
                }
            } 
        }

        public Faction Faction { get; set; } = Faction.NONE;
        public int Level { get; set; } = 1;
        public int Strength { get; set; } = 1;
        public int Agility { get; set; } = 1;
        public int Intelligence { get; set; } = 1;
        public int Charisma { get; set; } = 1;
        public int Constitution { get; set; } = 1;

    }
}
