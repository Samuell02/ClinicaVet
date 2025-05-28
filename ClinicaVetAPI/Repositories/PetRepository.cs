using ClinicaVetAPI.Data;
using ClinicaVetAPI.Models;
using ClinicaVetAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ClinicaVetAPI.Repositories;

namespace ClinicaVetAPI.Repositories;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pet>> GetAllAsync() =>
        await _context.Pets.Include(l => l.Tutor).ToListAsync();

    public async Task<Pet?> GetByIdAsync(int id) =>
        await _context.Pets.Include(l => l.Tutor)
            .FirstOrDefaultAsync(l => l.Id == id);

    public async Task<Pet> AddAsync(Pet Pet)
    {
        _context.Pets.Add(Pet);
        await _context.SaveChangesAsync();
        return Pet;
    }

    public async Task UpdateAsync(Pet Pet)
    {
        _context.Pets.Update(Pet);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var Pet = await GetByIdAsync(id);
        if (Pet is null) return;
        _context.Pets.Remove(Pet);
        await _context.SaveChangesAsync();
    }
}