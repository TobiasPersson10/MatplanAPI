namespace Matplan.Services;

public class AuthService(IConfiguration config) : IAuthService
{
    public string GetApiKey()
    {
        return config["ApiKey"] ?? throw new ArgumentNullException($"Cant find API Key in configuration");
    }
}

public interface IAuthService
{
    string GetApiKey();
}