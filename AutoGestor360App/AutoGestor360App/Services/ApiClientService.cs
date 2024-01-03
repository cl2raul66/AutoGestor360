using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AutoGestor360App.Services;

public interface IApiClientService
{
    string GetServerUrl { get; }

    HttpClient Current();
    Task<bool> SetUrl([Url] string url);
    Task<bool> Test([Url] string? url = null);
}

public class ApiClientService : IApiClientService
{
    readonly string key = "DAF8294687914F7DBBB2D788A6094F00";
    readonly HttpClient httpClient;

    public ApiClientService()
    {
        httpClient = new();
    }

    public async Task<bool> SetUrl([Url] string url)
    {
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return false;
        }
        bool hasResponse = await Test(url);

        if (hasResponse)
        {
            Preferences.Default.Set(key, url);
            return !string.IsNullOrEmpty(Preferences.Default.Get(key, string.Empty));
        }
        return hasResponse;
    }

    public string GetServerUrl
    {
        get
        {
            return Preferences.Default.Get(key, string.Empty);
        }
    }

    public HttpClient Current() => httpClient;

    public async Task<bool> Test([Url] string? url = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            url = Preferences.Default.Get(key, string.Empty);
        }
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return false;
        }
        Uri uriHost = new(url);
        bool hasResponse = false;
        try
        {
            var response = await httpClient.GetAsync(new Uri(uriHost, "healthchecks"));
            hasResponse = response.StatusCode switch
            {
                HttpStatusCode.OK => true,
                _ => false
            };
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"No se pudo conectar al servidor: {ex.Message}");
            return hasResponse;
        }
        return hasResponse;
    }
}
