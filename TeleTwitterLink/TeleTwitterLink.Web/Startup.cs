using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeleTwitterLink.Data.Models;
using TeleTwitterLInk.Data;
using TeleTwitterLink.Services.External;
using TeleTwitterLink.Infrastructure.Providers;
using TeleTwitterLink.Services.Data;
using TeleTwitterLInk.Data.Repository;
using TeleTwitterLInk.Data.Saver;
using TeleTwitterLink.Services.External.Contracts;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.Configuration = configuration;
            this.Environment = env;

            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        private void RegisterData(IServiceCollection services)
        {
            services.AddDbContext<TeleTwitterLinkDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ISaver, EntitySaver>();
        }

        private void RegisterAuthentication(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<TeleTwitterLinkDbContext>()
                .AddDefaultTokenProviders();

            if (this.Environment.IsDevelopment())
            {
                services.Configure<IdentityOptions>(options =>
                {
                    // Password settings
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(1);
                    options.Lockout.MaxFailedAccessAttempts = 999;
                });
            }
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.Configure<TwitterKeys>(Configuration.GetSection("TwitterKeys"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ITwitterApiService, TwitterApiService>();
            services.AddTransient<ITwitterApiCall, TwitterApiCall>();
            services.AddTransient<ITwitterKeys, TwitterKeys>();
            services.AddTransient<IJsonDeserializer, JsonDeserializer>();
        }

        private void RegisterInfrastructure(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddAutoMapper();

            services.AddScoped<IMappingProvider, MappingProvider>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.RegisterData(services);
            this.RegisterAuthentication(services);
            this.RegisterServices(services);
            this.RegisterInfrastructure(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (this.Environment.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
