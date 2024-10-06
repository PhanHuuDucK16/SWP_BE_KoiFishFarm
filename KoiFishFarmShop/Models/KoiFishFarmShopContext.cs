using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiFishFarmShop.Models;

public partial class KoiFishFarmShopContext : DbContext
{
    public KoiFishFarmShopContext()
    {
    }

    public KoiFishFarmShopContext(DbContextOptions<KoiFishFarmShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DeliveryCompany> DeliveryCompanies { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<KoiFishCategory> KoiFishCategories { get; set; }

    public virtual DbSet<KoiFishGroup> KoiFishGroups { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-ENB2C1SC\\NHATHUYSQLSERVER;Initial Catalog=KoiFishFarmShop;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC078C94B790");

            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0720DE40EF");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(256);
            entity.Property(e => e.Username).HasMaxLength(256);
        });

        modelBuilder.Entity<DeliveryCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC0737ECB449");

            entity.ToTable("DeliveryCompany");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(256);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC07B971E663");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Feedback__Custom__3D5E1FD2");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Feedback__OrderI__3C69FB99");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KoiFish__3214EC076E784BAF");

            entity.ToTable("KoiFish");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Origin).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(256);
        });

        modelBuilder.Entity<KoiFishCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KoiFishC__3214EC07846966B3");

            entity.ToTable("KoiFishCategory");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Category).WithMany(p => p.KoiFishCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__KoiFishCa__Categ__286302EC");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.KoiFishCategories)
                .HasForeignKey(d => d.KoiFishId)
                .HasConstraintName("FK__KoiFishCa__KoiFi__29572725");
        });

        modelBuilder.Entity<KoiFishGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KoiFishG__3214EC07384CF7FD");

            entity.ToTable("KoiFishGroup");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(256);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Manager__3214EC0767C7F290");

            entity.ToTable("Manager");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.Username).HasMaxLength(256);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC07E2CD6B99");

            entity.ToTable("Order");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(256);
            entity.Property(e => e.Receiver).HasMaxLength(256);
            entity.Property(e => e.Status).HasMaxLength(256);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__33D4B598");

            entity.HasOne(d => d.DeliveryCompany).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryCompanyId)
                .HasConstraintName("FK__Order__DeliveryC__34C8D9D1");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07DA36E132");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DriverNumber).HasMaxLength(256);
            entity.Property(e => e.Plates).HasMaxLength(256);

            entity.HasOne(d => d.KoiFishGroup).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.KoiFishGroupId)
                .HasConstraintName("FK__OrderDeta__KoiFi__398D8EEE");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.KoiFishId)
                .HasConstraintName("FK__OrderDeta__KoiFi__38996AB5");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__37A5467C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
