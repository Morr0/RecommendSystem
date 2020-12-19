using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecommendSystem.Exceptions;
using RecommendSystem.Models;
using RecommendSystem.Repositories;

namespace RecommendSystem.Services
{
    public class ReviewService : IReviewService
    {
        private DataContext _context;

        public ReviewService(DataContext context)
        {
            _context = context;
        }
        
        public async Task<ItemReview> Review(string itemId, Review review)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(false);
            var item = await _context.Item.FirstOrDefaultAsync(x => x.Id == itemId).ConfigureAwait(false);
            if (item is null)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                throw new ItemNotFoundException();
            }

            await _context.Review.AddAsync(review).ConfigureAwait(false);
            var itemReview = new ItemReview
            {
                Item = item,
                Review = review
            };
            await _context.ItemReview.AddAsync(itemReview).ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);
            await transaction.CommitAsync().ConfigureAwait(false);

            return itemReview;
        }

        public async Task<IList<Review>> GetItemReviews(string itemId, int page, byte size, bool hasComment)
        {
            var hasItem = await _context.Item.AsNoTracking().AnyAsync(x => x.Id == itemId).ConfigureAwait(false);
            if (!hasItem) throw new ItemNotFoundException();

            var queryable = (from ir in _context.ItemReview
                    join i in _context.Item on ir.ItemId equals i.Id
                    join r in _context.Review on ir.ReviewId equals r.Id
                    where ir.ItemId == itemId
                    select ir.Review)
                .Skip(page * size)
                .Take(size);

            if (hasComment)
            {
                queryable = queryable.Where(x => !string.IsNullOrEmpty(x.Comment));
            }

            var reviews = await queryable.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return reviews;
        }
    }
}