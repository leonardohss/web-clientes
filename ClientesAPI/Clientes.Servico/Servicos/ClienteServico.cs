using Clientes.Dominio.Entidades;
using Clientes.Dominio.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Servico.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IBaseRepositorio<Cliente> _clienteRepositorio;

        public ClienteServico(IBaseRepositorio<Cliente> clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Cliente Adicionar<TValidator>(Cliente cliente) where TValidator : AbstractValidator<Cliente>
        {
            CalcularIdadeCliente(cliente);

            Validate(cliente, Activator.CreateInstance<TValidator>());
            _clienteRepositorio.Inserir(cliente);
            return cliente;
        }

        public Cliente Atualizar<TValidator>(Cliente cliente) where TValidator : AbstractValidator<Cliente>
        {
            CalcularIdadeCliente(cliente);

            Validate(cliente, Activator.CreateInstance<TValidator>());
            _clienteRepositorio.Atualizar(cliente);
            return cliente;
        }

        public void DeletarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Cliente> Listar()
        {
            throw new NotImplementedException();
        }

        public Cliente SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        private void Validate(Cliente cliente, AbstractValidator<Cliente> validator)
        {
            if (cliente == null)
                throw new Exception("Cliente não infomado!");

            validator.ValidateAndThrow(cliente);
        }

        private void CalcularIdadeCliente(Cliente cliente)
        {
            cliente.Idade = DateTime.Now.Year - cliente.DataDeNascimento.Year;
            if (DateTime.Now.DayOfYear < cliente.DataDeNascimento.DayOfYear)
                cliente.Idade--;
        }
    }
}
