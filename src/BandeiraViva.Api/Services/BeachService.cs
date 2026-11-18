using BandeiraViva.Api.Data;
using BandeiraViva.Api.Interfaces;
using BandeiraViva.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BandeiraViva.Api.Services;

public class BeachService(AppDbContext db) : IBeachService
{
    public async Task<IReadOnlyList<Beach>> GetAllAsync(CancellationToken cancellationToken) =>
        await db.Beaches.AsNoTracking()
            .Where(beach => beach.IsActive)
            .OrderBy(beach => beach.Name)
            .ToListAsync(cancellationToken);

    public Task<Beach?> GetByIdAsync(int id, CancellationToken cancellationToken) =>
        db.Beaches.AsNoTracking()
            .FirstOrDefaultAsync(beach => beach.Id == id && beach.IsActive, cancellationToken);
}
