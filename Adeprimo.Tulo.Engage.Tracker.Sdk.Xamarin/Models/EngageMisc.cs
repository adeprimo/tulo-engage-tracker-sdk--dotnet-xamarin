using System;
using Newtonsoft.Json;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models
{
    public class EngageUrl
    {
        public EngageUrl(string path)
        {
            PathName = path;
        }

        [JsonProperty("pathname")]
        public string PathName { get; set; }
    }

    public class EngageLocale
    {
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("timezone_offset")]
        public string TimeZoneOffset { get; set; }
    }

    public class EngageReferrer
    {
        [JsonProperty("pathname")]
        public string PathName { get; set; }
        [JsonProperty("protocol")]
        public string Protocol { get; set; }
    }
}
