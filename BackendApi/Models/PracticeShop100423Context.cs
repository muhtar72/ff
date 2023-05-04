using System;
using System.Collections.Generic;
using BackendApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Online_shop_database.Models
{

    public partial class PracticeShop100423Context : DbContext
    {
        public PracticeShop100423Context()
        {
        }

        public PracticeShop100423Context(DbContextOptions<PracticeShop100423Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Filter> Filters { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.CartId).HasName("PK__cart__2EF52A27EAD031D5");

                entity.ToTable("cart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");
                entity.Property(e => e.ItemId).HasColumnName("item_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Item).WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart__item_id__3A81B327");

                entity.HasOne(d => d.User).WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart__user_id__398D8EEE");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B4021C7AF0");

                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.HasKey(e => e.FilterId).HasName("PK__filters__833C443FF64657B9");

                entity.ToTable("filters");

                entity.Property(e => e.FilterId).HasColumnName("filter_id");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.FilterName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("filter_name");

                entity.HasOne(d => d.Category).WithMany(p => p.Filters)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__filters__categor__36B12243");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemId).HasName("PK__item__52020FDDD7824592");

                entity.ToTable("item");

                entity.Property(e => e.ItemId).HasColumnName("item_id");
                entity.Property(e => e.ItemCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("item_category");
                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("item_description");
                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("item_name");
                entity.Property(e => e.ItemPrice).HasColumnName("item_price");
                entity.Property(e => e.ItemQuantity).HasColumnName("item_quantity");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("PK__orders__46596229A7E4E907");

                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.DeliveryMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("delivery_method");
                entity.Property(e => e.ItemId).HasColumnName("item_id");
                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("order_status");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Item).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__item_id__3E52440B");

                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__user_id__3D5E1FD2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FC9EEAEA7");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");
                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
