using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.GameEngine.CampaignModels
{
    internal class Campaign
    {
        internal required int Id { get; set; }
        internal string Name { get; set; } = "Unnamed Campaign";
        internal List<Chapter> Chapters { get; set; } = new List<Chapter>();
    }
}
