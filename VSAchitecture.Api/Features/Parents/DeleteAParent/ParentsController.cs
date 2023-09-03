using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAchitecture.Api.Features.Parents.DeleteAParent;

[Route("api/parents")]
[ApiController]
public class ParentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid Id)
    {
        await _mediator.Send(new DeleteAParentCommand(Id));
        return NoContent();
    }
}