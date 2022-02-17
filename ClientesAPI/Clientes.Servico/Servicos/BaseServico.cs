using Clientes.Dominio.Interfaces;
using Clientes.Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Clientes.Servico.Servicos
{
    public class BaseServico<TEntidade> : IBaseServico<TEntidade> where TEntidade : BaseEntidade
    {
        protected readonly IBaseRepositorio<TEntidade> _baseRepositorio;
        protected readonly IMapper _mapper;

        public BaseServico(IBaseRepositorio<TEntidade> baseRepositorio, IMapper mapper)
        {
            _baseRepositorio = baseRepositorio;
            _mapper = mapper;
        }

        public TEntidade Adicionar<TValidator, TInput>(TInput input) 
            where TValidator : AbstractValidator<TEntidade>
            where TInput : class
        {
            TEntidade objeto = _mapper.Map<TEntidade>(input);

            Validate(objeto, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Inserir(objeto);
            return objeto;
        }

        public TEntidade Atualizar<TValidator, TInput>(TInput input)
            where TValidator : AbstractValidator<TEntidade>
            where TInput : class
        {
            TEntidade objeto = _mapper.Map<TEntidade>(input);

            Validate(objeto, Activator.CreateInstance<TValidator>());
            _baseRepositorio.Atualizar(objeto);
            return objeto;
        }

        public void DeletarPorId(int id) => _baseRepositorio.DeletarPorId(id);

        public IList<TEntidade> Listar() => _baseRepositorio.Listar();

        public TEntidade SelecionarPorId(int id) => _baseRepositorio.SelecionarPorId(id);

        protected void Validate(TEntidade objeto, AbstractValidator<TEntidade> validator)
        {
            if (objeto == null)
                throw new Exception("Objeto inválido!");

            validator.ValidateAndThrow(objeto);
        }
    }
}
