﻿using Clientes.Dominio.Entidades;
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
        private IBaseServico<Cliente> _clienteServico;

        public ClienteController(IBaseServico<Cliente> clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return NotFound();

            return Execute(() => _clienteServico.Adicionar<ClienteValidador>(cliente).Id);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return NotFound();

            return Execute(() => _clienteServico.Atualizar<ClienteValidador>(cliente));
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
