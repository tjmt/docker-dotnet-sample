using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;
using TJMT.Docker.DotNet.Sample.Test.ServerFixture;
using TJMT.Docker.DotNet.Samples.Core.Extensions;
using TJMT.Docker.DotNet.Samples.Data;
using Xunit;

namespace TJMT.Docker.DotNet.Sample.Test
{
    [AllowAnyStatusCode]
    public interface ITabelaControllerTestApi
    {
        [Get("tabela")]
        Task<Response<List<Tabela>>> Get();

        [Get("tabela/{id}")]
        Task<Response<Tabela>> Get([Path(UrlEncode = false, Name = "id")]int id);

        [Get("tabela/protocolo")]
        Task<Response<string>> GetByProtocolo();
    }

    public class TabelaControllerTest : IntegrationTestBase
    {
        private readonly ITabelaControllerTestApi _tabelaControllerTestApi;

        public TabelaControllerTest(ServerFixture.ServerFixture factory) : base(factory)
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
                var values = response.StringContent.ReadAsJsonAsync<List<Tabela>>();
                Assert.NotNull(values);
                Assert.NotEmpty(values);
            }
        }
    }
}
