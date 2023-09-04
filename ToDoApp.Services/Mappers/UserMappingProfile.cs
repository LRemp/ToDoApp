using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Services.Mappers;

public class UserMappingProfile: Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}