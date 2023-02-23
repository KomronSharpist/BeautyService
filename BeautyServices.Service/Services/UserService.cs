using BeautyServices.Data.GenericRepostories;
using BeautyServices.Data.IGenericRepostories;
using BeautyServices.Domain.Entities;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;
using BeautyServices.Service.Interfaces;

namespace BeautyServices.Service.Services;

public class UserService : IUserService
{
    private readonly IGenericRepostory<User> userRepository;
    public UserService()
    {
        userRepository = new GenericRepostory<User>();
    }
    public async Task<GenericResponce<User>> CheckLogin(string username, string password)
    {
        var users = await userRepository.GetAllAsync();

        foreach (var user in users)
        {
            if (user.Username == username && user.Password == password)
            {
                return new GenericResponce<User>
                {
                    StatusCode = 200,
                    Message = "Success",
                    Value = user
                };
            }
        }

        return new GenericResponce<User>
        {
            StatusCode = 404,
            Message = "Not found",
            Value = null
        };
    }

    public async Task<GenericResponce<User>> CreateAsync(UserDTo userDTo)
    {
        var user = (await userRepository.GetAllAsync()).FirstOrDefault(u => u.Username == userDTo.Username);

        if (user is null)
        {
            var NewUser = new User()
            {
                CreatedAt = DateTime.Now,
                Email = userDTo.Email,
                FirstName = userDTo.FirstName,
                LastName = userDTo.LastName,
                Username = userDTo.Username,
                Password = userDTo.Password,
            };

            var result = await userRepository.CreateAsync(NewUser);

            return new GenericResponce<User>
            {
                StatusCode = 200,
                Message = "Succes created",
                Value = result
            };
        }

        return new GenericResponce<User>
        {
            StatusCode = 405,
            Message = "User is already created",
            Value = null
        };
    }

    public async Task<GenericResponce<User>> DeleteAsync(long id)
    {
        var user = await this.userRepository.GetAsync(id);

        if (user is not null)
        {
            await this.userRepository.DeleteAsync(id);
            return new GenericResponce<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = user
            };
        }

        return new GenericResponce<User>()
        {
            StatusCode = 404,
            Message = "User is not found",
            Value = null
        };
    }

    public async Task<GenericResponce<List<User>>> GetAllAsync(Predicate<User> predicate)
    {
        var result = await this.userRepository.GetAllAsync(predicate);
        return new GenericResponce<List<User>>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = result
        };
    }

    public async Task<GenericResponce<User>> GetAsync(long id)
    {
        var user = await this.userRepository.GetAsync(id);
        if (user is not null)
            return new GenericResponce<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = user
            };

        return new GenericResponce<User>()
        {
            StatusCode = 404,
            Message = "User is not found",
            Value = null
        };
    }

    public async Task<GenericResponce<User>> UpdateAsync(long id, UserDTo userDto)
    {
        var users = await userRepository.GetAllAsync();
        var user = users.FirstOrDefault(u => u.Id == id);

        if (user is null)
        {

            if (user.Username != userDto.Username)
            {
                var userWithUsername = users.FirstOrDefault(c => c.Username == userDto.Username);

                if (userWithUsername is not null)
                    return new GenericResponce<User>
                    {
                        StatusCode = 405,
                        Message = "Username is taken",
                        Value = null
                    };
            }

            user.UpdatedAt = DateTime.UtcNow;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.Username = userDto.Username;
            var result = await userRepository.UpdateAsync(user);

            return new GenericResponce<User>
            {
                StatusCode = 200,
                Message = "Succes",
                Value = result
            };
        }

        return new GenericResponce<User>
        {
            StatusCode = 404,
            Message = "User is not found",
            Value = null
        };
    }
}
