using ClinicaVetAPI.Models;

namespace ClinicaVetAPI.Repositories.Interfaces;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetAllAsync();
    Task<Tutor?> GetByIdAsync(int id);
    Task<Tutor> AddAsync(Tutor Tutor);
    Task UpdateAsync(Tutor Tutor);
    Task DeleteAsync(int id);
}