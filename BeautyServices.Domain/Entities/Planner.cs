using BeautyServices.Domain.Commons;
using BeautyServices.Domain.Enums;

namespace BeautyServices.Domain.Entities;

public class Planner : Auditable
{
    public int UserId { get; set; }
    public int WorkerId { get; set; }
    public string Description { get; set; }
    public OrderTypes statusType { get; set; }
    public List<Workers> Items { get; set; }
}
