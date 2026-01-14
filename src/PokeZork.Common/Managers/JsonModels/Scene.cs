using System.Collections.Generic;

namespace PokeZork.Common.Managers.JsonModels
{
    public class Scene
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Dialog> Dialogs { get; set; } = new List<Dialog>();
    }
}
