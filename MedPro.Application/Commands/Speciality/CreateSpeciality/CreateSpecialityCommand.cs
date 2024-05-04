using MediatR;
using MedPro.Infrastructure.Persistence.Context;

namespace MedPro.Application.Commands.CreateSpeciality;

public class CreateSpecialityCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}