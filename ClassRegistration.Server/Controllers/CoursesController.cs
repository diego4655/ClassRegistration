using ClassRegistration.Server.Application.Courses.Queries.GetAllCourses;
using ClassRegistration.Server.Domain.Models;
using ClassRegistration.Server.Features.Courses.Commands.CreateCourse;
using ClassRegistration.Server.Features.Courses.Queries.GetAllCourses;
using ClassRegistration.Server.Features.Courses.Queries.GetCourse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegistration.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

  

 
    [HttpGet]
    [Route("Courses")]
    public async Task<ActionResult<List<Course>>> GetAllCourses()
    {
        GetAllCourseQuery query = new GetAllCourseQuery();
        var result = await _mediator.Send(query);
        if(result.Count() == 0)
        {
            return NoContent();
        }

        return Ok(result);
    } 

} 