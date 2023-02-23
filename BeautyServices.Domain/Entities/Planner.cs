using BeautyServices.Domain.Commons;
using BeautyServices.Domain.Enums;

namespace BeautyServices.Domain.Entities;

public class Planner : Auditable
{
    public long UserId { get; set; }
    public long WorkerId { get; set; }
    public string Description { get; set; }
    public OrderTypes statusType { get; set; } = OrderTypes.planned;
}
