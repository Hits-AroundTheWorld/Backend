using AroundTheWorld.Application.Interfaces.TimeIntervals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.TimeIntervals.DeleteTimeInterval
{
    public class DeleteTimeIntervalCommandHandler : IRequestHandler<DeleteTimeIntervalCommand>
    {
        private readonly ITimeIntervalService _timeIntervalService;

        public DeleteTimeIntervalCommandHandler(ITimeIntervalService timeIntervalService)
        {
            _timeIntervalService = timeIntervalService;
        }

        public async Task Handle(DeleteTimeIntervalCommand request, CancellationToken cancellationToken)
        {
            await _timeIntervalService.DeleteTimeInterval(request.timeIntervalId);
        }
    }
}
