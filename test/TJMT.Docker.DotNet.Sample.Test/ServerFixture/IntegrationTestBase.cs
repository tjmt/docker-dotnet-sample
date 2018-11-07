using System.Net.Http;
using Xunit;

namespace TJMT.Docker.DotNet.Sample.Test.ServerFixture
{
    public class IntegrationTestBase : IClassFixture<ServerFixture>
    {
        public readonly HttpClient HttpClient;

        public IntegrationTestBase(ServerFixture factory)
        {
            HttpClient = factory.CreateDefaultClient();
        }
    }
}