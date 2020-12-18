using System;
using System.Collections.Generic;

namespace RecommendSystem.Models
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        
        public IList<ItemReview> ItemReviews { get; set; }
    }
}