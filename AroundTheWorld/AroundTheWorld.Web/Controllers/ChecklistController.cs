using AroundTheWorld.Web.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AroundTheWorld.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistController : BaseController
    {
        public ChecklistController(IMediator mediator) : base(mediator) { }



    }
}
