using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeSeries
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("directoryName")]
        public string DirectoryName { get; set; }

        [JsonPropertyName("seasons")]
        public List<AnimeSeason> Seasons { get; set; }
    }
}