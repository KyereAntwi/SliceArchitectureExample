using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VSAchitecture.Api.Features.Parents.GetAllParents;

[Route("api/parents")]
[ApiController]
public class ParentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ParentDto>))]
    public async Task<ActionResult> Get()
    {
        var vm = await _mediator.Send(new GetAllParentsQuery());
        return Ok(vm);
    }
}