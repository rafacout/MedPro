using MediatR;
using MedPro.Domain.Repositories;

namespace MedPro.Application.Commands.UpdateSpeciality;

public class UpdateSpecialityCommandHandler : IRequestHandler<UpdateSpecialityCommand, Unit>
{
    private readonly ISpecialityRepository _specialityRepository;

    public UpdateSpecialityCommandHandler(ISpecialityRepository specialityRepository)
    {
        _specialityRepository = specialityRepository;
    }

    public async Task<Unit> Handle(UpdateSpecialityCommand request, CancellationToken cancellationToken)
    {
        var speciality = await _specialityRepository.GetByIdAsync(request.Id);

        if (speciality != null)
        {
            speciality.Update(request.Name, request.Description);
            await _specialityRepository.UpdateAsync(speciality);
        }

        return Unit.Value;
    }
}