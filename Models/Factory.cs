namespace course3_s1_lab1_web.Models;

public class Factory
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}