using Clientes.Dominio.Entidades;
using FluentValidation;
using System.Collections.Generic;

namespace Clientes.Dominio.Interfaces
{
    public interface IBaseServico<TEntidade> where TEntidade : BaseEntidade
    {
        TEntidade Adicionar<TValidator>(TEntidade objeto) where TValidator : AbstractValidator<TEntidade>;
        TEntidade Atualizar<TValidator>(TEntidade objeto) where TValidator : AbstractValidator<TEntidade>;
        void DeletarPorId(int id);
        IList<TEntidade> Listar();
        TEntidade SelecionarPorId(int id);
    }
}
