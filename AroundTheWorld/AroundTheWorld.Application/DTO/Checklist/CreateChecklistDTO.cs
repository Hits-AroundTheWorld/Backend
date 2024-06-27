namespace AroundTheWorld.Application.DTO.Checklist
{
    public class CreateChecklistDTO
    {
        public required string Title { get; set; }
        public string? Text { get; set; }
        public Guid ParentId { get; set; }
    }
}
