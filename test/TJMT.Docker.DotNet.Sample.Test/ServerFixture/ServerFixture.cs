using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using TJMT.Docker.DotNet.Samples;

namespace TJMT.Docker.DotNet.Sample.Test.ServerFixture
{
    public class ServerFixture : WebApplicationFactory<Startup>
    {
        protected override void ConfigureClient(HttpClient client)
        {
            base.ConfigureClient(client);
            ConfigBaseAdress(client);
        }

        private static void ConfigBaseAdress(HttpClient client)
        {
            var config = new ConfigurationBuilder()
                            .AddEnvironmentVariables()
                            .Build();

            string baseAdress = config["HOST"];

            if (!string.IsNullOrWhiteSpace(baseAdress))
            {
                client.BaseAddress = new Uri(config["HOST"]);
            }
        }
    }
}