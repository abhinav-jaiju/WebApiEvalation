using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RentBook.Models
{
    public partial class Phase1EvaluationContext : DbContext
    {
        public Phase1EvaluationContext()
        {
        }

        public Phase1EvaluationContext(DbContextOptions<Phase1EvaluationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorTable> AuthorTable { get; set; }
        public virtual DbSet<BookTable> BookTable { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<RentTable> RentTable { get; set; }
/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ABHINAVJAIJU\\SQLEXPRESS; Initial Catalog= Phase1Evaluation; Integrated security=True");
            }
        }
*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorTable>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .HasName("PK__authorTa__8E2731B93526F1B8");

                entity.ToTable("authorTable");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("authorId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorName)
                    .HasColumnName("authorName")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookTable>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__bookTabl__8BE5A10DBEE6CB02");

                entity.ToTable("bookTable");

                entity.Property(e => e.BookId)
                    .HasColumnName("bookId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.BookName)
                    .HasColumnName("bookName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GenreId).HasColumnName("genreId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PublicationId).HasColumnName("publicationId");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookTable)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__bookTable__autho__2E1BDC42");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BookTable)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__bookTable__genre__2D27B809");

                entity.HasOne(d => d.Publication)
                    .WithMany(p => p.BookTable)
                    .HasForeignKey(d => d.PublicationId)
                    .HasConstraintName("FK__bookTable__publi__2C3393D0");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId)
                    .HasColumnName("genreId")
                    .ValueGeneratedNever();

                entity.Property(e => e.GenreName)
                    .HasColumnName("genreName")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.Property(e => e.MemberId)
                    .HasColumnName("memberId")
                    .ValueGeneratedNever();

                entity.Property(e => e.MemberName)
                    .HasColumnName("memberName")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("publication");

                entity.Property(e => e.PublicationId)
                    .HasColumnName("publicationId")
                    .ValueGeneratedNever();

                entity.Property(e => e.PublicationName)
                    .HasColumnName("publicationName")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RentTable>(entity =>
            {
                entity.HasKey(e => e.RentId)
                    .HasName("PK__rentTabl__354E5A8725439D76");

                entity.ToTable("rentTable");

                entity.Property(e => e.RentId)
                    .HasColumnName("rentId")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookId).HasColumnName("bookId");

                entity.Property(e => e.BookReturnDate).HasColumnType("date");

                entity.Property(e => e.BookTakenDate)
                    .HasColumnName("bookTakenDate")
                    .HasColumnType("date");

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.RentPrice).HasColumnName("rentPrice");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.RentTable)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__rentTable__bookI__30F848ED");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.RentTable)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__rentTable__membe__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
