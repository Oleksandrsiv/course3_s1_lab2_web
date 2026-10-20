using Microsoft.EntityFrameworkCore;
using course3_s1_lab1_web.Data;
using course3_s1_lab1_web.Interfaces;
using course3_s1_lab1_web.Models;

namespace course3_s1_lab1_web.Repositories;

public class FactoryRepository : IFactoryRepository
{
    private readonly AppDbContext _context;

    public FactoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Factory>> GetAllAsync() => await _context.Factories.ToListAsync();

    public async Task<Factory?> GetByIdAsync(int id) => await _context.Factories.FirstOrDefaultAsync(f => f.Id == id);

    public async Task<bool> ExistsAsync(int id) => await _context.Factories.AnyAsync(f => f.Id == id);

    public async Task AddAsync(Factory factory)
    {
        await _context.Factories.AddAsync(factory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Factory factory)
    {
        _context.Factories.Update(factory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Factory factory)
    {
        _context.Factories.Remove(factory);
        await _context.SaveChangesAsync();
    }
}