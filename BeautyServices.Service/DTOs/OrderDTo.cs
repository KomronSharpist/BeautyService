using BeautyServices.Domain.Enums;

namespace BeautyServices.Service.DTOs;

public class OrderDTo
{
    public long UserId { get; set; }
    public long WorkerId { get; set; }
    public string Description { get; set; }
    public OrderTypes StatusType { get; set; }
}
