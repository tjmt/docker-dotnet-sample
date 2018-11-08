using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TJMT.Docker.DotNet.Samples.Test.Server
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
