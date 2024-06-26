﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApp_hareem.Models;

namespace WebApp_hareem.Data
{
    public partial class dotnetContext : DbContext
    {
        public dotnetContext()
        {
        }

        public dotnetContext(DbContextOptions<dotnetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=dotnet;Integrated Security=True; Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite; MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("PK__Role__C4762327D2E1C35B");

                entity.ToTable("Role");

                entity.Property(e => e.RId).HasColumnName("r_id");

                entity.Property(e => e.RName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("r_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__Users__B51D3DEACB885E1C");

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.Property(e => e.RId).HasColumnName("r_id");

                entity.Property(e => e.UImg)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("u_img");

                entity.Property(e => e.UName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("u_name");

                entity.Property(e => e.UPass)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("u_pass");

                entity.HasOne(d => d.RIdNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__r_id__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
