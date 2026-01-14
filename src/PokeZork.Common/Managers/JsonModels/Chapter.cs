using System.Collections.Generic;

namespace PokeZork.Common.Managers.JsonModels
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<Scene> Scenes { get; set; } = new List<Scene>();
    }
}
