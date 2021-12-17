using System;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeEpisode
    {
        public int? EpisodeIndex { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public Guid EpisodeId { get; set; }
    }
}