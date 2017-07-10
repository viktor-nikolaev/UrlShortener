using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UrlShortener.Dal;

namespace UrlShortener.Dal.Migrations
{
    [DbContext(typeof(UrlShortenerDb))]
    [Migration("20170702175210_optimized structure")]
    partial class optimizedstructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UrlShortener.Domain.ShortLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SourceUrl");

                    b.HasKey("Id");

                    b.ToTable("ShortLinks");
                });
        }
    }
}
