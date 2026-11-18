using BandeiraViva.Api.Data;
using BandeiraViva.Api.DTOs;
using BandeiraViva.Api.Interfaces;
using BandeiraViva.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BandeiraViva.Api.Services;

public class AnonymousReportService(AppDbContext db) : IAnonymousReportService
{
    public async Task<AnonymousReport?> CreateAsync(
        CreateAnonymousReportDto dto, CancellationToken cancellationToken)
    {
        var beachExists = await db.Beaches.AnyAsync(
            beach => beach.Id == dto.BeachId && beach.IsActive, cancellationToken);

        if (!beachExists) return null;

        var report = new AnonymousReport
        {
            BeachId = dto.BeachId,
            Description = dto.Description.Trim(),
            Category = dto.Category.Trim(),
            CreatedAt = DateTime.UtcNow
        };

        db.AnonymousReports.Add(report);
        await db.SaveChangesAsync(cancellationToken);
        return report;
    }

    public async Task<IReadOnlyList<AnonymousReport>> GetByBeachAsync(
        int beachId, CancellationToken cancellationToken) =>
        await db.AnonymousReports.AsNoTracking()
            .Where(report => report.BeachId == beachId)
            .OrderByDescending(report => report.CreatedAt)
            .ToListAsync(cancellationToken);
}
