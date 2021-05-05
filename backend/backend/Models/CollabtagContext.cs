using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace backend.Models
{
    public partial class CollabtagContext : DbContext
    {
        public CollabtagContext()
        {
        }

        public CollabtagContext(DbContextOptions<CollabtagContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CUser> CUsers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Datum> Data { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=collabtag;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<CUser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("user_pk");

                entity.ToTable("c_user");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("class_pk");

                entity.ToTable("class");

                entity.Property(e => e.IdClass).HasColumnName("id_class");

                entity.Property(e => e.IdProject)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_project");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("class_fk1");
            });

            modelBuilder.Entity<Datum>(entity =>
            {
                entity.HasKey(e => e.IdData)
                    .HasName("data_pk");

                entity.ToTable("data");

                entity.Property(e => e.IdData).HasColumnName("id_data");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("date");

                entity.Property(e => e.IdClass)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_class");

                entity.Property(e => e.IdProject)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_project");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_user");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Data)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("data_fk2");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Data)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("data_fk3");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Data)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("data_fk1");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.IdModel)
                    .HasName("model_pk");

                entity.ToTable("model");

                entity.Property(e => e.IdModel).HasColumnName("id_model");

                entity.Property(e => e.Accuracy).HasColumnName("accuracy");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("date");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnName("file");

                entity.Property(e => e.IdProject)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_project");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("model_fk1");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.IdProject)
                    .HasName("project_pk");

                entity.ToTable("project");

                entity.Property(e => e.IdProject).HasColumnName("id_project");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_user");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_fk1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
