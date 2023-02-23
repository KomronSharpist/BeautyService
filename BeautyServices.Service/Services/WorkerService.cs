using BeautyServices.Data.GenericRepostories;
using BeautyServices.Data.IGenericRepostories;
using BeautyServices.Domain.Entities;
using BeautyServices.Service.DTOs;
using BeautyServices.Service.Helpers;
using BeautyServices.Service.Interfaces;

namespace BeautyServices.Service.Services;

public class WorkerService : IWorkerService
{
    private readonly IGenericRepostory<Workers> workerRepository;
    public WorkerService()
    {
        workerRepository = new GenericRepostory<Workers>();
    }
    public async Task<GenericResponce<Workers>> CreateAsync(WorkerDTo worker)
    {
        var WorkerCreate = (await workerRepository.GetAllAsync()).FirstOrDefault(c => c.ProfName == worker.ProfName);

        if (WorkerCreate is not null)
        {
            return new GenericResponce<Workers>
            {
                StatusCode = 404,
                Message = "Worker is already created.",
                Value = null
            };
        }

        var NewWorker = new Workers()
        {
            CreatedAt = DateTime.UtcNow,
            Description = worker.Description,
            ProfName = worker.ProfName,
            ProfLastName = worker.ProfLastName,
            Status = worker.Status,
            Job = worker.job,
        };

        var result = await workerRepository.CreateAsync(NewWorker);

        return new GenericResponce<Workers>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = result
        };
    }

    public async Task<GenericResponce<Workers>> DeleteAsync(long id)
    {
        var Worker = (await workerRepository.GetAllAsync()).FirstOrDefault(c => c.Id == id);

        if (Worker is null)
        {
            return new GenericResponce<Workers>
            {
                StatusCode = 404,
                Message = "Worker is not found",
                Value = null
            };
        }

        var result = await workerRepository.DeleteAsync(Worker.Id);

        return new GenericResponce<Workers>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = Worker
        };
    }

    public async Task<GenericResponce<List<Workers>>> GetAllAsync(Predicate<Workers> predicate)
    {
        var Workers = await workerRepository.GetAllAsync(predicate);

        return new GenericResponce<List<Workers>>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = Workers
        };
    }

    public async Task<GenericResponce<Workers>> GetAsync(long id)
    {
        var worker = (await workerRepository.GetAllAsync()).FirstOrDefault(w => w.Id == id);

        if (worker is null)
        {
            return new GenericResponce<Workers>
            {
                StatusCode = 404,
                Message = "Worker is not found",
                Value = null
            };
        }

        return new GenericResponce<Workers>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = worker
        };
    }

    public async Task<GenericResponce<Workers>> UpdateAsync(long id, WorkerDTo worker)
    {
        var workerUpdate = (await workerRepository.GetAllAsync()).FirstOrDefault(w => w.Id == id);

        if (workerUpdate is null)
        {
            return new GenericResponce<Workers>
            {
                StatusCode = 404,
                Message = "Worker is not found",
                Value = null
            };
        }

        workerUpdate.UpdatedAt = DateTime.UtcNow;
        workerUpdate.Status = worker.Status;
        workerUpdate.Description = worker.Description;
        workerUpdate.Job = worker.job;
        workerUpdate.ProfName = worker.ProfName;
        workerUpdate.ProfLastName = worker.ProfLastName;

        var result = await workerRepository.UpdateAsync(workerUpdate);

        return new GenericResponce<Workers>
        {
            StatusCode = 200,
            Message = "Succes",
            Value = result
        };
    }
}
