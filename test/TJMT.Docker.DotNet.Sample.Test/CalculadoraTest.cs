using System;
using TJMT.Docker.DotNet.Samples.Core;
using Xunit;

namespace TJMT.Docker.DotNet.Sample.Test
{
    public class CalculadoraTest
    {
        [Fact]
        public void Deve_somar_corretamente()
        {
            var calc = new CalculadoraService();
            var result = calc.Somar(1, 1);

            Assert.Equal(2, result);
        }
    }
}
