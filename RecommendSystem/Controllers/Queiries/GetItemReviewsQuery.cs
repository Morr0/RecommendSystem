using System;
using System.ComponentModel.DataAnnotations;

namespace RecommendSystem.Controllers.Queiries
{
    public class GetItemReviewsQuery
    {
        private const byte MaxPageSize = 10;
        
        [Range(1, MaxPageSize)] public byte Size { get; set; } = MaxPageSize;
        [Range(0, Int32.MaxValue)] public int Page { get; set; }

        public bool HaveComments { get; set; }
    }
}