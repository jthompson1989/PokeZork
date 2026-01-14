using PokeZork.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.GameEngine.Models
{
    public class Player : Character
    {
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
