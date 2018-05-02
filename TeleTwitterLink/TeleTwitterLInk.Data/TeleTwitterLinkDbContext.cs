using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.Data.Models.Abstract;

namespace TeleTwitterLInk.Data
{
    public class TeleTwitterLinkDbContext : IdentityDbContext<User>
    {
        public TeleTwitterLinkDbContext(DbContextOptions<TeleTwitterLinkDbContext> options)
           : base(options)
        {
        }

        public DbSet<TwitterUser> TwitterUsers { get; set; }

        public DbSet<UserTwitterUser> UserTwitterUsers { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<UserTweet> UserTweet { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserTwitterUser>()
                .HasKey(k => new { k.TwitterUserId, k.UserId });

            builder.Entity<UserTwitterUser>()
                .HasOne<User>(u => u.User)
                .WithMany(t => t.UserTwitterUsers)
                .HasForeignKey(k => k.UserId);

            builder.Entity<UserTwitterUser>()
                .HasOne<TwitterUser>(t => t.TwitterUser)
                .WithMany(u => u.UserTwitterUsers)
                .HasForeignKey(k => k.TwitterUserId);

            builder.Entity<UserTweet>()
                .HasKey(k => new { k.TweetId, k.UserId });

            builder.Entity<UserTweet>()
                .HasOne<User>(u => u.User)
                .WithMany(t => t.UserTweet)
                .HasForeignKey(k => k.UserId);

            builder.Entity<UserTweet>()
                .HasOne<Tweet>(t => t.Tweet)
                .WithMany(u => u.UserTweet)
                .HasForeignKey(k => k.TweetId);

            base.OnModelCreating(builder);
        }

        private void ApplyAuditInfoRules()
        {
            var newlyCreatedEntities = this.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in newlyCreatedEntities)
            {
                var entity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == null)
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
