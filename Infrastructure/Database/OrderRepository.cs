

public class OrderRepository :IRepository<Order>{
    private readonly OrderDbContext _context;
    public OrderRepository(OrderDbContext _context) {
        this._context = _context;
    }
    public Order FindOrder(int id) {
        return this._context.Orders.Find(id);
    }

    public void Add(Order obj)
    {
        _context.Orders.Add(obj);
    }

    public void Delete(Order obj)
    {
        _context.Orders.Remove(obj);
    }

    public Order Get(int id)
    {
        return FindOrder(id);
    }

    public void Update(int id, Order obj)
    {
        var dbOrder = FindOrder(id);
        ArgumentNullException.ThrowIfNull(dbOrder);
        _context.Entry(dbOrder).CurrentValues.SetValues(obj);
    }

    public IEnumerable<Order> Search(Func<Order, bool> predicate)
    {
        return _context.Orders.Where(predicate);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}