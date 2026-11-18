using BandeiraViva.Api.Models;

namespace BandeiraViva.Api.Interfaces;

public interface IBeachService
{
    Task<IReadOnlyList<Beach>> GetAllAsync(CancellationToken cancellationToken);
    Task<Beach?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
