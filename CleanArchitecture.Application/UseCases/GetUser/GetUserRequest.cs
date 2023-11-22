using CleanArchitecture.Application.ResponseBase;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetUser;

public sealed record GetUserRequest(Guid Id) :
                    IRequest<Response>;
