using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassRegistration.Server.Domain.Models;

public class Teacher
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [Phone]
    [StringLength(20)]
    public string Phone { get; set; } = string.Empty;
    
    private readonly List<Course> _courses = new();
    
    [BackingField(nameof(_courses))]
    public IReadOnlyCollection<Course> Courses => _courses.AsReadOnly();

    public bool CanAddCourse()
    {
        return _courses.Count < 2;
    }

    public void AddCourse(Course course)
    {
        if (!CanAddCourse())
        {
            throw new InvalidOperationException("A teacher cannot have more than 2 courses.");
        }
        _courses.Add(course);
    }

    public void RemoveCourse(Course course)
    {
        _courses.Remove(course);
    }
} 