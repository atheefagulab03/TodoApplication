using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task1.Models;

public partial class TodoContext : DbContext
{
    public TodoContext()
    {
    }

    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todos> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("data source=KANINI-LTP-370\\SQLEXPRESS;initial catalog=Todo;integrated security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Todo__3214EC07B38A6C9D");

            entity.ToTable("Todo");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Due)
                .HasColumnType("datetime")
                .HasColumnName("due");
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.PriorityFlag)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("Low")
                .HasColumnName("priorityFlag");
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("taskName");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NotCompleted")
                .HasColumnName("taskStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
