using Clientes.Dominio.Interfaces;
using Clientes.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Clientes.Servico.Servicos
{
    public class BaseServico<TEntidade> : IBaseServico<TEntidade> where TEntidade : BaseEntidade
    {
        private readonly IBaseRepositorio<TEntidade> _baseRepositorio;

        public BaseServico(IBaseRepositorio<TEntidade> baseRepositorio)
        {
            _baseRepositorio = baseRepositorio;
        }

        public TEntidade Adicionar<TValidator>(TEntidade objeto) where TValidator : AbstractValidator<TEntidade>
        {
            Validate(objeto, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Inserir(objeto);
            return objeto;
        }

        public TEntidade Atualizar<TValidator>(TEntidade objeto) where TValidator : AbstractValidator<TEntidade>
        {
            Validate(objeto, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Atualizar(objeto);
            return objeto;
        }

        public void DeletarPorId(int id) => _baseRepositorio.DeletarPorId(id);

        public IList<TEntidade> Listar() => _baseRepositorio.Listar();

        public TEntidade SelecionarPorId(int id) => _baseRepositorio.SelecionarPorId(id);

        private void Validate(TEntidade objeto, AbstractValidator<TEntidade> validator)
        {
            if (objeto == null)
                throw new Exception("Objeto inválido!");

            validator.ValidateAndThrow(objeto);
        }
    }
}
