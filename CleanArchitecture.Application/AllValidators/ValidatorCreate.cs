using CleanArchitecture.Application.UseCases.CreateUser;
using FluentValidation;

namespace CleanArchitecture.Application.AllValidators;

public sealed class ValidatorCreate : AbstractValidator<CreateUserRequest>
{
    public ValidatorCreate()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Nome).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}