namespace UnitConversion.Api.Services;

public class LengthConverter : IUnitConverter
{
    private readonly Dictionary<string, double> _units =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["meter"] = 1,
            ["kilometer"] = 1000,
            ["foot"] = 0.3048,
            ["inch"] = 0.0254
        };

    public IEnumerable<string> SupportedUnits => _units.Keys;

    public bool CanConvert(string fromUnit, string toUnit)
    {
        return _units.ContainsKey(fromUnit) &&
               _units.ContainsKey(toUnit);
    }

    public double Convert(double value, string fromUnit, string toUnit)
    {
        double meters = value * _units[fromUnit];

        return meters / _units[toUnit];
    }
}