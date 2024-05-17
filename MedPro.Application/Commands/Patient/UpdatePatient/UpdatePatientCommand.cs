using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MedPro.Domain.Enums;

namespace MedPro.Application.Commands.Patient.UpdatePatient
{
    public class UpdatePatientCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
        public BloodTypeEnum BloodTypeEnum { get; set; }
        public string Address { get; set; }

        public decimal Heigth { get; set; }
        public decimal Weigth { get; set; }
    }
}
