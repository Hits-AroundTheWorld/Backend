using AroundTheWorld.Application.DTO.Checklist;
using AroundTheWorld.Domain.Entities;

namespace AroundTheWorld.Application.Interfaces.Checklists
{
    public interface IChecklistService
    {
        public Task CreateChecklist(CreateChecklistDTO checklistDTO, Guid userId);
        public Task EditChecklist(EdtiChecklistDTO checklistInfo);
        public Task<IList<Checklist>> GetChecklistByParentId(Guid parentId);
        public Task<IQueryable<Checkpoint>> GetCheckpointsFromChecklist(Guid checklistId);
        public Task CheckpointActions(EditCheckpointsDTO checkpointDTO);
        public Task DeleteChecklist(Guid checklistId);
    }
}
