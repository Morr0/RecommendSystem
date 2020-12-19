using System.Collections.Generic;
using System.Threading.Tasks;
using RecommendSystem.Models;

namespace RecommendSystem.Services
{
    public interface IReviewService
    {
        Task<ItemReview> Review(string itemId, Review review);
        Task<IList<Review>> GetItemReviews(string itemId, int page, byte size);
    }
}