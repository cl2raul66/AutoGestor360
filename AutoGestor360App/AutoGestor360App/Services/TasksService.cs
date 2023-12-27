using AutoGestor360App.Models;
using System.Text.Json;

namespace AutoGestor360App.Services;

public interface ITasksService
{
    bool Delete(string name);
    IEnumerable<Work>? GetAll();
    bool Upsert(Work work);
}

public class TasksService : ITasksService
{
    readonly string key = "4E9A50AD51604EF7B5B4666025EED31C";
    readonly JsonSerializerOptions jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public bool Upsert(Work work)
    {
        var worksJson = Preferences.Get(key, string.Empty);
        var works = JsonSerializer.Deserialize<List<Work>>(worksJson, jsonOptions);
        if (work is null || works is null)
        {
            return false;
        }
        if (works!.FirstOrDefault(x => x.Name == work.Name) is not null)
        {
            var copyWorks = works.Where(x => x.Name == work.Name).ToList();
            works = copyWorks;
        }
        works!.Add(work);
        var serializeWorks = JsonSerializer.Serialize(works, jsonOptions);
        Preferences.Set(key, serializeWorks);
        return true;
    }

    public IEnumerable<Work>? GetAll()
    {
        var worksJson = Preferences.Get(key, string.Empty);
        if (!string.IsNullOrEmpty(worksJson))
        {
            return JsonSerializer.Deserialize<IEnumerable<Work>>(worksJson, jsonOptions)!;
        }
        return null;
    }

    public bool Delete(string name)
    {
        var worksJson = Preferences.Get(key, string.Empty);
        var works = JsonSerializer.Deserialize<List<Work>>(worksJson, jsonOptions);
        if (works?.FirstOrDefault(x => x.Name == name) is null)
        {
            return false;
        }
        var copyWorks = works.Where(x => x.Name == name).ToList();
        works = copyWorks;
        return true;
    }
}
