using BandeiraViva.Api.DTOs;
using BandeiraViva.Api.Models;

namespace BandeiraViva.Api.Interfaces;

public interface IAnonymousReportService
{
    Task<AnonymousReport?> CreateAsync(CreateAnonymousReportDto dto, CancellationToken cancellationToken);
    Task<IReadOnlyList<AnonymousReport>> GetByBeachAsync(int beachId, CancellationToken cancellationToken);
}
