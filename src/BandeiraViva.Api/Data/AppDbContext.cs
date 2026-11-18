using BandeiraViva.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BandeiraViva.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Beach> Beaches => Set<Beach>();
    public DbSet<WaterReading> WaterReadings => Set<WaterReading>();
    public DbSet<AnonymousReport> AnonymousReports => Set<AnonymousReport>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beach>(entity =>
        {
            entity.Property(beach => beach.Name).HasMaxLength(100).IsRequired();
            entity.Property(beach => beach.Neighborhood).HasMaxLength(100).IsRequired();
            entity.HasMany(beach => beach.WaterReadings)
                .WithOne(reading => reading.Beach)
                .HasForeignKey(reading => reading.BeachId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<WaterReading>(entity =>
        {
            entity.Property(reading => reading.Source).HasMaxLength(80).IsRequired();
            entity.Property(reading => reading.Status).HasMaxLength(30).IsRequired();
            entity.Property(reading => reading.Explanation).HasMaxLength(300);
        });

        modelBuilder.Entity<AnonymousReport>(entity =>
        {
            entity.Property(report => report.Description).HasMaxLength(500).IsRequired();
            entity.Property(report => report.Category).HasMaxLength(60).IsRequired();
            entity.HasOne(report => report.Beach)
                .WithMany()
                .HasForeignKey(report => report.BeachId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
