using AutoMapper;
using CleanArchitecture.Application.ResponseBase;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.ProfileMapper;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>().ReverseMap(); 
    }
}
