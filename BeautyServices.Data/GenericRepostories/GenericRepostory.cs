using BeautyServices.Data.DataBasePaths;
using BeautyServices.Data.IGenericRepostories;
using BeautyServices.Domain.Commons;
using BeautyServices.Domain.Entities;
using Newtonsoft.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace BeautyServices.Data.GenericRepostories;

public class GenericRepostory<TEntity> : IGenericRepostory<TEntity> where TEntity : Auditable
{
    private string Path;
    private long lastID = 1;

    public GenericRepostory()
    {
        Start();
    }

    private async void Start()
    {
        if (typeof(TEntity) == typeof(User))
            Path = DataBasePath.UsersDBPath;
        else if (typeof(TEntity) == typeof(Workers))
            Path = DataBasePath.WorkersDBPath;
        else if (typeof(TEntity) == typeof(Orders))
            Path = DataBasePath.ordersDBPath;
        else if (typeof(TEntity) == typeof(Planner))
            Path = DataBasePath.plannedDBPath;

        foreach (var model in await GetAllAsync())
            if (model.Id > lastID)
                lastID = model.Id;
    }
    public async Task<TEntity> CreateAsync(TEntity model)
    {
        model.Id = ++lastID;
        var models = await GetAllAsync();
        models.Add(model);

        File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));

        return model;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var models = await GetAllAsync();
        var model = models.FirstOrDefault(m => m.Id == id);

        if (model is null)
        {
            return false;
        }
        
        models.Remove(model);
        File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));

        return true;
    }

    public async Task<List<TEntity>> GetAllAsync(Predicate<TEntity> predicate = null)
    {
        string models = File.ReadAllText(Path);

        if (string.IsNullOrEmpty(models))
        {
            models = "[]";
        }

        var result = JsonConvert.DeserializeObject<List<TEntity>>(models);

        if (predicate is null)
        {
            return result;
        }

        return result.FindAll(predicate);
    }

    public async Task<TEntity> GetAsync(long id)
    {
        return (await GetAllAsync(m => m.Id == id)).FirstOrDefault();
    }

    public async Task<TEntity> UpdateAsync(TEntity model)
    {
        var models = await GetAllAsync();
        var modelUPDATE = models.FirstOrDefault(x => x.Id == model.Id);

        if (modelUPDATE is null)
            return null;

        int index = models.IndexOf(modelUPDATE);
        models.Remove(modelUPDATE);
        model.UpdatedAt = DateTime.UtcNow;
        models.Insert(index, model);

        File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));
        return model;
    }
}
