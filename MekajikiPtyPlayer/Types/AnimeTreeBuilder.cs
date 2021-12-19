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
            if (forObject is AnimeSeries series)
                return series.Seasons;

            if (forObject is AnimeSeason season)
                return season.Episodes;
            
            if (forObject is AnimeEpisode)
                return new List<object>();

            return Api.GetAnimeListing(Program.Config.Server, Program.Config.Token);
        }

        public static string GetName(object o)
        {
            if (o is AnimeSeries s)
                return s.Name;

            if (o is AnimeSeason se)
                return se.Name;

            if (o is AnimeEpisode e)
                return e.Name + " - " + e.Length;

            return o.ToString();
        }
    }
}