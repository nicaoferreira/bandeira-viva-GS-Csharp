namespace BandeiraViva.Api.Models;

public class AnonymousReport
{
    public int Id { get; set; }
    public int BeachId { get; set; }
    public Beach? Beach { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = "Outro";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Recebido";
}
