using System.ComponentModel.DataAnnotations;

namespace BandeiraViva.Api.DTOs;

public class CreateWaterReadingDto
{
    [Range(1, int.MaxValue)]
    public int BeachId { get; set; }

    public double? TurbidityNtu { get; set; }
    public double? TemperatureCelsius { get; set; }
    public double? EnterococciPer100Ml { get; set; }

    [Required, StringLength(80)]
    public string Source { get; set; } = "Registro manual";
}
