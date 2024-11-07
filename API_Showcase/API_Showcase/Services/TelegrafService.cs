using System.Globalization;
using System.Text.Json;
using API_Showcase.Constants;
using API_Showcase.CsvModelMappings;
using API_Showcase.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace API_Showcase.Services;

public class TelegrafService : ITelegrafService
{
    private readonly EmqxService _emqxService;
    public TelegrafService(EmqxService emqxService)
    {
        this._emqxService = emqxService;
    }

    public async Task SendDataAsync(PrimaryCommoditiesData primaryCommoditiesData)
    {
        foreach (var point in primaryCommoditiesData.CreatePoints())
        {
            await this._emqxService.PublishMessageAsync(JsonSerializer.SerializeToUtf8Bytes(point), TopicConstants.TELEGRAF);
        }
    }

    public async Task SendCsvDataAsync(IFormFile file)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };
        using (var reader = new StreamReader(file.OpenReadStream()))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<PrimaryCommoditiesMap>();
            var records = csv.GetRecords<PrimaryCommoditiesData>();
            foreach (var record in records)
            {
                foreach (var point in record.CreatePoints())
                {
                    await this._emqxService.PublishMessageAsync(JsonSerializer.SerializeToUtf8Bytes(point), TopicConstants.TELEGRAF);
                }
            }
        }
    }
}