﻿using System.Threading.Tasks;
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
            var item = await _context.Item.FirstOrDefaultAsync().ConfigureAwait(false);
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
    }
}