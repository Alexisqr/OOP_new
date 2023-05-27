﻿// <auto-generated />
using System;
using BookS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookS.Data.Migrations
{
    [DbContext(typeof(BookShopContext))]
    [Migration("20230521181219_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookS.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            FirstName = "Nayden",
                            LastName = "Vitanov"
                        },
                        new
                        {
                            AuthorId = 2,
                            FirstName = "Deyan",
                            LastName = "Tanev"
                        },
                        new
                        {
                            AuthorId = 3,
                            FirstName = "Desislav",
                            LastName = "Petkov"
                        },
                        new
                        {
                            AuthorId = 4,
                            FirstName = "Dyakon",
                            LastName = "Hristov"
                        },
                        new
                        {
                            AuthorId = 5,
                            FirstName = "Milen",
                            LastName = "Todorov"
                        },
                        new
                        {
                            AuthorId = 6,
                            FirstName = "Aleksander",
                            LastName = "Kishishev"
                        },
                        new
                        {
                            AuthorId = 7,
                            FirstName = "Ilian",
                            LastName = "Stoev"
                        });
                });

            modelBuilder.Entity("BookS.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Copies")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<int>("EditionType")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AgeRestriction = 2,
                            AuthorId = 1,
                            Copies = 27274,
                            Description = "lALA",
                            EditionType = 0,
                            Price = 15.31m,
                            ReleaseDate = new DateTime(2018, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Absalom"
                        },
                        new
                        {
                            BookId = 2,
                            AgeRestriction = 0,
                            AuthorId = 2,
                            Copies = 16159,
                            Description = "lALA",
                            EditionType = 0,
                            Price = 35.56m,
                            ReleaseDate = new DateTime(1998, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "After Many a Summer Dies the Swan"
                        },
                        new
                        {
                            BookId = 3,
                            AgeRestriction = 0,
                            AuthorId = 3,
                            Copies = 29025,
                            Description = "lALA",
                            EditionType = 1,
                            Price = 23.71m,
                            ReleaseDate = new DateTime(1999, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Ah"
                        },
                        new
                        {
                            BookId = 4,
                            AgeRestriction = 2,
                            AuthorId = 4,
                            Copies = 9998,
                            Description = "lALA",
                            EditionType = 2,
                            Price = 5.26m,
                            ReleaseDate = new DateTime(1993, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Wilderness"
                        },
                        new
                        {
                            BookId = 5,
                            AgeRestriction = 2,
                            AuthorId = 5,
                            Copies = 18832,
                            Description = "lALA",
                            EditionType = 2,
                            Price = 5.69m,
                            ReleaseDate = new DateTime(2014, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Alien CornÂ (play)"
                        },
                        new
                        {
                            BookId = 6,
                            AgeRestriction = 2,
                            AuthorId = 6,
                            Copies = 28741,
                            Description = "lALA",
                            EditionType = 0,
                            Price = 34.56m,
                            ReleaseDate = new DateTime(2003, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Alien CornÂ (short story)"
                        },
                        new
                        {
                            BookId = 7,
                            AgeRestriction = 1,
                            AuthorId = 7,
                            Copies = 20471,
                            Description = "lALA",
                            EditionType = 1,
                            Price = 7.18m,
                            ReleaseDate = new DateTime(1991, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "All Passion Spent"
                        });
                });

            modelBuilder.Entity("BookS.Models.BookCategory", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BookCategory");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            CategoryId = 7
                        },
                        new
                        {
                            BookId = 2,
                            CategoryId = 6
                        },
                        new
                        {
                            BookId = 3,
                            CategoryId = 5
                        },
                        new
                        {
                            BookId = 4,
                            CategoryId = 4
                        },
                        new
                        {
                            BookId = 5,
                            CategoryId = 3
                        },
                        new
                        {
                            BookId = 6,
                            CategoryId = 2
                        },
                        new
                        {
                            BookId = 7,
                            CategoryId = 1
                        });
                });

            modelBuilder.Entity("BookS.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Drama"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Action"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Adventure"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Romance"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Mystery"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("BookS.Models.Book", b =>
                {
                    b.HasOne("BookS.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookS.Models.BookCategory", b =>
                {
                    b.HasOne("BookS.Models.Book", "Book")
                        .WithMany("BookCategories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookS.Models.Category", "Category")
                        .WithMany("CategoryBooks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
