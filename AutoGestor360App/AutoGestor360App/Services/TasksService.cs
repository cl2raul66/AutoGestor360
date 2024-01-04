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
        if (work is null)
        {
            return false;
        }

        var worksJson = Preferences.Get(key, string.Empty);
        List<Work>? works = string.IsNullOrEmpty(worksJson) ? new() : JsonSerializer.Deserialize<List<Work>>(worksJson, jsonOptions);

        works!.RemoveAll(x => x.Name == work.Name);
        works.Add(work);

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
        if (string.IsNullOrEmpty(worksJson))
        {
            return false;
        }
        var works = JsonSerializer.Deserialize<List<Work>>(worksJson, jsonOptions);
        if (works!.RemoveAll(x => x.Name == name) > 0)
        {
            var serializeWorks = JsonSerializer.Serialize(works, jsonOptions);
            Preferences.Set(key, serializeWorks);
            return true;
        }
        return false;
    }
}
