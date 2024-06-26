using AroundTheWorld.Application.Interfaces.TimeIntervals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.TimeIntervals.EditTimeInterval
{
    public class EditTimeIntervalCommandHandler : IRequestHandler<EditTimeIntervalCommand>
    {
        private readonly ITimeIntervalService _timeIntervalService;

        public EditTimeIntervalCommandHandler(ITimeIntervalService timeIntervalService)
        {
            _timeIntervalService = timeIntervalService;
        }

        public async Task Handle(EditTimeIntervalCommand request, CancellationToken cancellationToken)
        {
            await _timeIntervalService.EditTimeInterval(request.editTimeIntervalDTO);
        }
    }
}
