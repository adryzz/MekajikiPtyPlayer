using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MekajikiPtyPlayer.Types
{
    public class AnimeListing
    {
        [JsonPropertyName("series")]
        public List<AnimeSeries> Series { get; set; }
    }
}