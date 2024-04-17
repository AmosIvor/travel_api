using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using travel_api.Models.EF;
using travel_api.Models.Utils;

namespace travel_api.Repositories
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        #region Init DbSet

        // EF
        public DbSet<User> Users { get; set; }

        // Utils
        public DbSet<Photo> Photos { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Model Creating ...
        }
    }
}
