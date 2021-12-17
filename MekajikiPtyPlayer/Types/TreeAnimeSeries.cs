using System.Collections.Generic;
using System.Text.Json.Serialization;
using Terminal.Gui.Trees;

namespace MekajikiPtyPlayer.Types
{
    public class TreeAnimeSeries : ITreeNode
    {
        [JsonPropertyName("name")]
        public string Text { get; set; }
        
        [JsonPropertyName("seasons")]
        public IList<ITreeNode> Children { get; }
        
        public object Tag { get; set; }
    }
}