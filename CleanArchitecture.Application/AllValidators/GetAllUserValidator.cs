using CleanArchitecture.Application.UseCases.GetAllUser;
using FluentValidation;

namespace CleanArchitecture.Application.AllValidators;

internal class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
{
    public GetAllUserValidator()
    {
        // Não necessita validção !
    }
}
