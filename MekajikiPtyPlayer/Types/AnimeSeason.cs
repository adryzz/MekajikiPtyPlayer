using System.Collections.Generic;
using Mekajiki.Types;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeSeason : IAnimeSeason
    {
        public string Name { get; set; }
        public string DirectoryName { get; set; }
        public List<IAnimeEpisode> Episodes { get; set; }
    }
}