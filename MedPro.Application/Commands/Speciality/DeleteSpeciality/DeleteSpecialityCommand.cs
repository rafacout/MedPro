using MediatR;

namespace MedPro.Application.Commands.DeleteSpeciality;

public class DeleteSpecialityCommand : IRequest<Unit>
{
    public DeleteSpecialityCommand(Guid id)
    {
        Id = id;
    }
    
    public Guid Id { get; private set; }
}