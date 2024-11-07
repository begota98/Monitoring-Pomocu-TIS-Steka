using API_Showcase.Models;

namespace API_Showcase.Services;

public interface ITelegrafService
{
    Task SendDataAsync(PrimaryCommoditiesData primaryCommoditiesData);
    Task SendCsvDataAsync(IFormFile file);
}