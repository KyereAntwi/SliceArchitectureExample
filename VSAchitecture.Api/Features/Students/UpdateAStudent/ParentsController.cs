using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAchitecture.Api.Features.Students.UpdateAStudent;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromBody] UpdateAStudentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}