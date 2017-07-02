using System;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain;

namespace UrlShortener.Dal
{
    public partial class UrlShortenerDb : DbContext
    {
        public UrlShortenerDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ShortLink> ShortLinks { get; set; }
    }
}