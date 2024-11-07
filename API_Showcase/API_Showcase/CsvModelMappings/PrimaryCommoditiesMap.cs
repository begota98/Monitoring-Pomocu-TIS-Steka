using API_Showcase.Helpers;
using API_Showcase.Models;
using CsvHelper.Configuration;

namespace API_Showcase.CsvModelMappings;

public class PrimaryCommoditiesMap : ClassMap<PrimaryCommoditiesData>
{
    public PrimaryCommoditiesMap()
    {
        Map(x => x.DateTime).Name("Date").TypeConverter<DateConverter>();
        Map(x => x.CoalAuPrice).Name("Coal Australia price");
        Map(x => x.CoalAuIndex).Name("Coal Australia Index");
        Map(x => x.NaturalGasUSPrice).Name("Natural Gas US price");
        Map(x => x.NaturalGasUSIndex).Name("Natural Gas US Index");
        Map(x => x.NaturalGasEUPrice).Name("Natural gas EU price");
        Map(x => x.NaturalGasEUIndex).Name("Natural gas EU Index");
        Map(x => x.BeefPrice).Name("Beef price");
        Map(x => x.BeefIndex).Name("Beef Index");
        Map(x => x.WheatPrice).Name("Wheat price");
        Map(x => x.WheatIndex).Name("Wheat Index");
        Map(x => x.ShrimpPrice).Name("Shrimp price");
        Map(x => x.ShrimpIndex).Name("Shrimp Index");
    }
}