using AutoGestor360App.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AutoGestor360App.Services;

public interface IRegisterService
{
    Task<bool> ExistsRegister();
    Task<int> GetIndex();
    Task<IEnumerable<Register>> GetRegisters();
    Task<bool> UpsertRegister(Register register);
}

public class RegisterService : IRegisterService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseApiUrl = "http://localhost:5000";

    public RegisterService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<IEnumerable<Register>> GetRegisters()
    {
        var response = await _httpClient.GetAsync($"{_baseApiUrl}/Register");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var registers = JsonSerializer.Deserialize<IEnumerable<Register>>(content);

        return registers ?? Enumerable.Empty<Register>();
    }

    public async Task<bool> UpsertRegister(Register register)
    {
        var registerJson = JsonSerializer.Serialize(register, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        });
        //var content = new StringContent(registerJson, Encoding.UTF8, "application/json");
        var content = new StringContent(registerJson,MediaTypeHeaderValue.Parse("application/json"));

        var response = await _httpClient.PostAsync($"{_baseApiUrl}/Register", content);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ExistsRegister() => (await GetRegisters()).Any();

    public async Task<int> GetIndex()
    {
        int resul = 1;
        if (await ExistsRegister())
        {
            string lastId = (await GetRegisters()).LastOrDefault()!.Id!;
            resul = int.Parse(lastId.Split("-").Last()) + resul;
        }
        return resul;
    }

}