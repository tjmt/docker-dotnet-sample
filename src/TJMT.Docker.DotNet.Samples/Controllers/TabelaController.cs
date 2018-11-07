using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TJMT.Docker.DotNet.Samples.Data;

namespace TJMT.Docker.DotNet.Samples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaController : ControllerBase
    {
        public BancoContext DbContext { get; set; }

        public TabelaController(BancoContext bancoContext)
        {
            this.DbContext = bancoContext;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Tabela>> Get()
        {
            var query = this.DbContext.Tabela;
            var result = query.ToList();

            return Ok(result);
        }
    }
}