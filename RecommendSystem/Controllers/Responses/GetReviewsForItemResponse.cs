using System.Collections.Generic;
using RecommendSystem.Dtos;

namespace RecommendSystem.Controllers.Responses
{
    public class GetReviewsForItemResponse
    {
        public byte Size { get; set; }
        public byte Count { get; set; }
        public int Page { get; set; }
        
        public IList<ReviewReadDto> Reviews { get; set; }
    }
}