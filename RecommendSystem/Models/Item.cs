using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecommendSystem.Models
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        
        [JsonIgnore]
        public IList<ItemReview> ItemReviews { get; set; }
    }
}