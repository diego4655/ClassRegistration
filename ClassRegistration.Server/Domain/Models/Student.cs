using System.ComponentModel.DataAnnotations;

namespace ClassRegistration.Server.Domain.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]    
    [Range(0, 10)]
    public int Credits {  get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}