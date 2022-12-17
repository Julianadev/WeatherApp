using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.Clear();
      Console.WriteLine("------------------- Previsão do Tempo ------------------");
      Console.WriteLine("");
      Console.WriteLine("Digite o nome da cidade: \n");

      string city = Console.ReadLine().ToString().ToUpper();
      Console.WriteLine("");
      string apiKey = "SUA_CHAVE_API"; // Substitua "SUA_CHAVE_API" pela sua chave da API do OpenWeatherMap
      string units = "metric"; // Usar "metric" para obter as temperaturas em graus Celsius
      string lang = "pt";

      // Montar a URL da solicitação
      string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units={units}&appid={apiKey}&lang={lang}";

      // Fazer a solicitação à API
      WebClient client = new WebClient();
      string response = client.DownloadString(url);

      // Passar a resposta JSON
      JObject weatherData = JObject.Parse(response);
      string weatherDescription = (string)weatherData["weather"][0]["description"];
      double temperature = (double)weatherData["main"]["temp"];
      double humidity = (double)weatherData["main"]["humidity"];


      // Exibir a previsão do tempo
      Console.WriteLine($"Previsão do tempo para {city}: {weatherDescription}\n");
      Console.WriteLine($"Temperatura atual: {temperature:F1}°C\n");
      Console.WriteLine($"Umidade relativa do ar: {humidity}%\n");

    }
  }
}

