using AroundTheWorld.Application.Interfaces.Users;
using AroundTheWorld.Infrastructure.Policies;
using AroundTheWorld.Infrastructure.Repositories;
using AroundTheWorld.Infrastructure.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AroundTheWorld.Infrastructure
{
    public static class DependencyInjection
    {
        public static void ConfigureInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddServices();
        }

        public static void AddAutoMigration(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            services.AddSingleton<RedisRepository>(
                new RedisRepository(
                    configuration.GetConnectionString("RedisDatabase"))
              );
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<TokenBlacklistFilterAttribute>();
        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}


