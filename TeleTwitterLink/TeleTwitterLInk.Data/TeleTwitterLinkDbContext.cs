using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TeleTwitterLink.Data.Models;

namespace TeleTwitterLInk.Data
{
    public class TeleTwitterLinkDbContext : IdentityDbContext<User>
    {
        public TeleTwitterLinkDbContext(DbContextOptions<TeleTwitterLinkDbContext> options)
           : base(options)
        {
        }
    }
}
