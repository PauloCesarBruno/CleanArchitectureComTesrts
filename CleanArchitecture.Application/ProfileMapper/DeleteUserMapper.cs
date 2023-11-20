using AutoMapper;
using CleanArchitecture.Application.ResponseBase;
using CleanArchitecture.Application.UseCases.DeleteUser;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ProfileMapper;

public sealed class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<DeleteUserRequest, User>().ReverseMap();
    }
}
