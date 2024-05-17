using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MedPro.Application.Commands.Patient.DeletePatient
{
    public class DeletePatientCommand : IRequest<Unit>
    {
        public DeletePatientCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
