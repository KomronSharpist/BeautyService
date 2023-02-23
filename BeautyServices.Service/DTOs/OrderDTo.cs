using BeautyServices.Domain.Enums;

namespace BeautyServices.Service.DTOs;

public class OrderDTo
{
    public int UserId { get; set; }
    public int WorkerId { get; set; }
    public string Description { get; set; }
    public OrderTypes StatusType { get; set; }
}
