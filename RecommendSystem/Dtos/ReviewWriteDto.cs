namespace RecommendSystem.Dtos
{
    public class ReviewWriteDto
    {
        public string ItemId { get; set; }

        public byte Stars { get; set; }
        public string Comment { get; set; }
    }
}