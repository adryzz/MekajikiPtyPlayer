using System.Collections.Generic;
using System.Text.Json.Serialization;
using Terminal.Gui.Trees;

namespace MekajikiPtyPlayer.Types
{
    public class TreeAnimeEpisode : ITreeNode
    {
        private List<ITreeNode> empty = new List<ITreeNode>();
        
        [JsonPropertyName("name")]
        public string Text { get; set; }
        public IList<ITreeNode> Children => empty;
        [JsonPropertyName("episodeId")]
        public object Tag { get; set; }
        
        [JsonPropertyName("episodeIndex")]
        public int Index { get; }
    }
}