using BeautyServices.Service.DTOs;
using BeautyServices.Service.Interfaces;
using BeautyServices.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BeautyService.Con.Pages;

public class LoginOrRegistration
{
    private IUserService userService = new UserService();

    public void Start()
    {
        Console.WriteLine("1-Login\n2-Registration");
        int input = Convert.ToInt32(Console.ReadKey().Key);


        if (input == 49)
            Login();
        else if (input == 50)
            Registration();
        else
            Start();
    }

    private async void Registration()
    {
        var userDto = new UserDTo();

        WriteLine("First name: ");
        userDto.FirstName = ReadLine();
        WriteLine("Last name: ");
        userDto.LastName = ReadLine();
        WriteLine("Username: ");
        userDto.Username = ReadLine();
        WriteLine("Password: ");
        userDto.Password = ReadLine();
        WriteLine("Email:");
        userDto.Email = ReadLine();

        var response = await userService.CreateAsync(userDto);

        if(response.StatusCode == 200)
        {
            Clear();
            WriteLine("Succes");
        }
        else
        {
            Clear();
            WriteLine("Username was taken! Press enter to continue.");
        }
    }

    private async void Login()
    {
        WriteLine("username: ");
        string username = ReadLine();
        WriteLine("password: ");
        string password = ReadLine();

        var response = await userService.CheckLogin(username, password);

        if (response.StatusCode == 200)
        {
            WriteLine("Succes");
        }
        else
        {
            WriteLine("Username or Password is incorrect!");
        }
    }
}
