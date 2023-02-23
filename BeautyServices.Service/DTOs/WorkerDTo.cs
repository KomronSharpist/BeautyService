using BeautyServices.Domain.Enums;

namespace BeautyServices.Service.DTOs;

public class WorkerDTo
{
    public string Burning { get; set; }
    public string Description { get; set; }
    public string ProfName { get; set; }
    public string ProfLastName { get; set; }
    public WorkerStatusTypes Status { get; set; }
}
