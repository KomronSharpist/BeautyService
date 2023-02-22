using BeautyServices.Domain.Commons;

namespace BeautyServices.Domain.Entities;

public class Orders : Auditable
{
    public int UserId { get; set; }
    public int WorkerId { get; set; }
    public string Description { get; set; }
    public OrderStatusType StatusType { get; set; }
}
