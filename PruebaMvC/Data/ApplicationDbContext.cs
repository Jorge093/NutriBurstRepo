using Microsoft.EntityFrameworkCore;
using NutriBurst.Web.Models.Entities;

namespace NutriBurst.Web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
            
        }

        public DbSet<PatientsNb> PatientsNb { get; set; }
        public DbSet<UsersNb> UsersNb { get; set; }
    }
}
