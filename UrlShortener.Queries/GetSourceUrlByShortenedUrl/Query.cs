using MediatR;

namespace UrlShortener.Queries.GetSourceUrlByShortenedUrl
{
    public class Query : IRequest<Result>
    {
        public Query(string shortenedUrl)
        {
            ShortenedUrl = shortenedUrl;
        }

        public string ShortenedUrl { get; set; }
    }
}