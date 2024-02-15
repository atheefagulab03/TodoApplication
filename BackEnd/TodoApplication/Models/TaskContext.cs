using Microsoft.EntityFrameworkCore;

namespace TodoApplication.Models;

public partial class TaskContext(DbContextOptions<TaskContext> options, IConfiguration configuration) : DbContext(options)
{
    private readonly IConfiguration configuration = configuration;

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<TaskDetail> TaskDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionstring = configuration.GetConnectionString("DbConnection");
            optionsBuilder.UseSqlServer(connectionstring);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07744E0AEB");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Categories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Category__UserId__534D60F1");
        });

        modelBuilder.Entity<TaskDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskDeta__3214EC07BC6999A3");

            entity.Property(e => e.Due)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PriorityFlag)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.TaskDetails)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__TaskDetai__Categ__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.TaskDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TaskDetai__UserI__59FA5E80");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC072C05CB10");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534984E5291").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
