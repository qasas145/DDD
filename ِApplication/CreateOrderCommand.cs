using MediatR;

public class CreateOrderCommand :OrderDTO,IRequest<bool> {

}