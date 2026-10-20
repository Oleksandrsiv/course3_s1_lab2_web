using Microsoft.EntityFrameworkCore;
using course3_s1_lab1_web.Data;
using course3_s1_lab1_web.Interfaces;
using course3_s1_lab1_web.Models;

namespace course3_s1_lab1_web.Repositories;

public class CarRepository : ICarRepository
{
    private readonly AppDbContext _context;

    public CarRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Car>> GetAllAsync() => await _context.Cars.ToListAsync();

    public async Task<Car?> GetByIdAsync(int id) => await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Car>> GetByFactoryIdAsync(int factoryId) => 
        await _context.Cars.Where(c => c.FactoryId == factoryId).ToListAsync();

    public async Task AddAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Car car)
    {
        _context.Cars.Update(car);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Car car)
    {
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
    }
}