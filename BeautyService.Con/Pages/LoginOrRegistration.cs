using BeautyServices.Domain.Entities;
using BeautyServices.Domain.Enums;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;
using BeautyServices.Service.Interfaces;
using BeautyServices.Service.Services;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BeautyService.Con.Pages.LoginOrRegistration;
using static System.Console;

namespace BeautyService.Con.Pages;

public class LoginOrRegistration
{
    private IUserService userService = new UserService();
    private IWorkerService workerService = new WorkerService();
    private IOrderService orderService = new OrderService();
    private IPlannerService plannerService = new PlannerService();
    private UserDTo akkaunt = new UserDTo();
    public void Start()
    {
        Clear();
        Console.WriteLine("1-Login\n2-Registration");
        int input = Convert.ToInt32(Console.ReadKey().Key);


        if (input == 49)
            Login();
        else if (input == 50)
            Registration();
        else
            Start();
    }

    public async void Registration()
    {
        var userDto = new UserDTo();
        startFirst:
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

        akkaunt.FirstName = userDto.FirstName;
        akkaunt.LastName = userDto.LastName;
        akkaunt.Username = userDto.Username;
        akkaunt.Password = userDto.Password;
        akkaunt.Email = userDto.Email;

        if (response.StatusCode == 200)
        {
            Clear();
            User();
        }
        else
        {
            Clear();
            WriteLine("Username was taken!");
            goto startFirst;
        }
    }

    private async void Login()
    {
    startFirst:
        WriteLine("username: ");
        string username = ReadLine();
        WriteLine("password: ");
        string password = ReadLine();

        var response = await userService.CheckLogin(username, password);

        if (response.StatusCode == 200)
        {
            WriteLine("Succes");
            if (response.Value.userRole == RoleTypes.admin)
            {
                akkaunt.FirstName = response.Value.FirstName;
                akkaunt.LastName = response.Value.LastName;
                akkaunt.Username = response.Value.Username;
                akkaunt.Password = response.Value.Password;
                akkaunt.Email = response.Value.Email;
                Admin();
            }
            else
            {
                User();
            }
        }
        else
        {
            WriteLine("Username or Password is incorrect!");
            goto startFirst;
        }
    }

    private async void Admin()
    {
        Clear();
        start:
        WriteLine("1-Get all workers\n2-Create new worker\n3-Get all orders\n4-Accaunt\n5-Get all users\n6-Get by id workers\n7-Get by id users\n8-Get by id orders");
        int chose = int.Parse(ReadLine());
        if(chose == 1)
        {
            Clear();
            var result = await workerService.GetAllAsync(u => true);
            foreach (var i in result.Value)
            {
                Write($"\n                    ID : {i.Id} ProfesorName : {i.ProfName} ProfesorLName : {i.ProfLastName}\n                    Description : {i.Description} Job : {i.Job} Status : {i.Status}\n");
            }
        }
        if(chose == 2)
        {
            Clear();
            WorkerService workerService = new WorkerService();
            WorkerDTo worker = new WorkerDTo();
            worker.job = Jobs.braids;
            Write("Work description : ");
            worker.Description = ReadLine();
            Write("Profesor ismi : ");
            worker.ProfName = ReadLine();
            Write("Profesor familiyasi : ");
            worker.ProfLastName = ReadLine();
            Write("Work price : ");
            worker.Price = ReadLine();
            await workerService.CreateAsync(worker);
            goto start;
        }
        if(chose == 3)
        {
            Clear();
            var result = await orderService.GetAllAsync(u => true);
            foreach (var i in result.Value)
            {
                Write($"\n                    ID : {i.Id} ProfesorName : {i.UserId} ProfesorLName : {i.WorkerId}\n                    Description : {i.Description} Status : {i.StatusType}\n");
            }

        }
        if(chose == 4)
        {
            Clear();
            WriteLine($"{akkaunt.Username}\n{akkaunt.Password}\n{akkaunt.FirstName}\n{akkaunt.LastName}\n{akkaunt.Email}\n\n1-Exit Accaunt");
            if(int.Parse(ReadLine()) == 1)
            {
                Start();
            }
        }
        if(chose == 5)
        {
            Clear();
            var result = await userService.GetAllAsync(u => true);
            foreach (var i in result.Value)
            {
                Write($"\n                    ID : {i.Id} FirstName : {i.FirstName} LastName : {i.LastName}\n                    Username : {i.Username} Password : {i.Password} Email : {i.Email}\n");
            }
        }
        if(chose == 6)
        {
            Clear();
            Write("Id kiriting : ");
            var result = await workerService.GetAsync(int.Parse(ReadLine()));
            WriteLine($"\n                    ID : {result.Value.Id} ProfesorName : {result.Value.ProfName} ProfesorLName : {result.Value.ProfLastName}\n                    Description : {result.Value.Description} Job : {result.Value.Job} Price : {result.Value.Price}\n");
        }
        if (chose == 7)
        {
            Clear();
            Write("Id kiriting : ");
            var result = await userService.GetAsync(int.Parse(ReadLine()));
            WriteLine($"\n                    ID : {result.Value.Id} FirstName : {result.Value.FirstName} LastName : {result.Value.LastName}\n                    Username : {result.Value.Username} Password : {result.Value.Password} Email : {result.Value.Email}\n");
        }
        if (chose == 8)
        {
            Clear();
            Write("Id kiriting : ");
            var result = await orderService.GetAsync(int.Parse(ReadLine()));
            WriteLine($"\n                    ID : {result.Value.Id} UserID : {result.Value.UserId} WorkerID : {result.Value.WorkerId}\n                    Description : {result.Value.Description} CreatedAT : {result.Value.CreatedAt}\n");
        }
    }
    private async void User()
    {
        Clear();
        WriteLine("1-Akkaunt malumot\n2-Get all worker list\n3-Get by id worker\n4-Get Planned list\n5-Get all order list\n6-Get by id order\n7-Get history of orders\n");
        int chose = int.Parse(ReadLine());
        if(chose == 1)
        {
            Clear();
            WriteLine($"{akkaunt.Username}\n{akkaunt.Password}\n{akkaunt.FirstName}\n{akkaunt.LastName}\n{akkaunt.Email}\n\n1-Exit Accaunt");
            if (int.Parse(ReadLine()) == 1)
            {
                Start();
            }
            else User();
        }
        if(chose == 2)
        {
            Clear();
            var result = await workerService.GetAllAsync(u => true);
            foreach (var i in result.Value)
            {
                Write($"\n                    ID : {i.Id} ProfesorName : {i.ProfName} ProfesorLName : {i.ProfLastName}\n                    Description : {i.Description} Job : {i.Job} Status : {i.Status}\n");
            }
        }
        if(chose == 3)
        {
            Clear();
            Write("Id kiriting : ");
            var result = await workerService.GetAsync(int.Parse(ReadLine()));
            WriteLine($"\n                    ID : {result.Value.Id} ProfesorName : {result.Value.ProfName} ProfesorLName : {result.Value.ProfLastName}\n                    Description : {result.Value.Description} Job : {result.Value.Job} Price : {result.Value.Price}\n");
        }
        if (chose == 4)
        {
            Clear();
        }
        if (chose == 5)
        {
            Clear();
        }
        if(chose == 6)
        {
            Clear();
        }
        if(chose == 7)
        {
            Clear();
        }
    }
}
