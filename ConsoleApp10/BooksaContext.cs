using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsoleApp10
{
    public partial class BooksaContext : DbContext
    {
        public BooksaContext()
        {
        }

        public BooksaContext(DbContextOptions<BooksaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerBook> CustomerBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Booksa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname).IsRequired();

                entity.Property(e => e.Lastname).IsRequired();

                entity.HasOne(d => d.Books)
                    .WithMany(p => p.Autors)
                    .HasForeignKey(d => d.BooksId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Autor__BooksId__29572725");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookN).IsRequired();

                entity.Property(e => e.DateBuy)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateReturn)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Firstname).IsRequired();

                entity.Property(e => e.Lastname).IsRequired();
            });

            modelBuilder.Entity<CustomerBook>(entity =>
            {
                entity.HasOne(d => d.Books)
                    .WithMany(p => p.CustomerBooks)
                    .HasForeignKey(d => d.BooksId)
                    .HasConstraintName("FK__CustomerB__Books__3B75D760");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerBooks)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerB__Custo__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
