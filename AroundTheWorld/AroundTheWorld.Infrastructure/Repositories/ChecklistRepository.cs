using AroundTheWorld.Application.Interfaces.Checklists;
using AroundTheWorld.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AroundTheWorld.Infrastructure.Repositories
{
    public class ChecklistRepository : BaseRepository<Checklist>, IChecklistsRepository
    {
        private readonly AppDbContext _dbContext;

        public ChecklistRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ParentExistAsync(Guid parentId)
        {
            var parentExist = await _dbContext.Checklists
                .Where(cl => cl.Id == parentId)
                .Select(cl => cl.ParentId)
                .Union(_dbContext.Days
                    .Where(d => d.Id == parentId)
                    .Select(d => d.Id))
                .AnyAsync();

            return parentExist;
        }

        public async Task<IList<Checklist>> GetCheclistsByParentIdAsync(Guid parentId)
        {
            var checklists = await _dbContext.Checklists
                .Where(cl => cl.ParentId == parentId)
                .ToListAsync();

            return checklists;
        }

        public async Task<IList<Checkpoint>> GetCheckpointsByChecklistIdAsync(Guid checklistId)
        {
            var checkpoints = await _dbContext.Checkpoints
                .Where(cp => cp.ChecklistId == checklistId)
                .ToListAsync();

            return checkpoints;
        }

        public void ClearChecklist(Guid checklistId)
        {
            var checklists = _dbContext.Checkpoints.Where(cp => cp.ChecklistId == checklistId);
            _dbContext.RemoveRange(checklists);
            _dbContext.SaveChangesAsync();
        }
        public async Task<bool> ChecklistExistsAsync(Guid checklistId)
        {
            var checklistExists = await _dbContext.Checklists.Where(cl => cl.Id == checklistId).AnyAsync();

            return checklistExists;
        }
    }
}
