namespace BandeiraViva.Api.Models;

public class Beach
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = "São Vicente";
    public bool IsActive { get; set; } = true;

    public ICollection<WaterReading> WaterReadings { get; set; } = new List<WaterReading>();
}
