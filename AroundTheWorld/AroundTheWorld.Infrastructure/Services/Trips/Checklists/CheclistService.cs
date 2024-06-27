using AroundTheWorld.Application.DTO.Checklist;
using AroundTheWorld.Application.Exceptions;
using AroundTheWorld.Application.Interfaces.Checklists;
using AroundTheWorld.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Infrastructure.Services.Trips.Checklists
{
    public class CheclistService : IChecklistService
    {

        private IChecklistsRepository _checklistRepository;
        private ICheckpointRepository _checkpointRepository;
        private IMapper _mapper;

        public CheclistService(IChecklistsRepository checklistRepository, IMapper mapper, ICheckpointRepository checkpointRepository)
        {
            _checklistRepository = checklistRepository;
            _mapper = mapper;
            _checkpointRepository = checkpointRepository;
        }

        public async Task CreateChecklist(CreateChecklistDTO checklistDTO, Guid userId)
        {

            var newChecklist = _mapper.Map<Checklist>(checklistDTO);
            newChecklist.UpdateTime = DateTime.UtcNow;

            await _checklistRepository.AddAsync(newChecklist);
        }

        public async Task CheckpointActions(EditCheckpointsDTO checkpointDTO)
        {
            var currentCheclist = await _checklistRepository.GetByIdAsync(checkpointDTO.ChecklistId);

            if (currentCheclist == null)
            {
                throw new NotFoundException("Чеклиста с таким id не существует");
            }

            _checklistRepository.ClearChecklist(checkpointDTO.ChecklistId);

            var Checkpoints = new List<Checkpoint>();

            foreach (var checkpoint in checkpointDTO.Checkpoints)
            {
                var newCheckpoint = _mapper.Map<Checkpoint>(checkpoint);
                newCheckpoint.ChecklistId = checkpointDTO.ChecklistId;
                if (newCheckpoint.Text.Length > 0)
                {
                    Checkpoints.Add(newCheckpoint);
                }
            }

            await _checkpointRepository.AddRangeAsync(Checkpoints);
        }

        public async Task EditChecklist(EdtiChecklistDTO checklistInfo)
        {
            var checklist = await _checklistRepository.GetByIdAsync(checklistInfo.ChecklistId);

            if (checklist == null)
            {
                throw new NotFoundException("Чеклиста с таким id не существует");
            }

            checklist.UpdateTime = DateTime.Now;

            if (checklistInfo.Title != null)
            {
                checklist.Title = checklistInfo.Title;
            }
            if (checklistInfo.Text != null)
            {
                checklist.Text = checklistInfo.Text;
            }

            await _checklistRepository.UpdateAsync(checklist);
        }


        public async Task<IList<Checklist>> GetChecklistByParentId(Guid parentId)
        {
            var checklist = await _checklistRepository.GetCheclistsByParentIdAsync(parentId);

            return checklist;
        }

        public async Task<IQueryable<Checkpoint>> GetCheckpointsFromChecklist(Guid checklistId)
        {
            var checklistExists = await _checklistRepository.ChecklistExistsAsync(checklistId);

            if (!checklistExists)
            {
                throw new NotFoundException("Чеклист с таким id не найден");
            }

            var checkpoints = _checkpointRepository.GetCheckpointsByChecklistId(checklistId);

            return checkpoints;
        }

        public async Task DeleteChecklist(Guid checklistId)
        {
            var checklist = await _checklistRepository.GetByIdAsync(checklistId);

            if (checklist == null)
            {
               throw new NotFoundException("Чеклиста с таким id не существует");
            }

            await _checklistRepository.DeleteAsync(checklist);
        }
    }
}
