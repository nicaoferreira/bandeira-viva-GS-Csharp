using BandeiraViva.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BandeiraViva.Api.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Beaches.AnyAsync()) return;

        db.Beaches.AddRange(
            new Beach { Name = "Praia do Itararé (Posto 2)", Neighborhood = "Itararé" },
            new Beach { Name = "Praia do Gonzaguinha", Neighborhood = "Gonzaguinha" }
        );

        await db.SaveChangesAsync();
    }
}
