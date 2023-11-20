using AutoMapper;
using CleanArchitecture.Application.ResponseBase;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.DeleteUser;

public sealed class DeleteUserHandler :
                    IRequestHandler<DeleteUserRequest, Response>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(DeleteUserRequest request,
                                        CancellationToken cancellationToken)
    {
        // Usando o Get para obter o usuario pelo Id.
        var user = await _userRepository.Get(request.Id, cancellationToken);

        if (user == null) return default;

        _userRepository.Delete(user);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<Response>(user);
    }
}
