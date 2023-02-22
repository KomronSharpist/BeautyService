using BeautyServices.Domain.Entities;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;
using BeautyServices.Service.Interfaces;

namespace BeautyServices.Service.Services;

public class UserService : IUserService
{
    public Task<GenericResponce<User>> CheckLogin(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<User>> CreateAsync(UserDTo userDTo)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<User>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<List<User>>> GetAllAsync(Predicate<User> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<User>> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<User>> UpdateAsync(long id, UserDTo userDto)
    {
        throw new NotImplementedException();
    }
}
