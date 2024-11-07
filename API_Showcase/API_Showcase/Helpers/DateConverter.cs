using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace API_Showcase.Helpers;

public class DateConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        var stringSplit = text.Split("M");
        return new DateTime(int.Parse(stringSplit[0]), int.Parse(stringSplit[1]), 15).ToUniversalTime();
    }
}