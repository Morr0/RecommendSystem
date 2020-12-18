﻿namespace RecommendSystem.Models
{
    public class ItemReview
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public string ReviewId { get; set; }
        public Review Review { get; set; }
    }
}