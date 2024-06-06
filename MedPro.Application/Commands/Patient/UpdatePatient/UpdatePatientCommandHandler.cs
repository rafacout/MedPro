using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MedPro.Infrastructure.Persistence.Repositories;

namespace MedPro.Application.Commands.Patient.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            var patient = await _unitOfWork.Patients.GetByIdAsync(request.Id);

            if (patient is not null)
            {
                patient.Update(request.UserId, request.FirstName, request.LastName, request.BirthDate,
                    request.PhoneNumber, request.Email, request.DocumentNumber,
                    request.BloodTypeEnum, request.Address, request.Heigth, request.Weigth);

                await _unitOfWork.Patients.UpdateAsync(patient);
                await _unitOfWork.CompleteAsync();
            }

            return Unit.Value;
        }
    }
}
