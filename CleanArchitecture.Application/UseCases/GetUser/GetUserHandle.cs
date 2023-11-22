using AutoMapper;
using CleanArchitecture.Application.ResponseBase;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetUser;

public class GetUserHandle : IRequestHandler<GetUserRequest, Response>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserHandle(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetById(request.Id, cancellationToken);
        return _mapper.Map<Response>(users);
    }
}
