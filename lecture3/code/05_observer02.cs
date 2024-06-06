using System;
using System.Collections.Generic;

// Gränssnitt för observatörer
public interface IWeatherObserver
{
    void Update(float temperature, float humidity, float pressure);
}

// Konkret observatör för att visa väderdata
public class WeatherDisplay : IWeatherObserver
{
    private string _name;

    public WeatherDisplay(string name)
    {
        _name = name;
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        Console.WriteLine($"{_name} - Temperature: {temperature}, Humidity: {humidity}, Pressure: {pressure}");
    }
}

// Gränssnitt för ämnet
public interface IWeatherStation
{
    void RegisterObserver(IWeatherObserver observer);
    void RemoveObserver(IWeatherObserver observer);
    void NotifyObservers();
}

// Konkret ämne
public class WeatherStation : IWeatherStation
{
    private List<IWeatherObserver> _observers = new List<IWeatherObserver>();
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public void RegisterObserver(IWeatherObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IWeatherObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature, _humidity, _pressure);
        }
    }

    // Metoder för att uppdatera väderdata
    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        NotifyObservers();
    }
}

// Programklass för att demonstrera väderstationen
class Program
{
    static void Main()
    {
        WeatherStation weatherStation = new WeatherStation();

        WeatherDisplay currentConditionsDisplay = new WeatherDisplay("Current Conditions");
        WeatherDisplay statisticsDisplay = new WeatherDisplay("Statistics");

        weatherStation.RegisterObserver(currentConditionsDisplay);
        weatherStation.RegisterObserver(statisticsDisplay);

        weatherStation.SetMeasurements(25.0f, 65.0f, 1013.0f);
        weatherStation.SetMeasurements(22.0f, 70.0f, 1012.0f);

        weatherStation.RemoveObserver(statisticsDisplay);

        weatherStation.SetMeasurements(21.0f, 90.0f, 1011.0f);
    }
}
