using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Terminal.Gui.Trees;

namespace MekajikiPtyPlayer.Types
{
    public class TreeAnimeListing : ITreeNode
    {
        private IList<ITreeNode> series = new List<ITreeNode>();
        public string Text { get; set; } = "Listing";
        
        [JsonPropertyName("series")]
        public IList<ITreeNode> Children => series;

        public object Tag { get; set; }
    }
}