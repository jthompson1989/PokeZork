using System.Collections.Generic;

namespace PokeZork.Common.Managers.JsonModels
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Unnamed Campaign";
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();
    }
}
