public class Order :AggregateRoot {
    public Address Address{get;private set;}
    private readonly List<OrderItem> orderItems;
    public IReadOnlyCollection<OrderItem> Items=>orderItems;

    public Order(){}   
    public Order(Address address) {
        this.Address = address;
    }
    public OrderItem GetOrderItem(int id) {
        return orderItems.Find(o=>o.Id == id);
    }
    public void AddOrderItem(OrderItem item) {
        this.orderItems.Add(item);
    }
    public void RemoveOrderitem(OrderItem item) {
        this.orderItems.Remove(item);
    }
    public void UpdateAddress(string country, string city, string village) {
        var newAddress = new Address(country, city, village);
        Address = newAddress;
    }
    public void UpdateAddress(Address address) {
        Address = address;
    }
}