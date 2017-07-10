using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Queries.GetSourceUrlByShortenedUrl;

namespace UrlShortener.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RedirectToUrl(string shortenedUrl)
        {
            var result = await _mediator.Send(new Query(shortenedUrl)).ConfigureAwait(false);
            return RedirectPermanent(result.SourceUrl);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}