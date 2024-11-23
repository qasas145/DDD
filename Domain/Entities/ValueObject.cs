public abstract class ValueObject {
    public abstract IEnumerable<object> GetObjects();

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        var other = (ValueObject)obj;

        var otherEnumerator = other.GetObjects().GetEnumerator();
        var myEnumerator = GetObjects().GetEnumerator();

        while (otherEnumerator.MoveNext() && myEnumerator.MoveNext()) {

            if (ReferenceEquals(otherEnumerator.Current, null) && !ReferenceEquals(myEnumerator, null)) 
                return false;
            else if (!ReferenceEquals(otherEnumerator.Current, null) && ReferenceEquals(myEnumerator, null))
                return false;
            else if (otherEnumerator.Current != myEnumerator.Current)
                return false;
        }
        return true;
    }
    public static bool operator ==(ValueObject v1, ValueObject v2) {
        if (ReferenceEquals(v1, null) && !ReferenceEquals(v2, null)) {
            return false;
        }
        if (!ReferenceEquals(v1, null) && ReferenceEquals(v2, null)) {
            return false;
        }

        if (v1.GetType() != v2.GetType())return  false;

        return v1.Equals(v2);
    }
    public static bool operator !=(ValueObject v1, ValueObject v2) {
        return !(v1 == v2);
    }
}