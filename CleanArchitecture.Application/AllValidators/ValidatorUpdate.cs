using CleanArchitecture.Application.UseCases.UpdateUser;
using FluentValidation;

namespace CleanArchitecture.Application.AllValidators;

public sealed class ValidatorUpdate : AbstractValidator<UpdateUserRequest>
{
    public ValidatorUpdate()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(x => x.Nome).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}
