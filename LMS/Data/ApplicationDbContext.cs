using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string projectRootDirectory = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
            string databaseDirectory = Path.Combine(projectRootDirectory, "Data");

            // Ensure the 'dp' directory exists
            if (!Directory.Exists(databaseDirectory))
            {
                Directory.CreateDirectory(databaseDirectory);
            }

            string databasePath = Path.Combine(databaseDirectory, "LMSDB.db");
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }
    }
}
