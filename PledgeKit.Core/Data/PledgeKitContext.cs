using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using PledgeKit.Data;

namespace PledgeKit.Core.Data
{
    public partial class PledgeKitContext : DbContext
    {
        public PledgeKitContext()
        {
        }

        public PledgeKitContext(DbContextOptions<PledgeKitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendee> Attendees { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventAttendee> EventAttendees { get; set; }
        public virtual DbSet<EventProject> EventProjects { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Pledge> Pledges { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>(entity =>
            {
                entity.HasKey(e => e.AttendeeId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ClusterKey)
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Attendee_Email_Unique")
                    .IsUnique();

                entity.Property(e => e.AttendeeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClusterKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
               
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ClusterKey)
                    .ForSqlServerIsClustered();

                entity.Property(e => e.EventId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClusterKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventAttendee>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.AttendeeId })
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ClusterKey)
                    .ForSqlServerIsClustered();

                entity.Property(e => e.ClusterKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Attendee)
                    .WithMany(p => p.EventAttendees)
                    .HasForeignKey(d => d.AttendeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EventAttendees_dbo.Attendees_AttendeeId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventAttendees)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EventAttendees_dbo.Events_EventId");
            });

            modelBuilder.Entity<EventProject>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.ProjectId })
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ClusterKey)
                    .ForSqlServerIsClustered();

                entity.Property(e => e.ClusterKey).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventProjects)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EventProjects_dbo.Events_EventId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EventProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EventProjects_dbo.Projects_ProjectId");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ClusterKey)
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => e.PaymentMethodId)
                    .HasName("IX_PaymentMethodId");

                entity.Property(e => e.PaymentId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClusterKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Attendee)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.AttendeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Payments_dbo.Attendees_AttendeeId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Payments_dbo.Events_EventId");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Payments_dbo.PaymentMethods_PaymentMethodId");
            });

            modelBuilder.Entity<Pledge>(entity =>
            {
                entity.HasKey(e => e.PledgeId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ClusterKey)
                    .ForSqlServerIsClustered();

                entity.Property(e => e.PledgeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClusterKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Attendee)
                    .WithMany(p => p.Pledges)
                    .HasForeignKey(d => d.AttendeeId)
                    .HasConstraintName("FK_dbo.Pledges_dbo.Attendees_AttendeeId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Pledges)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_dbo.Pledges_dbo.Events_EventId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Pledges)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_dbo.Pledges_dbo.Projects_ProjectId");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ClusterKey)
                    .ForSqlServerIsClustered();

                entity.Property(e => e.ProjectId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClusterKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
