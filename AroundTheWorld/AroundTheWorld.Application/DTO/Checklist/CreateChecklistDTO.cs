namespace AroundTheWorld.Application.DTO.Checklist
{
    public class CreateChecklistDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public Guid ParentId { get; set; }
    }
}
