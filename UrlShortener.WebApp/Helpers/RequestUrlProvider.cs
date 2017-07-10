using Microsoft.AspNetCore.Http;
using UrlShortener.Contracts;

namespace UrlShortener.WebApp.Helpers
{
    internal class RequestUrlProvider : IRequestUrlProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestUrlProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public HttpContext HttpContext => _httpContextAccessor.HttpContext;

        public string GetRequestUrl()
        {
            var request = HttpContext.Request;
            return $"{request.Scheme}://{request.Host}";
        }
    }
}