using PokeZork.Game.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.Game.Models
{
    public class Character
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = "Unnamed";
        public required Gender Gender { get; set; } = Gender.Unknown;
        public required int Level { get; set; } = 1;
        public required int Strength { get; set; } = 1;
        public required int Agility { get; set; } = 1;
        public required int Intelligence { get; set; } =1;
        public required int Charisma { get; set; } = 1;
        public required int Constitution { get; set; } = 1;

    }
}
