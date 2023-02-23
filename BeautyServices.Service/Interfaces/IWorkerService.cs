using BeautyServices.Domain.Entities;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;

namespace BeautyServices.Service.Interfaces;
public interface IWorkerService
{
    Task<GenericResponce<Workers>> CreateAsync(WorkerDTo worker);
    Task<GenericResponce<Workers>> DeleteAsync(long id);
    Task<GenericResponce<Workers>> UpdateAsync(long id, WorkerDTo worker);
    Task<GenericResponce<Workers>> GetAsync(long id);
    Task<GenericResponce<List<Workers>>> GetAllAsync(Predicate<Workers> predicate);
}
