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

        public Dialog? LoadSelectedDialog(int chapterId, int sceneId, int dialogId)
        {
            var selectedchapter= Chapters.FirstOrDefault(c => c.Id == chapterId);
            if (selectedchapter == null) return null;

            var selectedScene = selectedchapter?.Scenes.FirstOrDefault(s => s.Id == sceneId);
            if (selectedScene == null) return null; 

            var selectedDialog = selectedScene?.Dialogs.FirstOrDefault(d => d.Id == dialogId);

            return selectedDialog;
        }
    }
}
