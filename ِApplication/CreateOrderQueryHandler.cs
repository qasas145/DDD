using MediatR;
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly  IOrderCommandService _service;
    public CreateOrderCommandHandler(IOrderCommandService service){
        _service = service;
    }
    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await _service.CreateOrderAsync(request);
        return true;
    }
}