public class OrderItemDTO {
    public int Id{get;set;}
    public int OrderId{get;set;}
    public int Price{get;private set;}
    public int Quantity{get;private set;}
    public int Total{get;set;}
}