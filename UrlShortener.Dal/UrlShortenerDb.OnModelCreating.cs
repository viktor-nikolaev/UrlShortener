using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain;

namespace UrlShortener.Dal
{
    public partial class UrlShortenerDb
    {
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ShortLink>()
                .HasKey(sl => sl.SourceUrl);
        }
    }
}