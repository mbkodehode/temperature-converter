

public class TemperatureConverter
{
    private const string celsius = "Celsius";
    private const string fahrenheit = "Fahrenheit";
    private const string kelvin = "Kelvin";
    public double ConvertTemperature(double temp, string fromunits, string tounits)
    {
        switch (fromunits, tounits) 
        {
            case (fahrenheit, celsius):
                return (temp - 32) * 5 / 9;
            case (fahrenheit, kelvin):
                return (temp - 32) * 5 / 9 + 273.15;
                
            case (celsius, kelvin):
                return temp + 273.15;                
            case (celsius, fahrenheit):
                return (temp * 9 / 5) + 32;

            case (kelvin, celsius):
                return temp - 273.15;               
            case (kelvin, fahrenheit):
                return (temp - 273.15) * 9 / 5 + 32;
            
            case var _ when fromunits == tounits:
                return temp;
            default:
                throw new ArgumentException("Invalid conversion type");
        }
    }
}