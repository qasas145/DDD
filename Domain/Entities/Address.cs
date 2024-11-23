
public class Address : ValueObject
{
    public string Country{get;set;}
    public string City{get;set;}
    public string Village{get;set;}
    public override IEnumerable<object> GetObjects()
    {
        return new [] {Country, City, Village};
    }
    public Address(){}
    public Address(string country, string city, string village) {
        this.Country = country;
        this.City = city;
        this.Village = village;
    }
}