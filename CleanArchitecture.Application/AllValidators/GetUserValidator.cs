using FluentValidation;

namespace CleanArchitecture.Application.AllValidators;

internal class GetUserValidation : AbstractValidator<GetUserValidation>
{
    public GetUserValidation()
    {
        // Não necessita validção !
    }
}
