using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecommendSystem.Controllers.Queiries;
using RecommendSystem.Controllers.Responses;
using RecommendSystem.Dtos;
using RecommendSystem.Exceptions;
using RecommendSystem.Models;
using RecommendSystem.Services;

namespace RecommendSystem.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReviewService _reviewService;

        public ReviewController(IMapper mapper, IReviewService reviewService)
        {
            _mapper = mapper;
            _reviewService = reviewService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Review([FromBody] ReviewWriteDto reviewWriteDto)
        {
            var review = _mapper.Map<Review>(reviewWriteDto);
            try
            {
                var itemReview = await _reviewService.Review(reviewWriteDto.ItemId, review);
                var itemReviewReadDto = _mapper.Map<ItemReviewReadDto>(itemReview);
                return Ok(itemReviewReadDto);
            }
            catch (ItemNotFoundException e)
            {
                return NotFound(new {ItemId = reviewWriteDto.ItemId});
            }
        }

        [HttpGet("item/{itemId}")]
        public async Task<IActionResult> GetReviewsForItem([FromRoute] string itemId, [FromQuery] GetItemReviewsQuery query)
        {
            try
            {
                var reviews = await _reviewService.GetItemReviews(itemId, query.Page, query.Size, query.HaveComments);
                var reviewsReadDtos = _mapper.Map<IList<ReviewReadDto>>(reviews);
                return Ok(Response(query, ref reviewsReadDtos));
            }
            catch (ItemNotFoundException e)
            {
                return NotFound(new {ItemId = itemId});
            }
        }

        private GetReviewsForItemResponse Response(GetItemReviewsQuery query, ref IList<ReviewReadDto> reviews)
        {
            byte count = (byte) reviews.Count;
            return new GetReviewsForItemResponse
            {
                Page = query.Page,
                Size = query.Size,
                Count = count,
                Reviews = reviews
            };
        }
    }
}