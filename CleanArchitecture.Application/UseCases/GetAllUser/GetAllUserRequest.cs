using CleanArchitecture.Application.ResponseBase;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetAllUser;

public sealed record GetAllUserRequest :
                    IRequest<List<Response>>;
