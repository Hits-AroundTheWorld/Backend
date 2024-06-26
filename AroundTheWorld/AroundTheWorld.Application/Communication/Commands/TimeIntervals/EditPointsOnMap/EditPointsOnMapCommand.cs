using AroundTheWorld.Application.DTO.TimeIntervals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AroundTheWorld.Application.Communication.Commands.TimeIntervals.EditPointsOnMap
{
    public record EditPointsOnMapCommand(NewMapPointsDTO newMapPointsInfo) : IRequest{}
}
