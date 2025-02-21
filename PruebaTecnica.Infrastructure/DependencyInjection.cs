using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Infrastructure.Data;
using PruebaTecnica.Infrastructure.Repositories;

namespace PruebaTecnica.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection Services,
            IConfiguration Configuration)
        {
            var ConnectionString = Configuration.GetConnectionString("ConnectionString") ?? throw new ArgumentNullException(nameof(Configuration));
            Services.AddDbContext<ApplicationDBContext>(Options =>
            {
                Options.UseNpgsql(ConnectionString).UseSnakeCaseNamingConvention();
            });
            Services.AddScoped<UserRepository>();
            Services.AddScoped<LoanRepository>();
            Services.AddSingleton<SQLConnectionFactory>(_ => new SQLConnectionFactory(ConnectionString));
            return Services;
        }
    }
}
