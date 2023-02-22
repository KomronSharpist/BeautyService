using BeautyServices.Domain.Commons;

namespace BeautyServices.Domain.Entities;

public class Planner : Auditable
{
    public int UserId { get; set; }
    public int WorkerId { get; set; }
    public string Description { get; set; }
    public OrderStatusType statusType { get; set; }
    public List<Worker> Items { get; set; }
}
