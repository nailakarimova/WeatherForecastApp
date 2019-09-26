using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastApp
{
    public class City
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public Sys sys { get; set; }
        public string name { get; set; }

        List<object> list = new List<object>();

        public void CityToArray()
        {
            list.Add(name);
            list.Add(weather);
            list.Add(main.pressure);
            list.Add(main.temp_min);
            list.Add(main.temp_max);
            list.Add(wind.speed);
            list.Add(wind.deg);
            list.Add(sys.country);
        }
        public void Print()
        {
            list.ForEach(Console.WriteLine);
        }
    }
}
