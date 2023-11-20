using CleanArchitecture.Application.ResponseBase;
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser;

public sealed record CreateUserRequest(string Email, string Nome) :
                                                IRequest<Response>;

