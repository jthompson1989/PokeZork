using PokeZork.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeZork.GameEngine.CampaignModels
{
    internal static class Converter
    {
        internal static Campaign ConvertCampaignJsonModelToEngineModel(Common.Managers.JsonModels.Campaign campaign)
        {
            try
            {
                Campaign engineCampaign = new Campaign
                {
                    Id = campaign.Id,
                    Name = campaign.Name
                };
                foreach (var chapterJson in campaign.Chapters)
                {
                    Chapter engineChapter = new Chapter
                    {
                        Id = chapterJson.Id,
                        Title = chapterJson.Title
                    };
                    foreach (var sceneJson in chapterJson.Scenes)
                    {
                        Scene engineScene = new Scene
                        {
                            Id = sceneJson.Id,
                            Title = sceneJson.Title
                        };
                        foreach (var dialogJson in sceneJson.Dialogs)
                        {
                            Dialog engineDialog = new Dialog
                            {
                                Id = dialogJson.Id,
                                Text = dialogJson.Text,
                                NextDialog = dialogJson.NextDialog ?? string.Empty
                            };
                            foreach (var commandEntry in dialogJson.Commands)
                            {
                                var command = commandEntry.Command.ToCommandEnum();
                                if (command.HasValue)
                                {
                                    engineDialog.Commands.Add(command.Value, commandEntry.Value);
                                }
                            }
                            foreach (var choiceJson in dialogJson.Choices)
                            {
                                DialogChoice engineChoice = new DialogChoice
                                {
                                    ChoiceKey = choiceJson.Key,
                                    ChoiceText = choiceJson.Text
                                };
                                foreach (var commandEntry in choiceJson.Commands)
                                {
                                    var command = commandEntry.Command.ToCommandEnum();
                                    if (command.HasValue)
                                    {
                                        engineChoice.Commands.Add(command.Value, commandEntry.Value);
                                    }
                                }
                                engineDialog.Choices.Add(engineChoice);
                            }
                            engineScene.Dialogs.Add(engineDialog);
                        }
                        engineChapter.Scenes.Add(engineScene);
                    }
                    engineCampaign.Chapters.Add(engineChapter);
                }
                return engineCampaign;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
