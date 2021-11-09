using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI_Project.Model;

namespace BookAPI_Project.Services
{
    public class BookDbContext :DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {
            Database.Migrate();

        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Reviewer> Reviewer { get; set; }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<BookCategory> BookCategory { get; set; }
        public virtual DbSet<BookAuthor> BookAuthor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
                   .HasOne(b => b.Book)
                   .WithMany(bc => bc.BookCategorys)
                   .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookCategory>()
                  .HasOne(b => b.Category)
                  .WithMany(bc => bc.BookCatergorys)
                  .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<BookAuthor>()
               .HasKey(bc => new { bc.BookId, bc.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
