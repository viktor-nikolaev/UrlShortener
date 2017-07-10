using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Dal;
using UrlShortener.Domain;

namespace UrlShortener.Queries.GetSourceUrlByShortenedUrl
{
    public class Handler : IAsyncRequestHandler<Query, Result>
    {
        private readonly UrlShortenerDb _db;

        public Handler(UrlShortenerDb db)
        {
            _db = db;
        }

        public async Task<Result> Handle(Query message)
        {
            int id = ShortLink.Decode(message.ShortenedUrl);
            return await _db.ShortLinks
                .Where(x => x.Id == id)
                .ProjectTo<Result>()
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}