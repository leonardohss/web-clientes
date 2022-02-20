using Clientes.App.Dtos;
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

            return Executar(() => _clienteServico.AdicionarCliente<ClienteValidador, ClienteDTO>(clienteDto).Id);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null)
                return NotFound();

            return Executar(() => _clienteServico.AtualizarCliente<ClienteValidador, ClienteDTO>(clienteDto).Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (id == 0)
                return NotFound();

            Executar(() =>
            {
                _clienteServico.DeletarPorId(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Executar(() => _clienteServico.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult SelecionarPorId(int id)
        {
            if (id == 0)
                return NotFound();

            return Executar(() => _clienteServico.SelecionarClientePorId(id));
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
