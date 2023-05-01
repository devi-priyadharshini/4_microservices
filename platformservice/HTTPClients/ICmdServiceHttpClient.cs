
/// HTTPClient for making a SYNC call to Command Microservice
public interface ICmdServiceHttpClient
{
  public Task SendNewPlatformAsync(PlatformReadDto newPlatform);
}