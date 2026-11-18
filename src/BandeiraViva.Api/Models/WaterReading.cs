namespace BandeiraViva.Api.Models;

public class WaterReading
{
    public int Id { get; set; }
    public int BeachId { get; set; }
    public Beach? Beach { get; set; }
    public DateTime CollectedAt { get; set; } = DateTime.UtcNow;
    public double? TurbidityNtu { get; set; }
    public double? TemperatureCelsius { get; set; }
    public double? EnterococciPer100Ml { get; set; }
    public string Source { get; set; } = "Registro manual";
    public string Status { get; set; } = "Indeterminada";
    public string Explanation { get; set; } = string.Empty;
}
