using Eclipseworks.Application.Interfaces;
using Eclipseworks.Application.Mappings;
using Eclipseworks.Application.Services;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Infra.Data.Context;
using Eclipseworks.Infra.Data.Repositories;
using Eclipseworks.Infra.Encryption.Service;
using Eclipseworks.Infra.Jwt.Context;
using Eclipseworks.Infra.Jwt.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eclipseworks.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                                                                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
            services.AddScoped<IProjectTaskCommentRepository, ProjectTaskCommentRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectTaskService, ProjectTaskService>();
            services.AddScoped<IProjectTaskCommentService, ProjectTaskCommentService>();
            services.AddScoped<IJwtService>(x => { return new JwtService(new ApplicationJwtContext(){ SecretKey = configuration["Jwt:Secretkey"],
                                                                                                      Issuer = configuration["Jwt:Issuer"],
                                                                                                      Audience = configuration["Jwt:Audience"],
                                                                                                      ExpiresMinutes = int.Parse(configuration["Jwt:ExpiresMinutes"])});
            });
            services.AddScoped<IEncryptionService>(x => new EncryptionService(configuration["Secretkey"]));

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
