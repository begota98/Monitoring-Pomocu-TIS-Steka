using System.Text.Json.Serialization;

namespace API_Showcase.Models;

public class PrimaryCommoditiesData
{
    public DateTime DateTime { get; set; }
    public decimal? CoalAuPrice { get; set; }
    public decimal? CoalAuIndex { get; set; }
    public decimal? NaturalGasUSPrice { get; set; }
    public decimal? NaturalGasUSIndex { get; set; }
    public decimal? NaturalGasEUPrice { get; set; }
    public decimal? NaturalGasEUIndex { get; set; }
    public decimal? BeefPrice { get; set; }
    public decimal? BeefIndex { get; set; }
    public decimal? WheatPrice { get; set; }
    public decimal? WheatIndex { get; set; }
    public decimal? ShrimpPrice { get; set; }
    public decimal? ShrimpIndex { get; set; }

    public List<Point> CreatePoints()
    {
        return
        [
            new Point
            {
                DateTime = DateTime,
                Field = "COAL_AU",
                Value = CoalAuPrice,
                ValueType = "Price"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "COAL_AU",
                Value = CoalAuIndex,
                ValueType = "Index"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "NATURAL_GAS_US",
                Value = NaturalGasUSPrice,
                ValueType = "Price"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "NATURAL_GAS_US",
                Value = NaturalGasUSIndex,
                ValueType = "Index"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "NATURAL_GAS_EU",
                Value = NaturalGasEUPrice,
                ValueType = "Price"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "NATURAL_GAS_EU",
                Value = NaturalGasEUIndex,
                ValueType = "Index"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "BEEF",
                Value = BeefPrice,
                ValueType = "Price"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "BEEF",
                Value = BeefIndex,
                ValueType = "Index"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "WHEAT",
                Value = WheatPrice,
                ValueType = "Price"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "WHEAT",
                Value = WheatIndex,
                ValueType = "Index"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "SHRIMP",
                Value = ShrimpPrice,
                ValueType = "Price"
            },

            new Point
            {
                DateTime = DateTime,
                Field = "SHRIMP",
                Value = ShrimpIndex,
                ValueType = "Index"
            }

        ];
    }
}