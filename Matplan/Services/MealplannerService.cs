namespace Matplan.Services;

public class MealplannerService : IMealplannerService
{
    private readonly IAuthService _authService;
    public MealplannerService(IAuthService authService)
    {
        _authService = authService;
    }
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://api.spoonacular.com/")
    };
    
    public async Task<string> GetMealPlanForDay()
    {
        string apiKey = AppendApiKey();
        HttpResponseMessage res = await HttpClient.GetAsync($"mealplanner/generate?timeFrame=day{apiKey}");
        var json = await res.Content.ReadAsStringAsync();
        return json;
    }

    private string AppendApiKey()
    {
        string query = $"&apiKey=";
        string key = _authService.GetApiKey();
        return query + key;
    }
}

public interface IMealplannerService
{
    Task<string> GetMealPlanForDay();
}