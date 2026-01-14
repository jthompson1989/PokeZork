using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.GameEngine.CampaignModels
{
    internal class Chapter
    {
        internal int Id { get; set; }
        internal string Title { get; set; } = string.Empty;
        internal List<Scene> Scenes = new List<Scene>();

        internal void LoadScenes()
        {            
            // Load scenes logic here
        }
    }
}
