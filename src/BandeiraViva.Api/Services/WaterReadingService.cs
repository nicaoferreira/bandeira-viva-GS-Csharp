using BandeiraViva.Api.Data;
using BandeiraViva.Api.DTOs;
using BandeiraViva.Api.Interfaces;
using BandeiraViva.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BandeiraViva.Api.Services;

public class WaterReadingService(AppDbContext db, IBathingStatusClassifier classifier)
    : IWaterReadingService
{
    public async Task<IReadOnlyList<WaterReading>> GetByBeachAsync(
        int beachId, CancellationToken cancellationToken) =>
        await db.WaterReadings.AsNoTracking()
            .Where(reading => reading.BeachId == beachId)
            .OrderByDescending(reading => reading.CollectedAt)
            .ToListAsync(cancellationToken);

    public async Task<WaterReading?> CreateAsync(
        CreateWaterReadingDto dto, CancellationToken cancellationToken)
    {
        var beachExists = await db.Beaches.AnyAsync(
            beach => beach.Id == dto.BeachId && beach.IsActive, cancellationToken);

        if (!beachExists) return null;

        var classification = classifier.Classify(dto.EnterococciPer100Ml);

        var reading = new WaterReading
        {
            BeachId = dto.BeachId,
            TurbidityNtu = dto.TurbidityNtu,
            TemperatureCelsius = dto.TemperatureCelsius,
            EnterococciPer100Ml = dto.EnterococciPer100Ml,
            Source = dto.Source.Trim(),
            Status = classification.Status,
            Explanation = classification.Explanation,
            CollectedAt = DateTime.UtcNow
        };

        db.WaterReadings.Add(reading);
        await db.SaveChangesAsync(cancellationToken);
        return reading;
    }
}
