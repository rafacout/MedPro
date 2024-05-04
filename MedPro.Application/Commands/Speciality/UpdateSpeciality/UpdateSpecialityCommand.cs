using MediatR;

namespace MedPro.Application.Commands.UpdateSpeciality;

public class UpdateSpecialityCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}