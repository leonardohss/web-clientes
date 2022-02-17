using Clientes.Dominio.Entidades;
using FluentValidation;

namespace Clientes.Dominio.Interfaces
{
    public interface IClienteServico : IBaseServico<Cliente>
    {
        Cliente AdicionarCliente<TValidator, TInput>(TInput clienteInput)
            where TValidator : AbstractValidator<Cliente>
            where TInput : class;

        Cliente AtualizarCliente<TValidator, TInput>(TInput clienteInput)
            where TValidator : AbstractValidator<Cliente>
            where TInput : class;
    }
}
