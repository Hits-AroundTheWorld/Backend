using AroundTheWorld.Application.DTO.Checklist;
using AroundTheWorld.Domain.Entities;
using AutoMapper;

namespace AroundTheWorld.Application.Helpers.AutoMapper
{
    public class ChecklistMapper : Profile
    {
        public ChecklistMapper()
        {
            CreateMap<CreateChecklistDTO, Checklist>();
            CreateMap<EditCheckpointsDTO, Checkpoint>();
        }
    }
}
