using AutoGestor360App.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AutoGestor360App.Services;

public interface IRegisterService
{
    Task<bool> DeleteRegister(string id);
    Task<int> GetNewIndex();
    Task<Register?> GetRegister(string id);
    Task<IEnumerable<Register>> GetRegisters();
    Task<bool> RegisterExistsAsync();
    Task<bool> UpsertRegister(Register register);
}

public class RegisterService : IRegisterService
{
    readonly IApiClientService apiClientServ;
    readonly HttpClient _httpClient;
    readonly string serverUrl;
    readonly JsonSerializerOptions jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public RegisterService(IApiClientService apiClientService)
    {
        apiClientServ = apiClientService;
        _httpClient = apiClientServ.Current();
        serverUrl = apiClientServ.GetServerUrl;
    }

    public async Task<bool> RegisterExistsAsync()
    {
        var response = await _httpClient.GetAsync($"{serverUrl}/Register/exist");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return bool.Parse(content);
    }

    public async Task<IEnumerable<Register>> GetRegisters()
    {
        var response = await _httpClient.GetAsync($"{serverUrl}/{nameof(Register)}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var registers = JsonSerializer.Deserialize<IEnumerable<Register>>(content, jsonOptions);
        return registers ?? Enumerable.Empty<Register>();
    }

    public async Task<Register?> GetRegister(string id)
    {
        var response = await _httpClient.GetAsync($"{serverUrl}/{nameof(Register)}/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Register>(content, jsonOptions);
    }

    public async Task<bool> UpsertRegister(Register register)
    {
        var registerJson = JsonSerializer.Serialize(register, jsonOptions);
        var content = new StringContent(registerJson, MediaTypeHeaderValue.Parse("application/json"));
        var response = await _httpClient.PostAsync($"{serverUrl}/{nameof(Register)}", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteRegister(string id)
    {
        var response = await _httpClient.DeleteAsync($"{serverUrl}/{nameof(Register)}/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<int> GetNewIndex()
    {
        var response = await _httpClient.GetAsync($"{serverUrl}/Register/getnewindex");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return int.Parse(content);
    }
}