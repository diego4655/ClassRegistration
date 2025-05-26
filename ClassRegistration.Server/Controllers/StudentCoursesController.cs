using ClassRegistration.Server.Application.Courses.Commands.DeleteStudentCourse;
using ClassRegistration.Server.Application.Courses.Commands.EnrollStudentInCourse;
using ClassRegistration.Server.Application.Courses.Queries.GetAllCourses;
using ClassRegistration.Server.Application.Courses.Queries.GetAllCoursesByStudent;
using ClassRegistration.Server.Application.Courses.Queries.GetAllStudentByCourse;
using ClassRegistration.Server.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegistration.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentCoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentCoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("AllCourseByStudent")]
    public async Task<IActionResult> GetAllCoursesByStudent([FromQuery] Guid studentId)
    {
        GetAllCourseByStudentQuery studentByCourses = new GetAllCourseByStudentQuery() {Student = new StudentDto() { Id = studentId} };
        var result = await _mediator.Send(studentByCourses);
        
        return Ok(result);
    }

    [HttpGet]
    [Route("AllStudentparners")]
    public async Task<IActionResult> GetAllStudentByCourse([FromQuery]Guid studentId)
    {
        GetAllStudentByCourseQuery query = new GetAllStudentByCourseQuery() { StudentId = studentId };
        var result = await _mediator.Send(query);
        return Ok(result);
    }



    [HttpPost]    
    public async Task<ActionResult<Course>> EnrollStudentInCourse([FromBody] EnrollStudentInCourseCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            if(result == null)
            {
                return NoContent();
            }
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteStudentCourse([FromQuery]Guid courseId, [FromQuery]Guid studentId)
    {
        try
        {
            var command = new DeleteStudentCourseCommand
            {
                CourseId = courseId,
                StudentId = studentId
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
} 