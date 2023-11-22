using AutoMapper;
using CleanArchitecture.Application.UseCases.GetUser;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ProfileMapper;

public class GetUserMapper : Profile
{
    public GetUserMapper()
    {
       CreateMap<GetUserRequest, User>();
    }
}
