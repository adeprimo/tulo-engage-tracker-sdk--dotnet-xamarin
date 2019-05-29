using System;
using Newtonsoft.Json;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models
{
    public class EngageBrowser
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("platform")]
        public string Platform { get; set; }
        [JsonProperty("ua")]
        public string Ua { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
