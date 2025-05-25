using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegistration.Server.Domain.Models;

public class Course
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public int Credits { get; set; } = 3;     
    
    public Guid TeacherId { get; set; }
    
    [ForeignKey(nameof(TeacherId))]
    public Teacher Teacher { get; set; } = null!;

    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
} 