using MedPro.Domain.Entities.Base;

namespace MedPro.Domain.Entities;

public class Insurance : BaseEntity
{
    public Insurance()
    {
    }
    
    public Insurance(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
}