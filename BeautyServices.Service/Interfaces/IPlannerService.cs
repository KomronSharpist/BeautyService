using BeautyServices.Domain.Entities;
using BeautyServices.Service.Helpers;

namespace BeautyServices.Service.Interfaces;

public interface IPlannerService
{
    Task<GenericResponce<Planner>> CreateAsync(Workers worker, long plannerId);
    Task<GenericResponce<Planner>> UpdateAsync(Planner cart);
    Task<GenericResponce<Planner>> GetAsync(long plannerId);
    Task<GenericResponce<Planner>> DeleteAsync(long plannerId);
    Task<GenericResponce<List<Planner>>> GetAllAsync(Predicate<Planner> predicate);
}
