using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LinkPortalDeneme.Models
{
    public partial class LinkPortalTestContext : DbContext
    {
        public LinkPortalTestContext()
        {
        }

        public LinkPortalTestContext(DbContextOptions<LinkPortalTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LinkCategory> LinkCategories { get; set; } = null!;
        public virtual DbSet<LinkOrtamBeyza> LinkOrtamBeyzas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LinkCategory");

                entity.Property(e => e.Desc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<LinkOrtamBeyza>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LinkOrtamBeyza");

                entity.Property(e => e.Desc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
