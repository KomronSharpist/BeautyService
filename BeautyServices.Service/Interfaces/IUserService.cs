using BeautyServices.Domain.Entities;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;

namespace BeautyServices.Service.Interfaces;

public interface IUserService
{
    Task<GenericResponce<User>> CreateAsync(UserDTo userDTo);
    Task<GenericResponce<User>> DeleteAsync(long id);
    Task<GenericResponce<User>> UpdateAsync(long id, UserDTo userDto);
    Task<GenericResponce<User>> GetAsync(long id);
    Task<GenericResponce<User>> CheckLogin(string username, string password);
    Task<GenericResponce<List<User>>> GetAllAsync(Predicate<User> predicate);
}
