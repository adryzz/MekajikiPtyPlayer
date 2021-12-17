using System;
using System.Text.Json.Serialization;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeEpisode
    {
        [JsonPropertyName("episodeIndex")]
        public int? EpisodeIndex { get; set; }

        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("episodeId")]
        public Guid EpisodeId { get; set; }
    }
}