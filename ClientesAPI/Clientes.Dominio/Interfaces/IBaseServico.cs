using Clientes.Dominio.Entidades;
using FluentValidation;
using System.Collections.Generic;

namespace Clientes.Dominio.Interfaces
{
    public interface IBaseServico<TEntidade> where TEntidade : BaseEntidade
    {
        TEntidade Adicionar<TValidator, TInput>(TInput objeto)
            where TValidator : AbstractValidator<TEntidade>
            where TInput : class;
        TEntidade Atualizar<TValidator, TInput>(TInput objeto)
            where TValidator : AbstractValidator<TEntidade>
            where TInput : class;
        void DeletarPorId(int id);
        IList<TEntidade> Listar();
        TEntidade SelecionarPorId(int id);
    }
}
