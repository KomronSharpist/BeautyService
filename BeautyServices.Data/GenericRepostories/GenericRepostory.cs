using BeautyServices.Data.DataBasePaths;
using BeautyServices.Data.IGenericRepostories;
using BeautyServices.Domain.Commons;
using BeautyServices.Domain.Entities;
using System.Xml;

namespace BeautyServices.Data.GenericRepostories;

public class GenericRepostory<TEntity> : IGenericRepostory<TEntity> where TEntity : Auditable
{
    private string Path;
    private long lastID = 0;

    public GenericRepostory()
    {
        // Constructor that sets up the repository
        Start();
    }

    // Private method that initializes the repository
    private async void Start()
    {
        // Determine the file path based on the TEntity type
        if (typeof(TEntity) == typeof(User))
            Path = DataBasePath.UsersDBPath;
        else if (typeof(TEntity) == typeof(Worker))
            Path = DataBasePath.WorkersDBPath;
        else if (typeof(TEntity) == typeof(Order))
            Path = DataBasePath.ordersDBPath;
        else if (typeof(TEntity) == typeof(Planned))
            Path = DataBasePath.plannedDBPath;

        // Load all entities from the file and get the last ID
        foreach (var model in await GetAllAsync())
            if (model.Id > lastID)
                lastID = model.Id;
    }

    // Creates a new entity and saves it to the file
    public async Task<TEntity> CreateAsync(TEntity model)
    {
        // Assign a new ID and add the entity to the list of existing entities
        model.Id = lastID++;
        var models = await GetAllAsync();
        models.Add(model);

        // Write the list of entities to the file
        File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));

        return model;
    }

    // Deletes an entity with the given ID from the file
    public async Task<bool> DeleteAsync(long id)
    {
        // Get all entities and find the one with the given ID
        var models = await GetAllAsync();
        var model = models.FirstOrDefault(m => m.Id == id);

        // If the entity is not found, return false
        if (model is null)
        {
            return false;
        }

        // Remove the entity and write the updated list to the file
        models.Remove(model);
        File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));

        return true;
    }

    // Gets all entities from the file that match the given predicate (or all entities if the predicate is null)
    public async Task<List<TEntity>> GetAllAsync(Predicate<TEntity> predicate = null)
    {
        // Read the list of entities from the file
        string models = File.ReadAllText(Path);

        // If the file is empty or does not exist, return an empty list
        if (string.IsNullOrEmpty(models))
        {
            models = "[]";
        }

        // Deserialize the JSON string into a list of entities
        var result = JsonConvert.DeserializeObject<List<TEntity>>(models);

        // If a predicate is given, filter the list to only include entities that match the predicate
        if (predicate is null)
        {
            return result;
        }

        return result.FindAll(predicate);
    }

    // Gets the entity with the given ID from the file
    public async Task<TEntity> GetAsync(long id)
    {
        return (await GetAllAsync(m => m.Id == id)).FirstOrDefault();
    }

    // Updates an entity with the same ID as the given entity and saves the
    public async Task<TEntity> UpdateAsync(TEntity model)
    {
        var models = await GetAllAsync();
        var modelUPDATE = models.FirstOrDefault(x => x.Id == model.Id);

        if (modelUPDATE is null)
            return null;

        int index = models.IndexOf(modelUPDATE);
        models.Remove(modelUPDATE);
        model.UpdatedAt = DateTime.Now;
        models.Insert(index, model);

        File.WriteAllText(Path, JsonConvert.SerializeObject(models, Formatting.Indented));
        return model;
    }
}
