using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeSeason
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("directoryName")]
        public string DirectoryName { get; set; }

        [JsonPropertyName("episodes")]
        public List<AnimeEpisode> Episodes { get; set; }
    }
}