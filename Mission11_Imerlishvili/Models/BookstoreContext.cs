using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mission11_Imerlishvili.Models
{
    public partial class BookstoreContext : DbContext
    {
   

        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         // Configure the entity model for the Book entity
            modelBuilder.Entity<Book>(entity =>
            {
               // Create a unique index on the BookId property
     
                entity.HasIndex(e => e.BookId, "IX_Books_BookID")
                    .IsUnique();
        // Configure the BookId property to be mapped to the "BookID" column in the database

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
