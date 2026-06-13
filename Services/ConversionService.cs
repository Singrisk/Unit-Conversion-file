namespace UnitConversion.Api.Services;

public class ConversionService
{
    private readonly IEnumerable<IUnitConverter> _converters;

    public ConversionService(IEnumerable<IUnitConverter> converters)
    {
        _converters = converters;
    }

    public double Convert(
        double value,
        string fromUnit,
        string toUnit)
    {
        var converter = _converters.FirstOrDefault(c =>
            c.CanConvert(fromUnit, toUnit));

        if (converter is null)
        {
            throw new InvalidOperationException(
                $"Conversion from '{fromUnit}' to '{toUnit}' is not supported.");
        }

        return converter.Convert(value, fromUnit, toUnit);
    }

    public Dictionary<string, IEnumerable<string>> GetUnits()
    {
        return new()
        {
            ["length"] =
                _converters.OfType<LengthConverter>()
                    .First().SupportedUnits,

            ["weight"] =
                _converters.OfType<WeightConverter>()
                    .First().SupportedUnits,

            ["temperature"] =
                _converters.OfType<TemperatureConverter>()
                    .First().SupportedUnits
        };
    }
}