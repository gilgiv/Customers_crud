using Customers_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers_crud.DAL;

public partial class StoreContext : DbContext
{
    public StoreContext()
    {
    }

    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //   // optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Store;Trusted_Connection=True;TrustServerCertificate=true;");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("Birth_date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Full_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tz).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
