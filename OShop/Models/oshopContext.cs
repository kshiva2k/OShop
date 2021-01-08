using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OShop.Models
{
    public partial class oshopContext : DbContext
    {
        public oshopContext()
        {
        }

        public oshopContext(DbContextOptions<oshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GAgencymaster> GAgencymaster { get; set; }
        public virtual DbSet<GAgencysubscription> GAgencysubscription { get; set; }
        public virtual DbSet<GDelivery> GDelivery { get; set; }
        public virtual DbSet<GRolemaster> GRolemaster { get; set; }
        public virtual DbSet<GShopcategorymaster> GShopcategorymaster { get; set; }
        public virtual DbSet<GShopmaster> GShopmaster { get; set; }
        public virtual DbSet<GUsermaster> GUsermaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=Mysql@2020;database=oshop");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GAgencymaster>(entity =>
            {
                entity.ToTable("g_agencymaster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phoneno)
                    .HasColumnName("phoneno")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GAgencysubscription>(entity =>
            {
                entity.ToTable("g_agencysubscription");

                entity.HasIndex(e => e.Agencyid)
                    .HasName("as_am_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Agencyid).HasColumnName("agencyid");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Fromdate).HasColumnName("fromdate");

                entity.Property(e => e.Isexpired)
                    .HasColumnName("isexpired")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Paymenttype).HasColumnName("paymenttype");

                entity.Property(e => e.Todate).HasColumnName("todate");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.GAgencysubscription)
                    .HasForeignKey(d => d.Agencyid)
                    .HasConstraintName("as_am");
            });

            modelBuilder.Entity<GDelivery>(entity =>
            {
                entity.ToTable("g_delivery");

                entity.HasIndex(e => e.Agencyid)
                    .HasName("d_ag_idx");

                entity.HasIndex(e => e.Shopid)
                    .HasName("d_sh_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Actualpayment)
                    .HasColumnName("actualpayment")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Agencyid).HasColumnName("agencyid");

                entity.Property(e => e.Billclearancedate).HasColumnName("billclearancedate");

                entity.Property(e => e.Billcleared)
                    .HasColumnName("billcleared")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Createddate).HasColumnName("createddate");

                entity.Property(e => e.Deliveredby).HasColumnName("deliveredby");

                entity.Property(e => e.Invoiceamount)
                    .HasColumnName("invoiceamount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Paymentmode)
                    .HasColumnName("paymentmode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Paymentno)
                    .HasColumnName("paymentno")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Shopid).HasColumnName("shopid");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.GDelivery)
                    .HasForeignKey(d => d.Agencyid)
                    .HasConstraintName("d_ag");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.GDelivery)
                    .HasForeignKey(d => d.Shopid)
                    .HasConstraintName("d_sh");
            });

            modelBuilder.Entity<GRolemaster>(entity =>
            {
                entity.ToTable("g_rolemaster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GShopcategorymaster>(entity =>
            {
                entity.ToTable("g_shopcategorymaster");

                entity.HasIndex(e => e.Agencyid)
                    .HasName("sc_ag_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Agencyid).HasColumnName("agencyid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.GShopcategorymaster)
                    .HasForeignKey(d => d.Agencyid)
                    .HasConstraintName("sc_ag");
            });

            modelBuilder.Entity<GShopmaster>(entity =>
            {
                entity.ToTable("g_shopmaster");

                entity.HasIndex(e => e.Agencyid)
                    .HasName("s_ag_idx");

                entity.HasIndex(e => e.Shopcategoryid)
                    .HasName("s_sc_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Agencyid).HasColumnName("agencyid");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Overallbalance)
                    .HasColumnName("overallbalance")
                    .HasColumnType("decimal(8,2)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Shopcategoryid).HasColumnName("shopcategoryid");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.GShopmaster)
                    .HasForeignKey(d => d.Agencyid)
                    .HasConstraintName("s_ag");

                entity.HasOne(d => d.Shopcategory)
                    .WithMany(p => p.GShopmaster)
                    .HasForeignKey(d => d.Shopcategoryid)
                    .HasConstraintName("s_sc");
            });

            modelBuilder.Entity<GUsermaster>(entity =>
            {
                entity.ToTable("g_usermaster");

                entity.HasIndex(e => e.Agencyid)
                    .HasName("u_ag_idx");

                entity.HasIndex(e => e.Roleid)
                    .HasName("u_role_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Agencyid).HasColumnName("agencyid");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Loginname)
                    .IsRequired()
                    .HasColumnName("loginname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobileno)
                    .HasColumnName("mobileno")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.GUsermaster)
                    .HasForeignKey(d => d.Agencyid)
                    .HasConstraintName("u_ag");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.GUsermaster)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("u_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
