using System.Collections.Generic;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeSeason
    {
        public string Name { get; set; }
        public string DirectoryName { get; set; }
        public List<AnimeEpisode> Episodes { get; set; }
    }
}