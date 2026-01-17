using PokeZork.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.GameEngine.Models
{
    public class Player : Character
    {
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public string GetStatsSummaryString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player Name: {this.Name}");
            sb.AppendLine($"Player Age: {this.Age}");
            sb.AppendLine($"Player Gender: {this.Gender}");
            sb.AppendLine($"Level: {this.Level}");
            sb.AppendLine($"Strength: {this.Strength}");
            sb.AppendLine($"Constitution: {this.Constitution}");
            sb.AppendLine($"Agility: {this.Agility}");
            sb.AppendLine($"Charisma: {this.Charisma}");
            sb.AppendLine($"Intelligence: {this.Intelligence}");
            sb.AppendLine($"Faction: {this.Faction.ToString()}");
            return sb.ToString();
        }
    }
}
