using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HomeFood.Models
{
    public partial class BDHomeFoodContext : DbContext
    {
        public BDHomeFoodContext()
        {
        }

        public BDHomeFoodContext(DbContextOptions<BDHomeFoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<CodePromotion> CodePromotion { get; set; }
        public virtual DbSet<Collaborator> Collaborator { get; set; }
        public virtual DbSet<CollaboratorType> CollaboratorType { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerCodePromotion> CustomerCodePromotion { get; set; }
        public virtual DbSet<LivingPlaceType> LivingPlaceType { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<ShopCar> ShopCar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=database-1.cqafasqmheaz.us-east-2.rds.amazonaws.com;Database=BDHomeFood;User=admin;Password=Xycybib7;ConnectRetryCount=0;MultipleActiveResultSets=true;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentNum)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.Nameaddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Customer");

                entity.HasOne(d => d.LivingPlaceType)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.LivingPlaceTypeId)
                    .HasConstraintName("FK_Address_LivingPlaceType");
            });

            modelBuilder.Entity<CodePromotion>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Collaborator>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentIdentity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastNames)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.Names)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.StateActivity)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UrlPhoto)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CollaboratorType)
                    .WithMany(p => p.Collaborator)
                    .HasForeignKey(d => d.CollaboratorTypeId)
                    .HasConstraintName("FK_Collaborator_CollaboratorType");
            });

            modelBuilder.Entity<CollaboratorType>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentoIdentity)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastNames)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pasword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerCodePromotion>(entity =>
            {
                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UseDate).HasColumnType("datetime");

                entity.HasOne(d => d.CodePromotion)
                    .WithMany(p => p.CustomerCodePromotion)
                    .HasForeignKey(d => d.CodePromotionId)
                    .HasConstraintName("FK_CustomerCodePromotion_CodePromotion");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCodePromotion)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerCodePromotion_Customer");
            });

            modelBuilder.Entity<LivingPlaceType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Collaborator)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.CollaboratorId)
                    .HasConstraintName("FK_Menu_Collaborator");

                entity.HasOne(d => d.MenuType)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.MenuTypeId)
                    .HasConstraintName("FK_Menu_MenuType");
            });

            modelBuilder.Entity<MenuType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalCostDriver).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalCostOrder).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CollaboratorDriver)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CollaboratorDriverId)
                    .HasConstraintName("FK_Order_Collaborator");

                entity.HasOne(d => d.CustomerCodePromotion)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerCodePromotionId)
                    .HasConstraintName("FK_Order_CustomerCodePromotion");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UrlPhoto)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Photo)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_Menu");
            });

            modelBuilder.Entity<ShopCar>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.State)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShopCar)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_ShopCar_Customer");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.ShopCar)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_ShopCar_Menu");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ShopCar)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_ShopCar_Order");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
