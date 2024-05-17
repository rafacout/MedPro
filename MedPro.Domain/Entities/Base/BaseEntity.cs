namespace MedPro.Domain.Entities.Base;

public abstract class BaseEntity
{
    protected BaseEntity() { }

    public Guid Id { get; private set; }
}