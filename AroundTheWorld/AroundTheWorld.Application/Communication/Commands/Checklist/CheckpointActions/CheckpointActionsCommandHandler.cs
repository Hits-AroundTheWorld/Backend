using AroundTheWorld.Application.Interfaces.Checklists;
using MediatR;

namespace AroundTheWorld.Application.Communication.Commands.Checklist.CheckpointActions
{
    public class CheckpointActionsCommandHandler: IRequestHandler<CheckpointActionsCommand>
    {
        private readonly IChecklistService _checklistService;

        public CheckpointActionsCommandHandler(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        public async Task Handle(CheckpointActionsCommand request, CancellationToken cancellationToken)
        {
            await _checklistService.CheckpointActions(request.checkpointDTO);
        }
    }
}
