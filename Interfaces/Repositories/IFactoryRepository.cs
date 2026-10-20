using course3_s1_lab1_web.Models;

namespace course3_s1_lab1_web.Interfaces;

public interface IFactoryRepository
{
    Task<IEnumerable<Factory>> GetAllAsync();
    Task<Factory?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task AddAsync(Factory factory);
    Task UpdateAsync(Factory factory);
    Task DeleteAsync(Factory factory);
}