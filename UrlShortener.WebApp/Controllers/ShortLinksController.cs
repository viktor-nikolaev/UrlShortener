using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Commands.AddNewShortLinkOrGetExisting;

namespace UrlShortener.WebApp.Controllers
{
    // I prefer message based api
    // So in production there would be only one endpoint receives any kind of message
    // here is a good article about pros and cons http://docs.servicestack.net/what-is-a-message-based-web-service
    [Route("api/[controller]")]
    public class ShortLinksController : Controller
    {
        private readonly IMediator _mediator;

        public ShortLinksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<Response> Post([FromBody] Command command)
        {
            return _mediator.Send(command);
        }
    }
}