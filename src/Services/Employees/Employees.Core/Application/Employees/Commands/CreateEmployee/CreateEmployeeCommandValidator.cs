using FluentValidation;
using System.Text.RegularExpressions;

namespace Employees.Core.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Name must be set")
                .MaximumLength(25)
                    .WithMessage("Maximum length is 20 symbols");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("LastName must be set")
                .MaximumLength(25)
                    .WithMessage("Maximum length is 20 symbols");

            RuleFor(c => c.Age)
                .GreaterThan(0)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Age must be set");

            RuleFor(c => c.Phone)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Phone must be set")
                .Length(12)
                    .WithMessage("Length must be exactly 12 symbols without plus(+) sign")
                .Must(IsPhoneValid)
                    .WithMessage("PhoneNumber in format 380961111111 without plus(+) sign");

            RuleFor(c=>c.Email)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Email must be set")
                .MaximumLength(100)
                    .WithMessage("Maximum length is 100 symbols");
        }

        private bool IsPhoneValid(string phone)
        {
            return Regex.Match(phone, pattern: @"^(\d{12})$").Success;
        }
    }
}
