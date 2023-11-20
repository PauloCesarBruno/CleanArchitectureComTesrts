using AutoMapper;
using CleanArchitecture.Application.ResponseBase;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.UpdateUser;

public class UpdateUserHandler  : IRequestHandler<UpdateUserRequest, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<Response> Handle(UpdateUserRequest command,
                                                 CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(command.Id, cancellationToken);
        if (user == null) return default;

        user.Nome = command.Nome;
        user.Email = command.Email;

        _userRepository.Update(user);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<Response>(user);
    }
}
