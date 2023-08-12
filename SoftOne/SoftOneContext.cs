using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SoftOne.Models;

namespace SoftOne;

public partial class SoftOneContext : DbContext
{
    public SoftOneContext()
    {
    }

    public SoftOneContext(DbContextOptions<SoftOneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleXStudent> RoleXStudents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\SoftOne;Initial Catalog=SoftOne");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName)
                .HasMaxLength(15)
                .IsFixedLength();
        });

        modelBuilder.Entity<RoleXStudent>(entity =>
        {
            entity.ToTable("Role_x_Students");

            entity.Property(e => e.Address1).HasMaxLength(50);
            entity.Property(e => e.City)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Street).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.RoleXStudents)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_x_StudentXRole");

            entity.HasOne(d => d.Student).WithMany(p => p.RoleXStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_x_StudentXStudent");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_Employee");

            entity.ToTable("Student");

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ContactNo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ContactPersonName).HasMaxLength(50);
            entity.Property(e => e.ContactPersonNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PrimaryAdressLine).HasMaxLength(50);
            entity.Property(e => e.Ssn).HasColumnName("SSN");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
