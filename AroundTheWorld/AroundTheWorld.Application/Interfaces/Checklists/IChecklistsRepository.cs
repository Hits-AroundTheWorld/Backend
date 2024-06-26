using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Interfaces.Checklists
{
    public interface IChecklistsRepository: IBaseRepository<Checklist>
    {
        public Task<bool> ParentExistAsync(Guid parentId);
        public Task<IList<Checkpoint>> GetCheckpointsByChecklistIdAsync(Guid checklistId);
        public void ClearChecklist(Guid checklistId);
        public Task<IList<Checklist>> GetCheclistsByParentIdAsync(Guid parentId);
        public Task<bool> ChecklistExistsAsync(Guid checklistId);
    }
}
