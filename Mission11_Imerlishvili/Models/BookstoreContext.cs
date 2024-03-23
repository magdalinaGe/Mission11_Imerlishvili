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
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.BookId, "IX_Books_BookID")
                    .IsUnique();

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
