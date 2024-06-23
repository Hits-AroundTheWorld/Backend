using AroundTheWorld.Application.DTO.Checklist;
using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Checklists
{
    public interface IChecklistService
    {
        public Task CreateChecklist(CreateChecklistDTO checklistDTO, Guid userId);
        public Task EditChecklist(EdtiChecklistDTO checklistInfo);
        public Task<IList<Checklist>> GetChecklistByParentId(Guid parentId);
        public Task<IQueryable<Checkpoint>> GetCheckpointsFromChecklist(Guid checkpointId);
        public Task CheckpointActions(EditCheckpointsDTO checkpointDTO);
    }
}
