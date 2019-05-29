using System;
using Newtonsoft.Json;

namespace Adeprimo.Tulo.Engage.Tracker.Sdk.Xamarin.Models
{
    public class EngageContent
    {
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("articleId")]
        public string ArticleId { get; set; }
        [JsonProperty("publishDate")]
        public string PublishDate { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("section")]
        public string Section { get; set; }
        [JsonProperty("keywords")]
        public string[] Keywords { get; set; }
        [JsonProperty("authorId")]
        public string[] AuthorId { get; set; }

        [JsonProperty("location")]
        public EngageArticleLocation Location { get; set; }

        public bool ShouldSerializePublishDate()
        {
            if (PublishDate != null) return true;
            return false;
        }

        public bool ShouldSerializeSection()
        {
            if (PublishDate != null) return true;
            return false;
        }
    }
}
