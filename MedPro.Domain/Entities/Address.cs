namespace MedPro.Domain.Entities;

public class Address : BaseEntity
{
    public Address(string street, string number, string complement, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Complement = complement;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }
    
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
}