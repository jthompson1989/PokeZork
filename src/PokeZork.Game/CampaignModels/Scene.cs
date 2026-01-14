using PokeZork.GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace PokeZork.GameEngine.CampaignModels
{
    internal class Scene
    {
        internal int Id { get; set; }
        internal string Title { get; set; } = string.Empty;
        internal List<NonPlayer> NPCs { get; set; } = new List<NonPlayer>();
        internal List<Dialog> Dialogs { get; set; } = new List<Dialog>();
    }
}
