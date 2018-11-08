using System;
using TJMT.Docker.DotNet.Samples.Core;
using Xunit;

namespace TJMT.Docker.DotNet.Samples.Test
{
    public class CalculadoraServiceTest
    {
       private readonly CalculadoraService _calculadoraService;

        public CalculadoraServiceTest()
        {
            _calculadoraService = new CalculadoraService();
        }

        [Fact]
        public void Deve_somar_corretamente()
        {
            var result = _calculadoraService.Somar(1, 1);

            Assert.Equal(2, result);
        }
    }
}
