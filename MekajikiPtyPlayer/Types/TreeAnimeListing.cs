using System.Collections.Generic;
using System.Linq;
using Terminal.Gui.Trees;

namespace MekajikiPtyPlayer.Types
{
    public class TreeAnimeListing : ITreeNode
    {
        //private IList<ITreeNode> series = new List<TreeAnimeSeries>();
        public string Text { get; set; } = "Listing";
        public IList<ITreeNode> Children
        {
            get
            {
                return new ITreeNode[]
                {
                    new TreeAnimeSeries
                    {
                        Text = "cock"
                    },
                    new TreeAnimeSeries
                    {
                        Text = "rushia1"
                    }
                }.ToList();
            }
        }

        public object Tag { get; set; }
    }
}