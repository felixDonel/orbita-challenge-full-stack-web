using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbita.Model
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(student => student.Name)
                .NotEmpty().WithMessage("O nome do estudante é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ser maior que 3 caracteres.")
                .MaximumLength(50).WithMessage("O nome deve ser menor que 50 caracteres.");

            RuleFor(student => student.Email)
                .NotEmpty().WithMessage("O e-mail do estudante é obrigatório.")
                .EmailAddress().WithMessage("Por favor, insira um endereço de e-mail válido.");

            RuleFor(student => student.CPF)
                .NotEmpty().WithMessage("O CPF do estudante é obrigatório.")
                .Must(CPFValid).WithMessage("Por favor, insira um CPF válido.");
        }

        private bool CPFValid(long cpf)
        {
            string cpfStr = cpf.ToString();
            return cpfStr.Length == 11;
        }
    }
}
