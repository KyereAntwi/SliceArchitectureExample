using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAchitecture.Api.Features.Students.AddAStudent;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Add([FromBody] AddAStudentCommand command)
    {
        var studentId = await _mediator.Send(command);
        return AcceptedAtAction("/api/parents", new { Id = studentId}, studentId);
    }
}