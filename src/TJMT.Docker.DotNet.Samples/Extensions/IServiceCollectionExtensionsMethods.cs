using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TJMT.Docker.DotNet.Samples.Data;

namespace TJMT.Docker.DotNet.Samples.Extensions
{
    public static class IServiceCollectionExtensionsMethods
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["CONNECTION_STRING"];
            services.AddDbContext<BancoContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
