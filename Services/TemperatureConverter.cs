namespace UnitConversion.Api.Services;

public class TemperatureConverter : IUnitConverter
{
    private readonly string[] _units =
    {
        "celsius",
        "fahrenheit",
        "kelvin"
    };

    public IEnumerable<string> SupportedUnits => _units;

    public bool CanConvert(string fromUnit, string toUnit)
    {
        return _units.Contains(fromUnit.ToLower()) &&
               _units.Contains(toUnit.ToLower());
    }

    public double Convert(double value, string fromUnit, string toUnit)
    {
        double celsius = fromUnit.ToLower() switch
        {
            "celsius" => value,
            "fahrenheit" => (value - 32) * 5 / 9,
            "kelvin" => value - 273.15,
            _ => throw new ArgumentException("Invalid unit")
        };

        return toUnit.ToLower() switch
        {
            "celsius" => celsius,
            "fahrenheit" => celsius * 9 / 5 + 32,
            "kelvin" => celsius + 273.15,
            _ => throw new ArgumentException("Invalid unit")
        };
    }
}