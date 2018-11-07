using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TJMT.Docker.DotNet.Samples.Data;

namespace TJMT.Docker.DotNet.Samples.Extensions
{
    public static class IServiceCollectionExtensionsMethods
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["CONNECTION_STRING"];


            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("No 'CONNECTION_STRING' environment variable was specified!");

            services.AddDbContext<BancoContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
