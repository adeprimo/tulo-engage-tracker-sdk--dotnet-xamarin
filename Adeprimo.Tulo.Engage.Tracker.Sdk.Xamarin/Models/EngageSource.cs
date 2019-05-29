using System;
using Newtonsoft.Json;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models
{
    public class EngageSource
    {
        [JsonProperty("browser")]
        public EngageBrowser Browser { get; set; }
        [JsonProperty("screen")]
        public EngageScreen Screen { get; set; }
        [JsonProperty("url")]
        public EngageUrl Url { get; set; }
        [JsonProperty("locale")]
        public EngageLocale Locale { get; set; }
        [JsonProperty("referrer")]
        public EngageReferrer Referrer { get; set; }

        public bool ShouldSerializeBrowser()
        {
            if (Browser != null) return true;
            return false;
        }
        public bool ShouldSerializeScreen()
        {
            if (Screen != null) return true;
            return false;
        }

        public bool ShouldSerializeUrl()
        {
            if (Url != null) return true;
            return false;
        }
        public bool ShouldSerializeLocale()
        {
            if (Locale != null) return true;
            return false;
        }
        public bool ShouldSerializeReferrer()
        {
            if (Referrer != null) return true;
            return false;
        }

    }
}
