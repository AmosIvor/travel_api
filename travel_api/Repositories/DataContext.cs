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
        public DbSet<City> Cities { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Location> Locations { get; set; }

        // Utils
        public DbSet<Photo> Photos { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Post_User
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Post_Location
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Location)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            // PostMedia
            modelBuilder.Entity<PostMedia>()
                .HasOne(f => f.Post)
                .WithMany(u => u.PostMedias)
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            // Feedback_User
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Feedback_Location
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Location)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            // FeedbackMedia
            modelBuilder.Entity<FeedbackMedia>()
                .HasOne(f => f.Feedback)
                .WithMany(u => u.FeedbackMedias)
                .HasForeignKey(f => f.FeedbackId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
