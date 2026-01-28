using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.Common.DiceMechanics
{
    public class Dice
    {
        public DiceType Type { get; set; }
        public int AmountRolled { get; set; }
        public int? RolledValue { get; set; } 
        public string DiceNotation 
        { 
            get 
            { 
                return $"{AmountRolled}d{(int)Type}"; 
            }
            set
            {
                var parts = value.ToLower().Split('d');
                if (parts.Length != 2 ||
                    !int.TryParse(parts[0], out int amount) ||
                    !int.TryParse(parts[1], out int typeValue) ||
                    !System.Enum.IsDefined(typeof(DiceType), typeValue))
                {
                    throw new ArgumentException("Invalid dice notation");
                }
                AmountRolled = amount;
                Type = (DiceType)typeValue;
            }
        }

        public Dice(string diceNotation)
        {
            var parts = diceNotation.ToLower().Split('d');
            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int amount) ||
                !int.TryParse(parts[1], out int typeValue) ||
                !System.Enum.IsDefined(typeof(DiceType), typeValue))
            {
                throw new ArgumentException("Invalid dice notation");
            }
            AmountRolled = amount;
            Type = (DiceType)typeValue;
        }  

        public void Roll()
        {
            Random rand = new Random();
            int total = 0;
            for (int i = 0; i < AmountRolled; i++)
            {
                total += rand.Next(1, (int)Type);
            }
            RolledValue = total;
        }
    }

    public enum DiceType
    {
        D2 = 2,
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
        D100 = 100,
        D200 = 200
    }
}
