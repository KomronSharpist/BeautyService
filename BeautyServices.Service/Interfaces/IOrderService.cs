using BeautyServices.Domain.Entities;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;

namespace BeautyServices.Service.Interfaces;

public interface IOrderService
{
    Task<GenericResponce<Orders>> CreateAsync(OrderDTo order);
    Task<GenericResponce<Orders>> DeleteAsync(long id);
    Task<GenericResponce<Orders>> UpdateAsync(long id, OrderDTo order);
    Task<GenericResponce<Orders>> GetAsync(long id);
    Task<GenericResponce<List<Orders>>> GetAllAsync(Predicate<Orders> predicate);
}
