using IMS.Data;
using IMS.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);

        // Add services to the container.
        builder.ConfigureServices((context, services) =>
        {
            services.AddControllersWithViews();
            services.AddDbContext<IMSDatabaseContext>(options =>
                options.UseSqlServer(context.Configuration.GetConnectionString("IMSDatabase")));

            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(context.Configuration.GetConnectionString("IMSAuthDatabase")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
        });

        var host = builder.Build();

        // Run the application.
        host.Run();
    }
}
