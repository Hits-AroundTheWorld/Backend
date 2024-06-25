using AroundTheWorld.Application.Interfaces.Checklists;
using MediatR;


namespace AroundTheWorld.Application.Communication.Commands.Checklist.DeleteChecklist
{
    internal class DeleteChecklistCommandHandler : IRequestHandler<DeleteChecklistCommand>
    {

        private readonly IChecklistService _checklistService;

        public DeleteChecklistCommandHandler(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        public async Task Handle(DeleteChecklistCommand request, CancellationToken cancellationToken)
        {
            await _checklistService.DeleteChecklist(request.checklistId);
        }
    }
}
