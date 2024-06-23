using AroundTheWorld.Application.Interfaces.Checklists;
using AroundTheWorld.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure.Repositories
{
    public class CheckpointRepository : BaseRepository<Checkpoint>, ICheckpointRepository
    {

        private readonly AppDbContext _dbContext;
        protected CheckpointRepository(AppDbContext dbContext) : base(dbContext)
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
