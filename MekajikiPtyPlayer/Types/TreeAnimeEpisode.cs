using System.Collections.Generic;
using Terminal.Gui.Trees;

namespace MekajikiPtyPlayer.Types
{
    public class TreeAnimeEpisode : ITreeNode
    {
        private List<ITreeNode> empty = new List<ITreeNode>();
        public string Text { get; set; }
        public IList<ITreeNode> Children => empty;
        public object Tag { get; set; }
    }
}