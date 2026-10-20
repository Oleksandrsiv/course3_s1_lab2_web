using course3_s1_lab1_web.DTOs;

namespace course3_s1_lab1_web.Interfaces;

public interface IFactoryService
{
    Task<IEnumerable<FactoryResponseDto>> GetAllAsync();
    Task<FactoryResponseDto?> GetByIdAsync(int id);
    Task<FactoryResponseDto> CreateAsync(FactoryCreateDto dto);
    Task<bool> UpdateAsync(int id, FactoryCreateDto dto);
    Task<bool> DeleteAsync(int id);
}