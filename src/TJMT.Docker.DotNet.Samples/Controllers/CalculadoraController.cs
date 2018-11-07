using Microsoft.AspNetCore.Mvc;
using TJMT.Docker.DotNet.Samples.Core;

namespace TJMT.Docker.DotNet.Samples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        public CalculadoraController()
        {

        }


        // GET api/values
        [HttpGet("somar/{a}/{b}")]
        public ActionResult<double> Somar(int a, int b)
        {
            CalculadoraService calc = new CalculadoraService();
            return calc.Somar(a, b);
        }
    }
}