using AroundTheWorld.Application.DTO.Trip;
using MediatR;
using AroundTheWorld.Domain.Entities;

namespace AroundTheWorld.Application.Communication.Queries.Checklists.GetChecklistByParentId
{
    public record GetChecklistByParentIdQuery(Guid parentId) : IRequest<IList<Checklist>>{}
}
