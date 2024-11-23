using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class OrderQueryController : ControllerBase {
    private readonly IMediator _mediator;
    public OrderQueryController(IMediator mediator) {
        _mediator = mediator;
    }
    [Route("/api/GetOrdersQuery")]
    [HttpGet]
    public async Task<IEnumerable<OrderDTO>> GetOrderCommand() {
        return await _mediator.Send(new GetOrderQuery());
    }
}