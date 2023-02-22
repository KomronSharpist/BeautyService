using BeautyServices.Domain.Entities;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;
using BeautyServices.Service.Interfaces;

namespace BeautyServices.Service.Services;

public class OrderService : IOrderService
{
    public Task<GenericResponce<Orders>> CreateAsync(OrderDTo order)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<Orders>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<List<Orders>>> GetAllAsync(Predicate<Orders> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<Orders>> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<Orders>> UpdateAsync(long id, OrderDTo order)
    {
        throw new NotImplementedException();
    }
}
