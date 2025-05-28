using ClinicaVetAPI.Data;
using ClinicaVetAPI.Models;
using ClinicaVetAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVetAPI.Repositories;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _context;

    public TutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tutor>> GetAllAsync() => 
        await _context.Tutores.ToListAsync();

    public async Task<Tutor?> GetByIdAsync(int id) => 
        await _context.Tutores.FindAsync(id);

    public async Task<Tutor> AddAsync(Tutor Tutor)
    {
        _context.Tutores.Add(Tutor);
        await _context.SaveChangesAsync();
        return Tutor;
    }

    public async Task UpdateAsync(Tutor Tutor)
    {
        _context.Tutores.Update(Tutor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var Tutor = await GetByIdAsync(id);
        if (Tutor is null) return;
        _context.Tutores.Remove(Tutor);
        await _context.SaveChangesAsync();
    }
}