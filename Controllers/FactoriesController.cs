using Microsoft.AspNetCore.Mvc;
using course3_s1_lab1_web.DTOs;
using course3_s1_lab1_web.Interfaces;

namespace course3_s1_lab1_web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FactoriesController : ControllerBase
{
    private readonly IFactoryService _factoryService;

    public FactoriesController(IFactoryService factoryService)
    {
        _factoryService = factoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FactoryResponseDto>>> GetAll()
    {
        var factories = await _factoryService.GetAllAsync();
        return Ok(factories); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FactoryResponseDto>> GetById(int id)
    {
        var factory = await _factoryService.GetByIdAsync(id);
        if (factory == null)
        {
            return NotFound(); 
        }
        return Ok(factory);
    }

    [HttpPost]
    public async Task<ActionResult<FactoryResponseDto>> Create(FactoryCreateDto dto)
    {
        var createdFactory = await _factoryService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdFactory.Id }, createdFactory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, FactoryCreateDto dto)
    {
        var updated = await _factoryService.UpdateAsync(id, dto);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _factoryService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}