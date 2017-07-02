using System;

namespace UrlShortener.Domain
{
    public class ShortLink
    {
        public ShortLink(string sourceUrl, string shortenedUrl)
        {
            SourceUrl = sourceUrl;
            ShortenedUrl = shortenedUrl;
        }

        public string SourceUrl { get; private set; }
        public string ShortenedUrl { get; private set; }
        public DateTime LastDateUsed { get; set; }
    }
}