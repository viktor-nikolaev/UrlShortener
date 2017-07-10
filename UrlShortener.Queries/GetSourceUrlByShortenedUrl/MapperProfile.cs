using AutoMapper;
using UrlShortener.Domain;

namespace UrlShortener.Queries.GetSourceUrlByShortenedUrl
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ShortLink, Result>();
        }
    }
}