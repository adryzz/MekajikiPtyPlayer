using System;
using Mekajiki.Types;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeEpisode : IAnimeEpisode
    {
        public int? EpisodeIndex { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public Guid EpisodeId { get; set; }
    }
}