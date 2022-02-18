using AutoMapper;
using Clientes.Dominio.Entidades;
using Clientes.Dominio.Interfaces;
using FluentValidation;
using System;
using System.Text;

namespace Clientes.Servico.Servicos
{
    public class ClienteServico : BaseServico<Cliente>, IClienteServico
    {
        private readonly IBaseServico<Profissao> _profissaoServico;

        public ClienteServico(IBaseRepositorio<Cliente> clienteRepositorio, IMapper mapper, IBaseServico<Profissao> profissaoServico) : base(clienteRepositorio, mapper)
        {
            _profissaoServico = profissaoServico;
        }

        public Cliente AdicionarCliente<TValidator, TInput>(TInput clienteInput) 
            where TValidator : AbstractValidator<Cliente>
            where TInput : class
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteInput);

            Validate(cliente, Activator.CreateInstance<TValidator>());
            VerificarProfissaoInserida(cliente.IdProfissao);

            AjustarDadosDoCliente(cliente);
            _baseRepositorio.Inserir(cliente);
            return cliente;
        }

        public Cliente AtualizarCliente<TValidator, TInput>(TInput clienteInput)
            where TValidator : AbstractValidator<Cliente>
            where TInput : class
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteInput);

            Validate(cliente, Activator.CreateInstance<TValidator>());
            VerificarProfissaoInserida(cliente.IdProfissao);

            AjustarDadosDoCliente(cliente);
            _baseRepositorio.Atualizar(cliente);
            return cliente;
        }

        private void VerificarProfissaoInserida(int? idProfissao)
        {
            if (idProfissao != null)
            {
                var profissao =  _profissaoServico.SelecionarPorId(idProfissao.Value);
                if(profissao == null)
                    throw new Exception("A profissão inserida não foi encontrada.");
            }  
        }

        private static void AjustarDadosDoCliente(Cliente cliente)
        {
            CalcularIdadeCliente(cliente);
            cliente.Cpf = ApenasNumeros(cliente.Cpf);
        }

        private static void CalcularIdadeCliente(Cliente cliente)
        {
            cliente.Idade = (byte)(DateTime.Now.Year - cliente.DataDeNascimento.Year);
            if (DateTime.Now.DayOfYear < cliente.DataDeNascimento.DayOfYear)
                cliente.Idade--;
        }

        private static string ApenasNumeros(string texto)
        {
            var sb = new StringBuilder(texto.Length);
            foreach (var letra in texto) 
                if (char.IsDigit(letra)) 
                    sb.Append(letra);

            return sb.ToString();
        }
    }
}
