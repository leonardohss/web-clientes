using AutoMapper;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Interfaces;
using FluentValidation;
using System;

namespace Clientes.Servico.Servicos
{
    public class ClienteServico : BaseServico<Cliente>, IClienteServico
    {
        public ClienteServico(IBaseRepositorio<Cliente> clienteRepositorio, IMapper mapper) : base(clienteRepositorio, mapper)
        {
        }

        public Cliente AdicionarCliente<TValidator, TInput>(TInput clienteInput) 
            where TValidator : AbstractValidator<Cliente>
            where TInput : class
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteInput);
            Validate(cliente, Activator.CreateInstance<TValidator>());

            CalcularIdadeCliente(cliente);
            _baseRepositorio.Inserir(cliente);
            return cliente;
        }

        public Cliente AtualizarCliente<TValidator, TInput>(TInput clienteInput)
            where TValidator : AbstractValidator<Cliente>
            where TInput : class
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteInput);
            Validate(cliente, Activator.CreateInstance<TValidator>());

            CalcularIdadeCliente(cliente);
            _baseRepositorio.Atualizar(cliente);
            return cliente;
        }

        private void CalcularIdadeCliente(Cliente cliente)
        {
            cliente.Idade = (byte)(DateTime.Now.Year - cliente.DataDeNascimento.Year);
            if (DateTime.Now.DayOfYear < cliente.DataDeNascimento.DayOfYear)
                cliente.Idade--;
        }
    }
}
