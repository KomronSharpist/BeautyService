using BeautyServices.Domain.Commons;
using BeautyServices.Domain.Enums;

namespace BeautyServices.Domain.Entities;

public class Orders : Auditable
{
    public long UserId { get; set; }
    public long WorkerId { get; set; }
    public string Description { get; set; }
    public OrderTypes StatusType { get; set; } = OrderTypes.ordered;
}
