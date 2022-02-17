using Clientes.App.Dtos;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Interfaces;
using Clientes.Servico.Validadores;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Clientes.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null)
                return NotFound();

            return Execute(() => _clienteServico.AdicionarCliente<ClienteValidador, ClienteDTO>(clienteDto).Id);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null)
                return NotFound();

            return Execute(() => _clienteServico.AtualizarCliente<ClienteValidador, ClienteDTO>(clienteDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _clienteServico.DeletarPorId(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _clienteServico.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _clienteServico.SelecionarPorId(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
