using MediatR;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Repositories;

namespace MedPro.Application.Commands.UpdateSpeciality;

public class UpdateSpecialityCommandHandler : IRequestHandler<UpdateSpecialityCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateSpecialityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateSpecialityCommand request, CancellationToken cancellationToken)
    {
        var speciality = await _unitOfWork.Specialities.GetByIdAsync(request.Id);

        if (speciality is not null)
        {
            speciality.Update(request.Name, request.Description);
            await _unitOfWork.Specialities.UpdateAsync(speciality);
            await _unitOfWork.CompleteAsync();
        }

        return Unit.Value;
    }
}