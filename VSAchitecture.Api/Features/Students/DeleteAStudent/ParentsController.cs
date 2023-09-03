using MediatR;
using Microsoft.AspNetCore.Mvc;
using VSAchitecture.Api.Features.Students.AddAStudent;

namespace VSAchitecture.Api.Features.Students.DeleteAStudent;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid Id)
    {
        await _mediator.Send(new DeleteAStudentCommand(Id));
        return NoContent();
    }
}