using AutoMapper;
using UrlShortener.Contracts;
using UrlShortener.Domain;

namespace UrlShortener.Commands.AddNewShortLinkOrGetExisting
{
    // sure, in production it must be placed somewhere in pipeline (middleware) of message queue
    public class ShortenedUrlValueResolver : IValueResolver<ShortLink, Response, string>
    {
        private readonly IRequestUrlProvider _requestUrlProvider;

        public ShortenedUrlValueResolver(IRequestUrlProvider requestUrlProvider)
        {
            _requestUrlProvider = requestUrlProvider;
        }

        public string Resolve(ShortLink source, Response destination, string destMember, ResolutionContext context)
        {
            string requestUrl = _requestUrlProvider.GetRequestUrl();
            return $"{requestUrl}/{source.Encode()}";
        }
    }
}