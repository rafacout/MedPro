using MediatR;
using MedPro.Domain.Entities;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;

namespace MedPro.Application.Commands.CreateSpeciality;

public class CreateSpecialityCommandHandler : IRequestHandler<CreateSpecialityCommand, Guid>
{
    private readonly ISpecialityRepository _specialityRepository;
    public CreateSpecialityCommandHandler(ISpecialityRepository specialityRepository)
    {
        _specialityRepository = specialityRepository;
    }
    
    public async Task<Guid> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
    {
        var speciality = new Speciality(request.Name, request.Description);

        var guid = await _specialityRepository.CreateAsync(speciality);

        return guid;
    }
}