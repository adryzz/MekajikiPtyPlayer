using MekajikiPtyPlayer.Types;
using Terminal.Gui;
using Terminal.Gui.Trees;

namespace MekajikiPtyPlayer.Views
{
    public class AnimeSelector : Window
    {
        private TreeView<ITreeNode> tree;
        public AnimeSelector()
        {
            X = 0;
            Y = 1;
            Width = Dim.Fill();
            Height = Dim.Fill();
            tree = new TreeView<ITreeNode>();
            tree.AddObject(new TreeAnimeListing());
            tree.ObjectActivated += TreeOnObjectActivated;
            Add(tree);
        }

        private void TreeOnObjectActivated(ObjectActivatedEventArgs<ITreeNode> obj)
        {
            
        }
    }
}