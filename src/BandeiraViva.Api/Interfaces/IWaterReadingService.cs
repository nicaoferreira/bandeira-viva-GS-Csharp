using BandeiraViva.Api.DTOs;
using BandeiraViva.Api.Models;

namespace BandeiraViva.Api.Interfaces;

public interface IWaterReadingService
{
    Task<IReadOnlyList<WaterReading>> GetByBeachAsync(int beachId, CancellationToken cancellationToken);
    Task<WaterReading?> CreateAsync(CreateWaterReadingDto dto, CancellationToken cancellationToken);
}
