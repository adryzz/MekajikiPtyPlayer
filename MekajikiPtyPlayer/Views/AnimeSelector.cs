using System;
using MekajikiPtyPlayer.Connection;
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
            tree.ObjectActivated += TreeOnObjectActivated;
            Add(tree);
            Initialized += OnInitialized;
        }

        private void OnInitialized(object? sender, EventArgs e)
        {
            tree.AddObjects(Api.GetAnimeListing(Program.Config.Server, Program.Config.Token));
        }

        private void TreeOnObjectActivated(ObjectActivatedEventArgs<ITreeNode> obj)
        {
            
        }
    }
}