namespace course3_s1_lab1_web.DTOs;

public class CarResponseDto
{
    public int Id { get; set; }
    public required string ModelName { get; set; }
    public required int FactoryId { get; set; }
}