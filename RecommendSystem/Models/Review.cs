using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecommendSystem.Models
{
    public class Review
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public byte Stars { get; set; }
        public string Comment { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        
        [JsonIgnore]
        public IList<ItemReview> ItemReviews { get; set; }
    }
}