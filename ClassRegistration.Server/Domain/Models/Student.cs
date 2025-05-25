using System.ComponentModel.DataAnnotations;

namespace ClassRegistration.Server.Domain.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    public int GetTotalCredits()
    {
        return StudentCourses.Sum(sc => sc.Course.Credits);
    }

    public bool CanEnrollInCourse(Course course)
    {
        if (GetTotalCredits() >= 10)
            return false;

        if (StudentCourses.Any(sc => sc.Course.TeacherId == course.TeacherId))
            return false;

        return true;
    }
}