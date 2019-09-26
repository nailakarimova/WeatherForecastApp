using System;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;



namespace WeatherForecastApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlString = String.Format("https://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=a3f5cd4926414edbf39ba29587ff39ef");
            WebRequest request = WebRequest.Create(urlString);

            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine($"status = {response.StatusCode}");

            string jsonString = null;
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
            }


            City city = JsonConvert.DeserializeObject<City>(jsonString);

            city.CityToArray();
            city.Print();
            Console.ReadKey();
        }
    }
}
