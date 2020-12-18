using System;
using System.Collections.Generic;

namespace RecommendSystem.Models
{
    public class Review
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public byte Stars { get; set; }
        public string Comment { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        
        public IList<ItemReview> ItemReviews { get; set; }
    }
}