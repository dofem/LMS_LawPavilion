using LIBRARY_MANAGEMENT_SYSTEM.Entities;
using LIBRARY_MANAGEMENT_SYSTEM.Enums;
using LIBRARY_MANAGEMENT_SYSTEM.Utilities;
using Microsoft.AspNetCore.Identity;

namespace LIBRARY_MANAGEMENT_SYSTEM.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book { Title = "Winning The League", Author = "Mikel Arteta", ISBN = "111", PublishedDate = DateTime.Now.AddYears(-3) },
                    new Book { Title = "Scoring Freekicks", Author = "Declan Rice", ISBN = "222", PublishedDate = DateTime.Now.AddYears(-1) }
                );
            }

            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "Admin",
                    PasswordHash = PasswordHasherMethod.Hash("Admin@123"),
                    Role = UserRole.Admin,
                });
            }

            context.SaveChanges();
        }
    }

}
