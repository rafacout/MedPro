using MediatR;
using MedPro.Domain.Entities;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using MedPro.Infrastructure.Persistence.Repositories;

namespace MedPro.Application.Commands.CreateSpeciality;

public class CreateSpecialityCommandHandler : IRequestHandler<CreateSpecialityCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateSpecialityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Guid> Handle(CreateSpecialityCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var speciality = new Speciality(request.Name, request.Description);
        var id = await _unitOfWork.Specialities.CreateAsync(speciality);
        await _unitOfWork.CompleteAsync();
        return id;
    }
}