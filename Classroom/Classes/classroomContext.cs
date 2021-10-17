using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Classroom
{
    public partial class classroomContext : DbContext
    {
        public classroomContext()
        {
        }

        public classroomContext(DbContextOptions<classroomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<Reaply> Reaplies { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QGEEUPD;Database=classroom;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("group");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IdOwner).HasColumnName("id_owner");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.IdOwner)
                    .HasConstraintName("FK_group_users");
            });

            modelBuilder.Entity<GroupUser>(entity =>
            {
                entity.ToTable("group_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdGroup).HasColumnName("id_group");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_group_user_group");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_group_user_users");
            });

            modelBuilder.Entity<Reaply>(entity =>
            {
                entity.ToTable("reaply");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasColumnName("file_name")
                    .IsFixedLength(true);

                entity.Property(e => e.IdTask).HasColumnName("id_task");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.HasOne(d => d.IdTaskNavigation)
                    .WithMany(p => p.Reaplies)
                    .HasForeignKey(d => d.IdTask)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_reaply_task");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Reaplies)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_reaply_users");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatePublished)
                    .HasColumnType("date")
                    .HasColumnName("datePublished");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.FileName)
                    .HasColumnType("text")
                    .HasColumnName("fileName");

                entity.Property(e => e.IdGroup).HasColumnName("id_group");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Type)
                    .HasMaxLength(15)
                    .HasColumnName("type")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdGroup)
                    .HasConstraintName("FK_task_group");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email")
                    .IsFixedLength(true);


                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .HasColumnName("password")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
