using AroundTheWorld.Application.Interfaces.TimeIntervals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.TimeIntervals.EditPointsOnMap
{
    public class EditPointsOnMapCommandHandler : IRequestHandler<EditPointsOnMapCommand>
    {
        private readonly ITimeIntervalService _timeIntervalService;

        public EditPointsOnMapCommandHandler(ITimeIntervalService timeIntervalService)
        {
            _timeIntervalService = timeIntervalService;
        }
        public async Task Handle(EditPointsOnMapCommand request, CancellationToken cancellationToken)
        {
            await _timeIntervalService.EditPointsOnMap(request.newMapPointsInfo);
        }
    }
}
