using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        //don't inject mediatr so derived controllers can use it
        //this is a lazy loaded property that will get the IMediator from the HttpContext's RequestServices
        private IMediator? _mediator = null;
        protected IMediator Mediator => 
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("Mediator service is unavaiable.");
    }
}
