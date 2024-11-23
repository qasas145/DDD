public class Order :Entity {
    public Address Address{get;private set;}
    private readonly List<OrderItem> orderItems;
    public IReadOnlyCollection<OrderItem> Items=>orderItems;

    public Order(){}   
    public Order(Address address) {
        this.Address = address;
    }
    public void AddOrderItem(OrderItem item) {
        this.orderItems.Add(item);
    }
    public void RemoveOrderitem(OrderItem item) {
        this.orderItems.Remove(item);
    }
}