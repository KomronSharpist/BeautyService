using BeautyServices.Data.GenericRepostories;
using BeautyServices.Data.IGenericRepostories;
using BeautyServices.Domain.Entities;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;
using BeautyServices.Service.Interfaces;

namespace BeautyServices.Service.Services;

public class OrderService : IOrderService
{
    private readonly IGenericRepostory<Orders> ordersRepository;
    public OrderService()
    {
        ordersRepository = new GenericRepostory<Orders>();
    }
    public async Task<GenericResponce<Orders>> CreateAsync(OrderDTo order, long orderId)
    {
        var orderCreate = (await ordersRepository.GetAllAsync()).FirstOrDefault(o => o.Id == orderId);
        if (orderCreate is not null)
        {
            return new GenericResponce<Orders>()
            {
                StatusCode = 404,
                Message = "Order is already exist",
                Value = null
            };
        }

        var result = await ordersRepository.CreateAsync(orderCreate);

        return new GenericResponce<Orders>()
        {
            StatusCode = 200,
            Message = "Succes",
            Value = result
        };
    }

    public async Task<GenericResponce<Orders>> DeleteAsync(long id)
    {
        var order = (await ordersRepository.GetAllAsync()).FirstOrDefault(o => o.Id == id);
        if (order is null)
        {
            return new GenericResponce<Orders>()
            {
                StatusCode = 404,
                Message = "Order is not found",
                Value = null
            };
        }

        var result = await ordersRepository.DeleteAsync(id);

        return new GenericResponce<Orders>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = order
        };
    }

    public async Task<GenericResponce<List<Orders>>> GetAllAsync(Predicate<Orders> predicate)
    {
        var orders = await ordersRepository.GetAllAsync(predicate);

        return new GenericResponce<List<Orders>>()
        {
            StatusCode = 200,
            Message = "Succes",
            Value = orders
        };
    }

    public async Task<GenericResponce<Orders>> GetAsync(long id)
    {
        var order = (await ordersRepository.GetAllAsync()).FirstOrDefault(o => o.Id == id);
        if (order is null)
        {
            return new GenericResponce<Orders>()
            {
                StatusCode = 404,
                Message = "Order is not found",
                Value = null
            };
        }

        return new GenericResponce<Orders>()
        {
            StatusCode = 200,
            Message = "Succes",
            Value = order
        };
    }

    public async Task<GenericResponce<Orders>> UpdateAsync(long id, OrderDTo order)
    {
        var orderUpdate = (await ordersRepository.GetAllAsync()).FirstOrDefault(o => o.Id == id);
        if (orderUpdate is null)
        {
            return new GenericResponce<Orders>()
            {
                StatusCode = 404,
                Message = "Order is not found",
                Value = null
            };
        }

        orderUpdate.UpdatedAt = DateTime.UtcNow;
        orderUpdate.Description = order.Description;
        orderUpdate.StatusType = order.StatusType;
        orderUpdate.UserId = order.UserId;
        orderUpdate.WorkerId = order.WorkerId;

        var result = await ordersRepository.UpdateAsync(orderUpdate);

        return new GenericResponce<Orders>()
        {
            StatusCode = 200,
            Message = "Succes",
            Value = orderUpdate
        };
    }
}
