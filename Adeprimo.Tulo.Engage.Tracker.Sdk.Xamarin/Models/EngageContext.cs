using System;
using Newtonsoft.Json;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models
{
    public class EngageContext
    {

        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        public EngageContext(string organizationId, string productId)
        {
            OrganizationId = organizationId;
            ProductId = productId;
        }
    }

}
