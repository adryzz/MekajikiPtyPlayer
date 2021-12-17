using System;
using System.Collections.Generic;
using Mekajiki.Types;
using MekajikiPtyPlayer.Connection;
using Terminal.Gui.Trees;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeTreeBuilder : TreeBuilder<object>
    {
        public AnimeTreeBuilder(bool supportsCanExpand) : base(supportsCanExpand)
        {
            
        }

        public override IEnumerable<object> GetChildren(object forObject)
        {
            return Api.GetAnimeListing(Program.Config.Server, Program.Config.Token);
        }

        public static string GetName(object o)
        {
            if (o is IAnimeSeries s)
                return s.Name;

            if (o is IAnimeSeason se)
                return se.Name;

            if (o is IAnimeEpisode e)
                return e.Name;

            return o.ToString();
        }
    }
}