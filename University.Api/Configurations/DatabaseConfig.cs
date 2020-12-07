using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using University.Data;

namespace University.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            string sqlConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UniversityContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);
            });
        }
    }
}