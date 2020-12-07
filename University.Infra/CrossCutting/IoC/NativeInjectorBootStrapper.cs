using Microsoft.Extensions.DependencyInjection;
using University.Application.Interfaces;
using University.Application.Services;
using University.Core.Interfaces;
using University.Data;
using University.Data.Repository;

namespace University.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IStudentAppService, StudentAppService>();

            // Infra - Data
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<UniversityContext>();
        }
    }
}