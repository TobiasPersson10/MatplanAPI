using Matplan.Services;
using Microsoft.AspNetCore.Mvc;

namespace Matplan.Controllers;

[ApiController]
[Route("[controller]")]
public class MealplannerController : ControllerBase
{
    private readonly IMealplannerService _mealplanner;

    public MealplannerController(IMealplannerService mealplanner)
    {
        _mealplanner = mealplanner;
    }

    [HttpGet]
    public async Task<IActionResult> GenerateMealPlanForDay()
    {
        var response = await _mealplanner.GetMealPlanForDay();
        
        return Ok(response);
    }
}