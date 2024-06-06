using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Repositories;

namespace MedPro.Application.Commands.Patient.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            var patient = new Domain.Entities.Patient(request.UserId, request.FirstName, request.LastName,
                request.BirthDate, request.PhoneNumber,
                request.Email, request.DocumentNumber, request.BloodTypeEnum, request.Address, request.Heigth,
                request.Weigth);
            
            var id = await _unitOfWork.Patients.CreateAsync(patient);
            
            await _unitOfWork.CompleteAsync();
            
            return id;
        }
    }
}
