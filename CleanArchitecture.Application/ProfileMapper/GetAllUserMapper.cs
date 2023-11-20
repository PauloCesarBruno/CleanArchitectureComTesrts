using AutoMapper;
using CleanArchitecture.Application.ResponseBase;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ProfileMapper;

public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, Response>();
    }
}
