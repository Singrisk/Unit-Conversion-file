namespace UnitConversion.Api.Services;

public class WeightConverter : IUnitConverter
{
    private readonly Dictionary<string, double> _units =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["kilogram"] = 1,
            ["gram"] = 0.001,
            ["pound"] = 0.45359237
        };

    public IEnumerable<string> SupportedUnits => _units.Keys;

    public bool CanConvert(string fromUnit, string toUnit)
    {
        return _units.ContainsKey(fromUnit) &&
               _units.ContainsKey(toUnit);
    }

    public double Convert(double value, string fromUnit, string toUnit)
    {
        double kilograms = value * _units[fromUnit];

        return kilograms / _units[toUnit];
    }
}