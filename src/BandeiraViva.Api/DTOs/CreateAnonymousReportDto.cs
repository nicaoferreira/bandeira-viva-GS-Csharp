using System.ComponentModel.DataAnnotations;

namespace BandeiraViva.Api.DTOs;

public class CreateAnonymousReportDto
{
    [Range(1, int.MaxValue)]
    public int BeachId { get; set; }

    [Required, StringLength(500, MinimumLength = 5)]
    public string Description { get; set; } = string.Empty;

    [Required, StringLength(60)]
    public string Category { get; set; } = "Outro";
}
