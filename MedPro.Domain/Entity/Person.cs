public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string DocumentNumber { get; set; }
    public BloodType BloodType { get; set; }
    public Address Address { get; set; }
}