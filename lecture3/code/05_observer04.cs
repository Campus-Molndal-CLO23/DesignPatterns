/*
    Exempel på event i C#.
    Som liknar observer-mönstret, men är mycket långsammare, 
    tyngre och mindre flexibelt.
*/
using System;

// Delegate som definierar signaturen för eventhanteraren
public delegate void WeatherChangedEventHandler(object sender, WeatherChangedEventArgs e);

// Klass för att hålla eventdata
public class WeatherChangedEventArgs : EventArgs
{
    public float Temperature { get; }
    public float Humidity { get; }
    public float Pressure { get; }

    public WeatherChangedEventArgs(float temperature, float humidity, float pressure)
    {
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;
    }
}

// Klass som representerar en väderstation
public class WeatherStation
{
    // Event som triggas när vädret ändras
    public event WeatherChangedEventHandler WeatherChanged;

    private float _temperature;
    private float _humidity;
    private float _pressure;

    // Metod för att uppdatera väderdata och trigga eventet
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        OnWeatherChanged(new WeatherChangedEventArgs(temperature, humidity, pressure));
    }

    // Metod för att trigga WeatherChanged eventet
    protected virtual void OnWeatherChanged(WeatherChangedEventArgs e)
    {
        WeatherChanged?.Invoke(this, e);
    }
}

// Klass som representerar en skärm som visar väderdata
public class WeatherDisplay
{
    private string _name;

    public WeatherDisplay(string name, WeatherStation weatherStation)
    {
        _name = name;
        // Prenumerera på WeatherChanged eventet
        weatherStation.WeatherChanged += Update;
    }

    // Eventhanterare som uppdaterar skärmen när vädret ändras
    public void Update(object sender, WeatherChangedEventArgs e)
    {
        Console.WriteLine($"{_name} - Temperature: {e.Temperature}, Humidity: {e.Humidity}, Pressure: {e.Pressure}");
    }
}

// Programklass för att demonstrera väderstationen med events och delegates
class Program
{
    static void Main()
    {
        WeatherStation weatherStation = new WeatherStation();

        WeatherDisplay currentConditionsDisplay = new WeatherDisplay("Current Conditions", weatherStation);
        WeatherDisplay statisticsDisplay = new WeatherDisplay("Statistics", weatherStation);

        // Uppdatera väderdata och trigga eventet
        weatherStation.SetMeasurements(25.0f, 65.0f, 1013.0f);
        weatherStation.SetMeasurements(22.0f, 70.0f, 1012.0f);

        // Ytterligare en skärm kan läggas till dynamiskt
        WeatherDisplay forecastDisplay = new WeatherDisplay("Forecast", weatherStation);
        weatherStation.SetMeasurements(21.0f, 90.0f, 1011.0f);
    }
}
