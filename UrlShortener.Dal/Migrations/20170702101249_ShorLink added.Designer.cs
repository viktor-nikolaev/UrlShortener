using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UrlShortener.Dal;

namespace UrlShortener.Dal.Migrations
{
    [DbContext(typeof(UrlShortenerDb))]
    [Migration("20170702101249_ShorLink added")]
    partial class ShorLinkadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UrlShortener.Domain.ShortLink", b =>
                {
                    b.Property<string>("SourceUrl")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastDateUsed");

                    b.Property<string>("ShortenedUrl");

                    b.HasKey("SourceUrl");

                    b.ToTable("ShortLinks");
                });
        }
    }
}
