using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Dal
{
    public partial class UrlShortenerDb
    {
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //mb.Entity<ShortLink>()
            //    .Property(x => x.SourceUrl)
            //    .HasAnnotation("CaseSensitive", true);
        }
    }
}