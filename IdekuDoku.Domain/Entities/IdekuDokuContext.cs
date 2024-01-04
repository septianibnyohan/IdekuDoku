using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IdekuDoku.Domain.Entities;

public partial class IdekuDokuContext : DbContext
{
    public IdekuDokuContext()
    {
    }

    public IdekuDokuContext(DbContextOptions<IdekuDokuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<SetupConfigurationCc> SetupConfigurationCcs { get; set; }

    public virtual DbSet<SetupConfigurationVa> SetupConfigurationVas { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transaction1> Transactions1 { get; set; }

    public virtual DbSet<TransactionCc?> TransactionCcs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=ideku_doku;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.FeeId).HasName("PRIMARY");

            entity.HasIndex(e => e.PaymentMethodId, "PaymentMethodID");

            entity.Property(e => e.FeeId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("FeeID");
            entity.Property(e => e.FeeFixed).HasPrecision(15, 2);
            entity.Property(e => e.FeePercentage).HasPrecision(5, 2);
            entity.Property(e => e.MaxAmount).HasPrecision(15, 2);
            entity.Property(e => e.MinAmount).HasPrecision(15, 2);
            entity.Property(e => e.PaymentMethodId)
                .HasColumnType("int(11)")
                .HasColumnName("PaymentMethodID");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Fees)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("Fees_ibfk_1");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.MethodId).HasName("PRIMARY");

            entity.Property(e => e.MethodId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("MethodID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.MethodName).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<SetupConfigurationCc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("SetupConfigurationCc");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClientId).HasMaxLength(30);
            entity.Property(e => e.Environment).HasMaxLength(30);
            entity.Property(e => e.MerchantName).HasMaxLength(30);
            entity.Property(e => e.SharedKey).HasMaxLength(30);
        });

        modelBuilder.Entity<SetupConfigurationVa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("SetupConfigurationVa");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClientId).HasMaxLength(30);
            entity.Property(e => e.Environment).HasMaxLength(30);
            entity.Property(e => e.MerchantName).HasMaxLength(30);
            entity.Property(e => e.SharedKey).HasMaxLength(30);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Transaction");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ExpiredDate).HasMaxLength(50);
            entity.Property(e => e.HowToPayApi).HasMaxLength(50);
            entity.Property(e => e.HowToPayPage).HasMaxLength(50);
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.VirtualAccountNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Transaction1>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("Transactions");

            entity.HasIndex(e => e.PaymentMethodId, "PaymentMethodID");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("TransactionID");
            entity.Property(e => e.Amount).HasPrecision(15, 2);
            entity.Property(e => e.PaymentMethodId)
                .HasColumnType("int(11)")
                .HasColumnName("PaymentMethodID");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Transaction1s)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("Transactions_ibfk_1");
        });

        modelBuilder.Entity<TransactionCc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TransactionCc");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Amount).HasPrecision(15, 2);
            entity.Property(e => e.InvoiceNumber).HasMaxLength(30);
            entity.Property(e => e.Status).HasMaxLength(30);
            entity.Property(e => e.UrlPaymentPage).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
