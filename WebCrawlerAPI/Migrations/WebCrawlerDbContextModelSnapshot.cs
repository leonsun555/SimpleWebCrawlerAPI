﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCrawlerAPI.Model;

namespace WebCrawlerAPI.Migrations
{
    [DbContext(typeof(WebCrawlerDbContext))]
    partial class WebCrawlerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebCrawlerAPI.Model.NewsList", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("contextUrl");

                    b.Property<string>("date");

                    b.Property<string>("description");

                    b.Property<string>("imgUrl");

                    b.HasKey("id");

                    b.ToTable("NewsLists");
                });
#pragma warning restore 612, 618
        }
    }
}