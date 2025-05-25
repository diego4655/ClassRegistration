using ClassRegistration.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.Server.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    public DbSet<Student> Students { get; set; } 
    public DbSet<Course> Courses { get; set; } 
    public DbSet<Teacher> Teachers { get; set; } 
    public DbSet<StudentCourse> StudentCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}