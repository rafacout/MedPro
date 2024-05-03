using MedPro.Domain.Entities.Base;

namespace MedPro.Domain.Entities;

public class Service : BaseEntity
{
    public Service(string name, decimal amount, int duration)
    {
        Name = name;
        Amount = amount;
        Duration = duration;
    }
    
    public string Name { get; private set; }
    public decimal Amount { get; private set; }
    public int Duration { get; private set; }
    
    public List<Appointment> Appointments { get; set; }
}