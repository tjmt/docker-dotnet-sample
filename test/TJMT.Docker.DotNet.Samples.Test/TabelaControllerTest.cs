using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;
using TJMT.Docker.DotNet.Samples.Core.Extensions;
using TJMT.Docker.DotNet.Samples.Data;
using TJMT.Docker.DotNet.Samples.Test.Server;
using Xunit;

namespace TJMT.Docker.DotNet.Samples.Test
{
    [AllowAnyStatusCode]
    public interface ITabelaControllerTestApi
    {
        [Get("tabela")]
        Task<Response<List<Tabela>>> Get();        
    }
    public class TabelaControllerTest : IntegrationTestBase
    {
        private readonly ITabelaControllerTestApi _tabelaControllerTestApi;
        public TabelaControllerTest(ServerFixture factory) : base(factory)
        {
            _tabelaControllerTestApi = RestClient.For<ITabelaControllerTestApi>(base.HttpClient);
        }

        [Fact]
        public async Task Ao_obter_todos_os_dados_retorno_nao_deve_ser_vazio()
        {
            var response = await _tabelaControllerTestApi.Get();
            var isSuccessStatusCode = response.ResponseMessage.IsSuccessStatusCode;
            Assert.True(isSuccessStatusCode);

            if (isSuccessStatusCode)
            {
                var values = response.StringContent.ReadAsJsonAsync<IEnumerable<Tabela>>();
                Assert.NotNull(values);
                Assert.NotEmpty(values);
            }
        }
    }
}
