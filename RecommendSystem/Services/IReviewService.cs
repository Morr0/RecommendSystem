﻿using System.Threading.Tasks;
using RecommendSystem.Models;

namespace RecommendSystem.Services
{
    public interface IReviewService
    {
        Task<ItemReview> Review(string itemId, Review review);
    }
}