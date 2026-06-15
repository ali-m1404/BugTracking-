using BugTracker.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<RoleEntity> Roles { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<ProjectEntity> Projects { get; set; }

    public DbSet<ProjectMemberEntity> ProjectMembers { get; set; }

    public DbSet<BugEntity> Bugs { get; set; }

    public DbSet<CommentEntity> Comments { get; set; }

    public DbSet<AttachmentEntity> Attachments { get; set; }

    public DbSet<BugHistoryEntity> BugHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Composite Key
        modelBuilder.Entity<ProjectMemberEntity>()
            .HasKey(pm => new { pm.ProjectId, pm.UserId });

        // Project Manager Relation
        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Manager)
            .WithMany(u => u.ManagedProjects)
            .HasForeignKey(p => p.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Bug Reporter Relation
        modelBuilder.Entity<BugEntity>()
            .HasOne(b => b.ReportedBy)
            .WithMany(u => u.ReportedBugs)
            .HasForeignKey(b => b.ReportedById)
            .OnDelete(DeleteBehavior.Restrict);

        // Bug Assigned Relation
        modelBuilder.Entity<BugEntity>()
            .HasOne(b => b.AssignedTo)
            .WithMany(u => u.AssignedBugs)
            .HasForeignKey(b => b.AssignedToId)
            .OnDelete(DeleteBehavior.Restrict);

        // Comment Relation
        modelBuilder.Entity<CommentEntity>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId);

        // Attachment Relation
        modelBuilder.Entity<AttachmentEntity>()
            .HasOne(a => a.UploadedBy)
            .WithMany(u => u.Attachments)
            .HasForeignKey(a => a.UploadedById)
            .OnDelete(DeleteBehavior.Restrict);

        // Bug History Relation
        modelBuilder.Entity<BugHistoryEntity>()
            .HasOne(h => h.ChangedBy)
            .WithMany(u => u.BugHistories)
            .HasForeignKey(h => h.ChangedById)
            .OnDelete(DeleteBehavior.Restrict);



        // ==========================
        // Seed Roles
        // ==========================

        var seedDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<RoleEntity>().HasData(

            new RoleEntity
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Admin",
                Description = "System Administrator",
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            },

            new RoleEntity
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "ProjectManager",
                Description = "Project Manager",
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            },

            new RoleEntity
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Developer",
                Description = "Software Developer",
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            },

            new RoleEntity
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Name = "Tester",
                Description = "Quality Assurance Tester",
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            }
        );
    }
}