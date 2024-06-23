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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PostMedia> PostMedias { get; set; }
        public DbSet<FeedbackMedia> FeedbackMedias { get; set; }
        public DbSet<CommentMedia> CommentMedias { get; set; }
        public DbSet<LocationMedia> LocationMedias { get; set; }

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
                .WithMany(l => l.Posts)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            // PostMedia_Post
            modelBuilder.Entity<PostMedia>()
                .HasOne(pm => pm.Post)
                .WithMany(p => p.PostMedias)
                .HasForeignKey(pm => pm.PostId)
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
                .WithMany(l => l.Feedbacks)
                .HasForeignKey(f => f.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            // FeedbackMedia_Feedback
            modelBuilder.Entity<FeedbackMedia>()
                .HasOne(fm => fm.Feedback)
                .WithMany(f => f.FeedbackMedias)
                .HasForeignKey(fm => fm.FeedbackId)
                .OnDelete(DeleteBehavior.NoAction);

            // Comment_User
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Comment_Post
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            // CommentMedia_Comment
            modelBuilder.Entity<CommentMedia>()
                .HasOne(cm => cm.Comment)
                .WithMany(c => c.CommentMedias)
                .HasForeignKey(cm => cm.CommentId)
                .OnDelete(DeleteBehavior.NoAction);

            // Location - Decimal Config
            modelBuilder.Entity<Location>()
                .Property(l => l.LocationLongtitude)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Location>()
                .Property(l => l.LocationLatitude)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Location>()
                .Property(l => l.LocationRateAverage)
                .HasPrecision(18, 2);

            // LocationMedia_Location
            modelBuilder.Entity<LocationMedia>()
                .HasOne(lm => lm.Location)
                .WithMany(f => f.LocationMedias)
                .HasForeignKey(fm => fm.LocationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
