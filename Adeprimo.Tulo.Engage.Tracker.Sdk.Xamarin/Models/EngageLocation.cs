using System;
using Newtonsoft.Json;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models
{
    public class EngageUserLocation
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }
        [JsonProperty("lon")]
        public string Longitude { get; set; }
    }
    public class EngageArticleLocation
    {
        [JsonProperty("articleLat")]
        public string Latitude { get; set; }
        [JsonProperty("articleLng")]
        public string Longitude { get; set; }
    }
}
