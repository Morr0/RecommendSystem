using System.ComponentModel.DataAnnotations;

namespace RecommendSystem.Dtos
{
    public class ItemWriteDto
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
    }
}