public interface IRepository<T>  {
    public void Add(T obj);
    public IEnumerable<T> Search(Func<T, bool> predicate);
    public void Delete(T obj);
    public T Get(int id);
    public void Update(T obj);
}