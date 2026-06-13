namespace UnitConversion.Api.Services;

public interface IUnitConverter
{
    bool CanConvert(string fromUnit, string toUnit);
    double Convert(double value, string fromUnit, string toUnit);
    IEnumerable<string> SupportedUnits { get; }
}