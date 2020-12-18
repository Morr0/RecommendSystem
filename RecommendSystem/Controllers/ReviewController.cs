using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}