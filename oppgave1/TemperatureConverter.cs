

public class TemperatureConverter
{
    private const string celsius = "Celsius";
    private const string fahrenheit = "Fahrenheit";
    private const string kelvin = "Kelvin";
    public double ConvertTemperature(double temperature, string fromunits, string tounits)
    {
        switch (fromunits, tounits) 
        {
            case (fahrenheit, celsius):
                return (temperature - 32) * 5 / 9;
            case (fahrenheit, kelvin):
                return (temperature - 32) * 5 / 9 + 273.15;
                
            case (celsius, kelvin):
                return temperature + 273.15;                
            case (celsius, fahrenheit):
                return (temperature * 9 / 5) + 32;

            case (kelvin, celsius):
                return temperature - 273.15;               
            case (kelvin, fahrenheit):
                return (temperature - 273.15) * 9 / 5 + 32;
            
            case var _ when fromunits == tounits:
                return temperature;
            default:
                throw new ArgumentException("Invalid conversion type");
        }
    }
}