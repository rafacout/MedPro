using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedPro.Domain.Entities;
using MedPro.Domain.Models;
using MedPro.Domain.Repositories;
using MedPro.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedProDbContext _dbContext;
        private const int PAGE_SIZE = 10;

        public PatientRepository(MedProDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginationResult<Patient>> GetAllAsync(string? query, int page = 1)
        {
            IQueryable<Patient> patients = _dbContext.Patients;

            if (!string.IsNullOrEmpty(query))
            {
                patients = patients.Where(x => x.FirstName.Contains(query) || x.LastName.Contains(query));
            }

            return await patients.GetPaged(page, PAGE_SIZE);
        }

        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient?> GetByDocumentAsync(string document)
        {
            return await _dbContext.Patients.FirstOrDefaultAsync(p => p.DocumentNumber == document);
        }

        public async Task<Patient?> GetByPhoneAsync(string phone)
        {
            return await _dbContext.Patients.FirstOrDefaultAsync(p => p.PhoneNumber == phone);
        }

        public async Task<Guid> CreateAsync(Patient patient)
        {
            await _dbContext.Patients.AddAsync(patient);
            return patient.Id;
        }

        public async Task UpdateAsync(Patient patient)
        {
            _dbContext.Patients.Update(patient);
        }

        public async Task DeleteAsync(Guid id)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(s => s.Id == id);

            if (patient != null)
            {
                _dbContext.Patients.Remove(patient);
            }
        }
    }
}
