﻿using BeautyServices.Data.GenericRepostories;
using BeautyServices.Data.IGenericRepostories;
using BeautyServices.Domain.Entities;
using BeautyServices.Service.Helpers;
using BeautyServices.Service.Interfaces;

namespace BeautyServices.Service.Services;

public class PlannerService : IPlannerService
{
    private IGenericRepostory<Planner> PlannerRepo;
    public void CartService()
    {
        PlannerRepo = new GenericRepostory<Planner>();
    }
    public async Task<GenericResponce<Planner>> CreateAsync(long userId)
    {
        var Planner = (await PlannerRepo.GetAllAsync()).FirstOrDefault(c => c.Id == userId);

        if (Planner is not null)
            return new GenericResponce<Planner>
            {
                StatusCode = 404,
                Message = "Cart is already created",
                Value = null
            };

        var result = await PlannerRepo.CreateAsync(new Planner
        {
            UserId = Planner.UserId,
            CreatedAt = DateTime.Now,
            Items = new List<Workers>()
        });

        return new GenericResponce<Planner>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = result
        };
    }

    public async Task<GenericResponce<List<Planner>>> GetAllAsync(Predicate<Planner> predicate)
    {
        var models = await PlannerRepo.GetAllAsync(predicate);

        return new GenericResponce<List<Planner>>
        {
            StatusCode = 200,
            Message = "Success",
            Value = models
        };
    }

    public async Task<GenericResponce<Planner>> GetAsync(long userId)
    {
        var cart = (await PlannerRepo.GetAllAsync(c => c.UserId == userId)).FirstOrDefault();

        if (cart is null)
            return new GenericResponce<Planner>
            {
                StatusCode = 404,
                Message = "Not found",
                Value = null
            };

        return new GenericResponce<Planner>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = cart
        };
    }
    public async Task<GenericResponce<Planner>> UpdateAsync(Planner cart)
    {
        var PlannerUpdate = (await PlannerRepo.GetAllAsync(c => c.Id == cart.Id)).FirstOrDefault();

        if (PlannerUpdate is null)
            return new GenericResponce<Planner>
            {
                StatusCode = 404,
                Message = "Not Found",
                Value = null
            };

        cart.UpdatedAt = DateTime.Now;
        var result = await PlannerRepo.UpdateAsync(cart);

        return new GenericResponce<Planner>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = result
        };
    }
}
