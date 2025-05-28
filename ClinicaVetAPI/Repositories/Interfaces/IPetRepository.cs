using ClinicaVetAPI.Models;

namespace ClinicaVetAPI.Repositories.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAllAsync();
    Task<Pet?> GetByIdAsync(int id);
    Task<Pet> AddAsync(Pet Pet);
    Task UpdateAsync(Pet Pet);
    Task DeleteAsync(int id);
}