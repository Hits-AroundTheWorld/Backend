using AroundTheWorld.Domain.Entities;

namespace AroundTheWorld.Application.DTO.Checklist
{
    public class EditCheckpointsDTO
    {
        public Guid ChecklistId { get; set; }
        public List<Checkpoint> Checkpoints { get; set; }
    }
}
