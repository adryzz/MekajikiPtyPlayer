using System.Collections.Generic;
using Mekajiki.Types;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeSeries : IAnimeSeries
    {
        public string Name { get; set; }
        public string DirectoryName { get; set; }
        public List<IAnimeSeason> Seasons { get; set; }
    }
}