public enum TempUnits
{
    FahrenheitToCelsius,
    CelsiusToFahrenheit,
    KelvinToCelsius,
    CelsiusToKelvin,
    FahrenheitToKelvin,
    KelvinToFahrenheit,
    IfEqual
};
public class TemperatureConverter
{
    internal static object ConvertTemperature()
    {
        throw new NotImplementedException();
    }

    public double ConvertTemperature(double value, TempUnits conversionType)
    {
        switch (conversionType)
        {
            case TempUnits.FahrenheitToCelsius:
                return (value - 32) * 5 / 9;
            case TempUnits.CelsiusToFahrenheit:
                return (value * 9 / 5) + 32;
            case TempUnits.KelvinToCelsius:
                return value - 273.15;
            case TempUnits.CelsiusToKelvin:
                return value + 273.15;
            case TempUnits.FahrenheitToKelvin:
                return (value - 32) * 5 / 9 + 273.15;
            case TempUnits.KelvinToFahrenheit:
                return (value - 273.15) * 9 / 5 + 32;
            default:
                throw new ArgumentException("Invalid conversion type");
        }
    }
}
