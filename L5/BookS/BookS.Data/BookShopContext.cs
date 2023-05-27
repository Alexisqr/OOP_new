using Microsoft.EntityFrameworkCore;
using System;
using BookS.Models;
using System.Linq;
using BookS.Data.EntityConfiguration;
namespace BookS.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
            Seeder(modelBuilder);
        }
        public static void Seeder(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "Science Fiction" },
                     new Category { CategoryId = 2, Name = "Drama" },
                      new Category { CategoryId = 3, Name = "Action" },
                       new Category { CategoryId = 4, Name = "Adventure" },
                        new Category { CategoryId = 5, Name = "Romance" },
                         new Category { CategoryId = 6, Name = "Mystery" },
                          new Category { CategoryId = 7, Name = "Horror" }

                );

            modelBuilder.Entity<Author>().HasData(
                 new Author { AuthorId = 1, FirstName = "Nayden", LastName = "Vitanov" },
                  new Author { AuthorId = 2, FirstName = "Deyan", LastName = "Tanev" },
                   new Author { AuthorId = 3, FirstName = "Desislav", LastName = "Petkov" },
                    new Author { AuthorId = 4, FirstName = "Dyakon", LastName = "Hristov" },
                     new Author { AuthorId = 5, FirstName = "Milen", LastName = "Todorov" },
                      new Author { AuthorId = 6, FirstName = "Aleksander", LastName = "Kishishev" },
                     new Author { AuthorId = 7, FirstName = "Ilian", LastName = "Stoev" }

             );


            modelBuilder.Entity<Book>().HasData(
            new Book
            {
                BookId = 1,
                Title = "Absalom",
                Description = "lALA",
                EditionType = EditionType.Normal,
                Price = 15.31M,
                Copies = 27274,
                ReleaseDate = DateTime.ParseExact("12-06-2018", "dd-MM-yyyy", null),
                AgeRestriction = AgeRestriction.Adult,
                AuthorId = 1
            },
             //Edition ReleaseDate Copies Price AgeRestriction Title
             //  "1 20/01/1998 27274 15.31 2 Absalom",
             //   "0 14/09/1998 16159 35.56 0 After Many a Summer Dies the Swan",
             //   "0 13/03/1999 29025 23.71 0 Ah",
             //   "2 12/3/1993 9998 5.26 2 Wilderness!",
             //   "2 22/10/2014 18832 5.69 2 Alien CornÂ (play)",
             //   "0 18/02/2003 28741 34.56 2 The Alien CornÂ (short story)",
             //   "1 11/10/1991 20471 7.18 1 All Passion Spent",
             new Book
             {
                 BookId = 2,
                 Title = "After Many a Summer Dies the Swan",
                 Description = "lALA",
                 EditionType = EditionType.Normal,
                 Price = 35.56M,
                 Copies = 16159,
                 ReleaseDate = DateTime.ParseExact("14-09-1998", "dd-MM-yyyy", null),
                 AgeRestriction = AgeRestriction.Minor,
                 AuthorId = 2
             },
              new Book
              {
                  BookId = 3,
                  Title = "Ah",
                  Description = "lALA",
                  EditionType = EditionType.Promo,
                  Price = 23.71M,
                  Copies = 29025,
                  ReleaseDate = DateTime.ParseExact("13-03-1999", "dd-MM-yyyy", null),
                  AgeRestriction = AgeRestriction.Minor,
                  AuthorId = 3
              },
               new Book
               {
                   BookId = 4,
                   Title = "Wilderness",
                   Description = "lALA",
                   EditionType = EditionType.Gold,
                   Price = 5.26M,
                   Copies = 9998,
                   ReleaseDate = DateTime.ParseExact("12-03-1993", "dd-MM-yyyy", null),
                   AgeRestriction = AgeRestriction.Adult,
                   AuthorId = 4
               },
                new Book
                {
                    BookId = 5,
                    Title = "Alien CornÂ (play)",
                    Description = "lALA",
                    EditionType = EditionType.Gold,
                    Price = 5.69M,
                    Copies = 18832,
                    ReleaseDate = DateTime.ParseExact("22-10-2014", "dd-MM-yyyy", null),
                    AgeRestriction = AgeRestriction.Adult,
                    AuthorId = 5
                },
                 new Book
                 {
                     BookId = 6,
                     Title = "The Alien CornÂ (short story)",
                     Description = "lALA",
                     EditionType = EditionType.Normal,
                     Price = 34.56M,
                     Copies = 28741,
                     ReleaseDate = DateTime.ParseExact("18-02-2003", "dd-MM-yyyy", null),
                     AgeRestriction = AgeRestriction.Adult,
                     AuthorId = 6
                 },
                  new Book
                  {
                      BookId = 7,
                      Title = "All Passion Spent",
                      Description = "lALA",
                      EditionType = EditionType.Promo,
                      Price = 7.18M,
                      Copies = 20471,
                      ReleaseDate = DateTime.ParseExact("11-10-1991", "dd-MM-yyyy", null),
                      AgeRestriction = AgeRestriction.Teen,
                      AuthorId = 7
                  }


        );
            modelBuilder.Entity<BookCategory>().HasData(
          new BookCategory { BookId = 1, CategoryId = 7 },
          new BookCategory { BookId = 2, CategoryId = 6 },
          new BookCategory { BookId = 3, CategoryId = 5 },
          new BookCategory { BookId = 4, CategoryId = 4 },
          new BookCategory { BookId = 5, CategoryId = 3 },
          new BookCategory { BookId = 6, CategoryId = 2 },
          new BookCategory { BookId = 7, CategoryId = 1 }


      );

        }

    }
}