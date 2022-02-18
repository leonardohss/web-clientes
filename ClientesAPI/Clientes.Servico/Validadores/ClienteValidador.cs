using Clientes.Dominio.Entidades;
using FluentValidation;
using System;

namespace Clientes.Servico.Validadores
{
    public class ClienteValidador : AbstractValidator<Cliente>
    {
        public ClienteValidador()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, insira o Nome do cliente.")
                .NotNull().WithMessage("Por favor, insira o Nome do cliente.");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Por favor, insira o Sobrenome do cliente.")
                .NotNull().WithMessage("Por favor, insira o Sobrenome do cliente.");

			RuleFor(c => c.Cpf)
				.NotEmpty().WithMessage("Por favor, insira o Cpf do cliente.")
				.NotNull().WithMessage("Por favor, insira o Cpf do cliente.")
				.Must(cpf => CpfValido(cpf)).WithMessage("Cpf informado inválido.");

			RuleFor(c => c.DataDeNascimento)
                .NotEmpty().WithMessage("Por favor, insira a Data De Nascimento do cliente.")
                .NotNull().WithMessage("Por favor, insira o Data De Nascimento do cliente.")
				.Must(dataDeNascimento => DataDeNascimentoValida(dataDeNascimento)).WithMessage("A Data De Nascimento informada é inválida.");
        }

		private static bool CpfValido(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}

		public static bool DataDeNascimentoValida(DateTime dataDeNascimento)
        {
			var anos = DateTime.Now.Year - dataDeNascimento.Year;
			return dataDeNascimento <= DateTime.Now && (anos >= 0 || anos <= 150);
        }
	}
}
