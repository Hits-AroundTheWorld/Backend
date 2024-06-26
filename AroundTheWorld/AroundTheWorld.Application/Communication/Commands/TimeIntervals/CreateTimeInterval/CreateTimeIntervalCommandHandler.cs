using AroundTheWorld.Application.Interfaces.TimeIntervals;
using MediatR;

namespace AroundTheWorld.Application.Communication.Commands.TimeIntervals.CreateTimeInterval
{
    public class CreateTimeIntervalCommandHandler : IRequestHandler<CreateTimeIntervalCommand>
    {
        private readonly ITimeIntervalService _timeIntervalService;

        public CreateTimeIntervalCommandHandler(ITimeIntervalService timeIntervalService)
        {
            _timeIntervalService = timeIntervalService;
        }

        public async Task Handle(CreateTimeIntervalCommand request, CancellationToken cancellationToken)
        {
            await _timeIntervalService.CreateTimeInterval(request.createDayDTO);
        }
    }
}
