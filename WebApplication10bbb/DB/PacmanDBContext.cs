using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication10bbb.DB
{
    public partial class PacmanDBContext : DbContext
    {
        public PacmanDBContext()
        {
        }

        public PacmanDBContext(DbContextOptions<PacmanDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Scores> Scores { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:pacmansadoviyserver.database.windows.net,1433;Initial Catalog=PacmanDB;Persist Security Info=False;User ID=frost7412359;Password=Ff7412359;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scores>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .ValueGeneratedNever();

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(30);
            });
        }
    }
}
