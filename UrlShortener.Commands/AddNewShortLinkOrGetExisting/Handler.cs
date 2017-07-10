using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Dal;
using UrlShortener.Domain;

namespace UrlShortener.Commands.AddNewShortLinkOrGetExisting
{
    public class Handler : IAsyncRequestHandler<Command, Response>
    {
        private readonly UrlShortenerDb _db;
        private readonly IMapper _mapper;

        public Handler(UrlShortenerDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Command message)
        {
            if (!Uri.IsWellFormedUriString(message.SourceUrl, UriKind.Absolute))
            {
                throw new InvalidOperationException("URL is not valid");
            }

            var existing = await _db.ShortLinks
                .Where(x => x.SourceUrl == message.SourceUrl)
                .ToListAsync()
                // CaseSensitive search; It would be more efficient then making column case sensitive
                .ContinueWith(t => t.Result.FirstOrDefault(x => x.SourceUrl == message.SourceUrl))
                .ConfigureAwait(false);

            if (existing != null)
            {
                return _mapper.Map<Response>(existing);
            }

            var shortLink = new ShortLink(message.SourceUrl);
            _db.ShortLinks.Add(shortLink);

            await _db.SaveChangesAsync().ConfigureAwait(false);

            return _mapper.Map<Response>(shortLink);
        }
    }
}