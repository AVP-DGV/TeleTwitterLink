using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using TeleTwitterLInk.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TeleTwitterLinkDbContext>
{
    public TeleTwitterLinkDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<TeleTwitterLinkDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);
        return new TeleTwitterLinkDbContext(builder.Options);
    }
}