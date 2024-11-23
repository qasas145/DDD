using MediatR;
public class GetOrdersQueryHandler : IRequestHandler<GetOrderQuery, IEnumerable<OrderDTO>>
{
    private readonly IOrderQueryService _service;
    public GetOrdersQueryHandler(IOrderQueryService service) {
        _service = service;
    }
    public async Task<IEnumerable<OrderDTO>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetOrdersAsync();
    }
}