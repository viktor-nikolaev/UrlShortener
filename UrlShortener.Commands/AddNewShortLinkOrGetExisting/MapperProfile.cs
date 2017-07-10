using AutoMapper;
using UrlShortener.Domain;

namespace UrlShortener.Commands.AddNewShortLinkOrGetExisting
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ShortLink, Response>()
                .ForMember(d => d.ShortenedUrl, o => o.ResolveUsing<ShortenedUrlValueResolver>());
        }
    }
}