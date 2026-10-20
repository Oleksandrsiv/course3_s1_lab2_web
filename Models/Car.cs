using System.Text.Json.Serialization;

namespace course3_s1_lab1_web.Models;

public class Car
{
    public int Id { get; set; }
    public required string ModelName { get; set; }
    public required int FactoryId { get; set; }
    
    [JsonIgnore]
    public Factory? Factory { get; set; } 
}