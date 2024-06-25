using AroundTheWorld.Application.Interfaces.Checklists;
using AroundTheWorld.Domain.Entities;

namespace AroundTheWorld.Infrastructure.Repositories
{
    public class CheckpointRepository : BaseRepository<Checkpoint>, ICheckpointRepository
    {

        private readonly AppDbContext _dbContext;
        public CheckpointRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Checkpoint> GetCheckpointsByChecklistId(Guid checklistId)
        {
            var checkpoints = _dbContext.Checkpoints.Where(cl => cl.ChecklistId == checklistId);

            return checkpoints;
        }
    }
}
