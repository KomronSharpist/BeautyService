using BeautyServices.Domain.Entities;
using BeautyServices.Service.Helpers;
using BeautyServices.Service.Interfaces;

namespace BeautyServices.Service.Services;

public class PlannerService : IPlannerService
{
    public Task<GenericResponce<Planner>> CreateAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<List<Planner>>> GetAllAsync(Predicate<Planner> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<Planner>> GetAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<decimal>> GetTotalPriceAsync(Planner cart)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<Planner>> UpdateAsync(Planner cart)
    {
        throw new NotImplementedException();
    }
}
