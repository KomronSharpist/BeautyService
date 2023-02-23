using BeautyServices.Domain.Enums;

namespace BeautyServices.Service.DTOs;

public class WorkerDTo
{
    public Jobs job { get; set; }
    public string Description { get; set; }
    public string ProfName { get; set; }
    public string ProfLastName { get; set; }
    public WorkerStatusTypes Status { get; set; } = WorkerStatusTypes.idler;
    public string Price { get; set; }
}
