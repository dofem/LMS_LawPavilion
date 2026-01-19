using LIBRARY_MANAGEMENT_SYSTEM.Data;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY_MANAGEMENT_SYSTEM.Extensions
{
    public static class DbExtensions
    {
        public static void UseDatabaseMigrationAndSeeding(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
            DbSeeder.Seed(db);
        }
    }
}

