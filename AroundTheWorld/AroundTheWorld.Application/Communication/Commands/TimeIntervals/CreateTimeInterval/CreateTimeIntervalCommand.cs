using AroundTheWorld.Application.DTO.TimeIntervals;
using MediatR;

namespace AroundTheWorld.Application.Communication.Commands.TimeIntervals.CreateTimeInterval
{
    public record CreateTimeIntervalCommand(CreateTimeIntervalDTO createDayDTO): IRequest{}
}
