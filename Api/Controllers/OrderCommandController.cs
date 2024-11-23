using Microsoft.AspNetCore.Mvc;
using MediatR;
[ApiController]
public class OrderCommandController :ControllerBase{
    private readonly IMediator _mediator;
    public OrderCommandController(IMediator mediator) {
        _mediator = mediator;
    }
    [HttpPost]
    [Route("/api/createorder")]
    public async Task<bool> CreateOrderCommand(CreateOrderCommand order) {
        
        return  await _mediator.Send(order);
    }
}