﻿using System;
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
            ConnectionToDb connection = new ConnectionToDb();
     
            string selectedCity = null;
            Console.WriteLine("Please select the city by the corresponding number:");
            DefineCity defineCity = new DefineCity();
           
            selectedCity = defineCity.SelectedCity();
            
            WeatherInfo.root output = getWeather(selectedCity);
            
            connection.Insert(selectedCity, output.wind.speed, output.main.temp, output.main.pressure, output.clouds.all);
            
        }

        public static WeatherInfo.root getWeather(string cityName)
        {
            using (WebClient web = new WebClient())
            {
                string urlString = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&APPID=a3f5cd4926414edbf39ba29587ff39ef";

                var json = web.DownloadString(urlString);

                var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                WeatherInfo.root output = result;
                output.RootToScreen(output);
                return output;
            }
        }


    }
}