using course3_s1_lab1_web.DTOs;
using course3_s1_lab1_web.Interfaces;
using course3_s1_lab1_web.Models;

namespace course3_s1_lab1_web.Services;

public class FactoryService : IFactoryService
{
    private readonly IFactoryRepository _repository;

    public FactoryService(IFactoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FactoryResponseDto>> GetAllAsync()
    {
        var factories = await _repository.GetAllAsync();
        return factories.Select(f => new FactoryResponseDto { Id = f.Id, Name = f.Name });
    }

    public async Task<FactoryResponseDto?> GetByIdAsync(int id)
    {
        var factory = await _repository.GetByIdAsync(id);
        if (factory == null) return null;
        
        return new FactoryResponseDto { Id = factory.Id, Name = factory.Name };
    }

    public async Task<FactoryResponseDto> CreateAsync(FactoryCreateDto dto)
    {
        var factory = new Factory { Name = dto.Name };
        await _repository.AddAsync(factory); 
        
        return new FactoryResponseDto { Id = factory.Id, Name = factory.Name };
    }

    public async Task<bool> UpdateAsync(int id, FactoryCreateDto dto)
    {
        var factory = await _repository.GetByIdAsync(id);
        if (factory == null) return false;

        factory.Name = dto.Name;
        await _repository.UpdateAsync(factory);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var factory = await _repository.GetByIdAsync(id);
        if (factory == null) return false;

        await _repository.DeleteAsync(factory);
        return true;
    }
}