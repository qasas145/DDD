public class OrderItem : Entity {
    public int Price{get;private set;}
    public int Quantity{get;private set;}
    public int Total=>Price*Quantity;

    public void UpdatePrice(int newPrice) {
        Price = newPrice;
    }
    public void UpdateQuantity(int newQuantity) {
        Quantity = newQuantity;
    }
    public OrderItem(){}
    public OrderItem(int price, int quantity) {
        this.Price = price;
        this.Quantity = quantity;
    }
}