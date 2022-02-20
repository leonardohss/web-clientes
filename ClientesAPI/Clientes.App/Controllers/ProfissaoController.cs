using Clientes.Dominio.Entidades;
using Clientes.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Clientes.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissaoController : ControllerBase
    {
        private IBaseServico<Profissao> _profissaoServico;

        public ProfissaoController(IBaseServico<Profissao> profissaoServico)
        {
            _profissaoServico = profissaoServico;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Executar(() => _profissaoServico.Listar());
        }

        private IActionResult Executar(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
