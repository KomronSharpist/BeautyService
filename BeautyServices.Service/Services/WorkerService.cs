using BeautyServices.Domain.Entities;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;
using BeautyServices.Service.Interfaces;

namespace BeautyServices.Service.Services;

public class WorkerService : IWorkerService
{
    public Task<GenericResponce<Workers>> CreateAsync(WorkerDTo order)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<Workers>> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<List<Workers>>> GetAllAsync(Predicate<Workers> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<Workers>> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<Workers>> UpdateAsync(long id, WorkerDTo order)
    {
        throw new NotImplementedException();
    }

    public Task<GenericResponce<Workers>> UpdateToNextProcessAsync(long id)
    {
        throw new NotImplementedException();
    }
}
