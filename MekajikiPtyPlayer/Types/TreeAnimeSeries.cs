using System.Collections.Generic;
using Terminal.Gui.Trees;

namespace MekajikiPtyPlayer.Types
{
    public class TreeAnimeSeries : ITreeNode
    {
        public string Text { get; set; }
        public IList<ITreeNode> Children { get; }
        public object Tag { get; set; }
    }
}