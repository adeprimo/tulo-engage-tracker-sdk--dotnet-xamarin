using System;
using Newtonsoft.Json;
using Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Services;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models
{

    public class EngageEvent
    {
        [JsonProperty("clientTimestamp")]
        public string ClientTimeStamp { get; private set; }
        [JsonProperty("eventId")]
        public string EventId { get; private set; }
        [JsonProperty("eventType")]
        public string EventType { get; private set; }
        [JsonProperty("eventTypeVersion")]
        public string EventTypeVersion {get; set; }
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
        [JsonProperty("rootEventId")]
        public string RootEventId { get; set; }
        [JsonProperty("eventCustomData")]
        public object EventCustomData { get; set; }
        [JsonProperty("context")]
        public EngageContext Context { get; set; }
        [JsonProperty("user")]
        public EngageUser User { get; set; }
        [JsonProperty("content")]
        public EngageContent Content { get; set; }
        [JsonProperty("source")]
        public EngageSource Source { get; set; }


        public EngageEvent(string eventType, string rootEventId, string clientId, string eventTypeVersion="1")
        {
            EventType = eventType;
            RootEventId = rootEventId;
            ClientId = clientId;
            EventTypeVersion = eventTypeVersion;
            EventId = Util.GenerateGuid();
            ClientTimeStamp = FormattedUtcNow;
        }

        public string Build()
        {
            return JsonConvert.SerializeObject(this);
        }

        public bool ShouldSerializeSource()
        {
            if (Source != null)
                return true;
            return false;
        }
        public bool ShouldSerializeContent()
        {
            if (Content != null)
                return true;
            return false;
        }
        public bool ShouldSerializeUser()
        {
            if (User!=null)
                return true;
            return false;
        }
        public bool ShouldSerializeEventCustomData()
        {
            if (EventCustomData != null)
                return true;
            return false;
        }
        string FormattedUtcNow => DateTime.UtcNow.ToString("o");

    }

}