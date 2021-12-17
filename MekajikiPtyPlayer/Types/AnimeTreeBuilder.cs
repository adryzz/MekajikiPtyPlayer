using System;
using System.Collections.Generic;
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
            var f = Api.GetAnimeListing(Program.Config.Server, Program.Config.Token);
            return f;
        }

        public static string GetName(object o)
        {
            if (o is AnimeSeries s)
                return s.Name;

            if (o is AnimeSeason se)
                return se.Name;

            if (o is AnimeEpisode e)
                return e.Name;

            return o.ToString();
        }
    }
}