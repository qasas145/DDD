public abstract class Entity {
    public int Id{get;set;}

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj))return true;
        var other = (Entity)obj;
        if (other.Id == default | this.Id == default) return false;

        return other.Id == this.Id;
    }
    public static bool operator ==(Entity e1, Entity e2) {
        if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) {
            return false;
        }
        if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) {
            return false;
        }
        if (e1.GetType() != e2.GetType()) return false;

        return e1.Equals(e2);
    }
    public static bool operator !=(Entity e1, Entity e2) {
        return !(e1 == e2);
    }
    public override int GetHashCode()
    {
        return this.Id.GetHashCode() ^ 31;
    }
}