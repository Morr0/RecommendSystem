using System.ComponentModel.DataAnnotations;

namespace RecommendSystem.Dtos
{
    public class ReviewWriteDto
    {
        [Required]
        [MinLength(1)]
        public string ItemId { get; set; }
        
        [Required]
        [Range(0, 10)]
        public byte Stars { get; set; }
        [MinLength(1)]
        public string Comment { get; set; }
    }
}