namespace Clientes.Servico.Servicos
{
    public class ClienteServicoBase
    {

        public new Cliente Adicionar<TValidator, TInput>(TInput clienteInput)
            where TValidator : AbstractValidator<Cliente>
            where TInput : class
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteInput);
            Validate(cliente, Activator.CreateInstance<TValidator>());

            CalcularIdadeCliente(cliente);
            _clienteRepositorio.Inserir(cliente);
            return cliente;
        }
    }
}