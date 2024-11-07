using API_Showcase.Models;
using API_Showcase.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Showcase.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DataController : ControllerBase
{
    private readonly ITelegrafService _telegrafService;
    public DataController(ITelegrafService telegrafService)
    {
        _telegrafService = telegrafService;
    }
    
    [HttpPost]
    public async Task<IActionResult> SendData([FromBody] PrimaryCommoditiesData primaryCommoditiesData)
    {
        await this._telegrafService.SendDataAsync(primaryCommoditiesData);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> SendCsvData(IFormFile file)
    {
        await this._telegrafService.SendCsvDataAsync(file);
        return Ok();
    }
}