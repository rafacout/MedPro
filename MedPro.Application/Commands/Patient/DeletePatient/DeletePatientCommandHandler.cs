using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MedPro.Infrastructure.Persistence.Repositories;

namespace MedPro.Application.Commands.Patient.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Patients.DeleteAsync(request.Id);
            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
