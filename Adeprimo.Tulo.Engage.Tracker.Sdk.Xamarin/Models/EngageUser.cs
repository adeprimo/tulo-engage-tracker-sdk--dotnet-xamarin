using System;
using Newtonsoft.Json;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models
{
    public class EngageUser
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("paywayId")]
        public string PaywayUserId { get; set; }
        [JsonProperty("products")]
        public string[] Products { get; set; }
        public bool LoggedIn { private get; set; }
        [JsonProperty("position")]
        public EngageUserLocation Position { get; set; }

        [JsonProperty("states")]
        public string[] States
        {
            get
            {
                if (LoggedIn)
                    return new string[] { "logged_in" };
                return new string[] { "anonymous" };
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
