using System;
using System.Diagnostics;
using MekajikiPtyPlayer.Connection;
using MekajikiPtyPlayer.Types;
using Terminal.Gui;
using Terminal.Gui.Trees;

namespace MekajikiPtyPlayer.Views
{
    public class AnimeSelector : Window
    {
        private TreeView<object> tree;
        private MenuBar bar;
        public AnimeSelector()
        {
            X = 0;
            Y = 1;
            Width = Dim.Fill();
            Height = Dim.Fill();
            tree = new TreeView<object>
            {
                X = 1,
                Y = 2,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                AllowLetterBasedNavigation = true,
                TreeBuilder = new AnimeTreeBuilder(false),
                AspectGetter = AnimeTreeBuilder.GetName
            };
            tree.ObjectActivated += TreeOnObjectActivated;
            Add(tree);
            Initialized += OnInitialized;

            bar = new MenuBar
            {
                X = 0,
                Y = 0,
                Menus = new MenuBarItem[]
                {
                    new MenuBarItem
                    {
                        Title = "_File",
                        Children = new MenuItem[]
                        {
                            new MenuItem
                            {
                                Title = "_Quit",
                                Action = () => Environment.Exit(0)
                            }
                        }
                    }
                }
            };
            Add(bar);
        }

        private void OnInitialized(object? sender, EventArgs _)
        {
            try
            {
                tree.AddObjects(tree.TreeBuilder.GetChildren(this));
            }
            catch (Exception e)
            {
                MessageBox.ErrorQuery(8, 8, "Error while connecting",
                    e.InnerException != null ? e.InnerException.Message : e.Message, "OK");
            }
        }

        private void TreeOnObjectActivated(ObjectActivatedEventArgs<object> obj)
        {
            if (obj.ActivatedObject is AnimeEpisode episode)
            {
                Uri uri = new Uri(Program.Config.Server +
                                  $"api/v1/GetAnimeEpisode?token={Program.Config.Token}&videoId={episode.EpisodeId}");
                ProcessStartInfo si = new ProcessStartInfo
                {
                    FileName = "/usr/bin/mpv",
                    Arguments = uri.ToString(),
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true
                };
                Process.Start(si).WaitForExit();
            }
            else if (obj.Tree.CanExpand(obj.ActivatedObject))
            {
                if (obj.Tree.IsExpanded(obj.ActivatedObject))
                {
                    obj.Tree.Collapse(obj.ActivatedObject);
                }
                else
                {
                    obj.Tree.Expand(obj.ActivatedObject);
                }
            }
        }
    }
}