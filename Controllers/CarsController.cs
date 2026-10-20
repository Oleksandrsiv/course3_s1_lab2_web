using Microsoft.AspNetCore.Mvc;
using course3_s1_lab1_web.DTOs;
using course3_s1_lab1_web.Interfaces;

namespace course3_s1_lab1_web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarResponseDto>>> GetAll()
    {
        var cars = await _carService.GetAllAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CarResponseDto>> GetById(int id)
    {
        var car = await _carService.GetByIdAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [HttpPost]
    public async Task<ActionResult<CarResponseDto>> Create(CarCreateDto dto)
    {
        var createdCar = await _carService.CreateAsync(dto);
        
        if (createdCar == null)
        {
            return BadRequest("Фабрики з таким FactoryId не існує.");
        }

        return CreatedAtAction(nameof(GetById), new { id = createdCar.Id }, createdCar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CarCreateDto dto)
    {
        var result = await _carService.UpdateAsync(id, dto);
        
        if (result == null) 
        {
            return BadRequest("Фабрики з таким FactoryId не існує.");
        }
        if (result == false)
        {
            return NotFound("Машину не знайдено.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _carService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}