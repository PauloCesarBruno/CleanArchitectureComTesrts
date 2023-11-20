using AutoMapper;
using CleanArchitecture.Application.ResponseBase;
using CleanArchitecture.Application.UseCases.UpdateUser;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ProfileMapper;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserRequest, User>().ReverseMap();
    }
}
