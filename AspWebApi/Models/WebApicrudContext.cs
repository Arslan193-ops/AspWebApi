using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspWebApi.Models;

public partial class WebApicrudContext : DbContext
{
    public WebApicrudContext()
    {
    }

    public WebApicrudContext(DbContextOptions<WebApicrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentTbl> StudentTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentTbl>(entity =>
        {
            entity.ToTable("Student_tbl");

            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.StudentGender).HasMaxLength(50);
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
