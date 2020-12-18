using System;

namespace RecommendSystem.Dtos
{
    public class ReviewReadDto
    {
        public string Id { get; set; }
        public byte Stars { get; set; }
        public string Comment { get; set; }
        public DateTime DateTime { get; set; }
    }
}