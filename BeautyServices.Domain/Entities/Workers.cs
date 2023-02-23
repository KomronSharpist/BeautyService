using BeautyServices.Domain.Commons;
using BeautyServices.Domain.Enums;

namespace BeautyServices.Domain.Entities;

public class Workers : Auditable
{
    public Jobs Job { get; set; } 
    public string Description { get; set; }
    public string ProfName { get; set; }
    public string ProfLastName { get; set; }
    public WorkerStatusTypes Status { get; set; } = WorkerStatusTypes.working;
    public string Price { get; set; }
}
