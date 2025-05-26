using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegistration.Server.Domain.Models;

public class StudentCourse
{
    [Key]
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }

    [ForeignKey(nameof(StudentId))]
    public Student Student { get; set; } = null!;

    [ForeignKey(nameof(CourseId))]
    public Course Course { get; set; } = null!;    
} 