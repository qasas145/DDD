public class OrderCommandService {
    private readonly IRepository<Order> _repository;
    public OrderCommandService(IRepository<Order> _repository) {
        _repository = _repository;
    }
    public async Task CreateOrderAsync(OrderDTO dto) {
        Address address = dto.GetShippingDomainEntity();
        Order order = new Order(address);
        _repository.Add(order);
        await _repository.SaveChanges();
    }
    public async Task UpdateOrderAddressAsync(AddressDTO newAddress) {
        var order = _repository.Get(newAddress.Id);
        Address address = new Address(newAddress.Address_Country, newAddress.Address_City, newAddress.Address_Village);
        order.UpdateAddress(address);
        await _repository.SaveChanges();

    }
    public void AddOrder(Order order){
        _repository.Add(order);
    }
    public async Task DeleteOrderAsync(int id) {
        var order = _repository.Get(id);
        _repository.Delete(order);
        await _repository.SaveChanges();
    }

    public async Task AddItemToOrder(OrderItemDTO item) {
        var order = _repository.Get(item.OrderId);
        order.AddOrderItem(new OrderItem(item.Price, item.Quantity));
        await _repository.SaveChanges();
    }
    public async Task UpdatePriceAsync(int orderId, int orderItemId, int price) {
        var order = _repository.Get(orderId);
        var orderItem = order.GetOrderItem(orderItemId);
        orderItem.UpdatePrice(price);
        await _repository.SaveChanges();
    }
    public async Task UpdateQuantityAsync(int orderId, int orderItemId, int Quantity) {
        var order = _repository.Get(orderId);
        var orderItem = order.GetOrderItem(orderItemId);
        orderItem.UpdateQuantity(Quantity);
        await _repository.SaveChanges();
    }
}