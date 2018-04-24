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

        public DbSet<TwitterUser> TweetUsers { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(x => x.TweeterUsers);

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
