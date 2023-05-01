using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;

public class CmdServiceHttpClient : ICmdServiceHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly CommandService _cmdServiceConfig;


    public CmdServiceHttpClient(HttpClient httpClient, IOptions<CommandService> cmdServiceConfigOptions)
    {
        _httpClient = httpClient;
        _cmdServiceConfig = cmdServiceConfigOptions.Value;
    }

    public async Task SendNewPlatformAsync(PlatformReadDto newPlatform)
    {
        Console.WriteLine("Send HTTP Post msg to command service");
        var httpContent = new StringContent(
            JsonSerializer.Serialize(newPlatform),
            Encoding.UTF8,
            "application/json");
        try
        {
            Console.WriteLine($"CMD Service URI : {_cmdServiceConfig.BaseURI}/api/cmdsvc/platform");
            var response = await _httpClient.PostAsync($"{_cmdServiceConfig.BaseURI}/api/cmdsvc/platform", httpContent);

            if (response.IsSuccessStatusCode)
                Console.WriteLine($"HTTP Req --> CMD Service: Success. New Platform {newPlatform.Name} has beed updated to Command Service");
            else
                Console.WriteLine($"HTTP Req --> CMD Service: Failed. Could not Update command service about the {newPlatform.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("HTTP Req --> CMD Service: Failed " + ex.Message);
        }
    }
}