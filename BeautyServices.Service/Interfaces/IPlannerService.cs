using BeautyServices.Domain.Entities;
using BeautyServices.Service.Helpers;

namespace BeautyServices.Service.Interfaces;

public interface IPlannerService
{
    Task<GenericResponce<Planner>> CreateAsync(long userId);
    Task<GenericResponce<Planner>> UpdateAsync(Planner cart);
    Task<GenericResponce<Planner>> GetAsync(long userId);
    Task<GenericResponce<List<Planner>>> GetAllAsync(Predicate<Planner> predicate);
    Task<GenericResponce<decimal>> GetTotalPriceAsync(Planner cart);
}
