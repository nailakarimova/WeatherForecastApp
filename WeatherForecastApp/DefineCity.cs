using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastApp
{
    public class DefineCity
    {
        Dictionary<int, string> cities;

        public DefineCity()
        {
            cities = new Dictionary<int, string>(5);
            cities.Add(1, "Baku");
            cities.Add(2, "London");
            cities.Add(3, "Moscow");
            cities.Add(4, "Paris");
            cities.Add(5, "Kyiv");

            foreach (KeyValuePair<int, string> keyValue in cities)
                Console.WriteLine($"{keyValue.Key} - {keyValue.Value}");
        }

        public string SelectedCity()
        {
            return cities[Listen()];
        }
        public int Listen()
        {
            ConsoleKeyInfo keyInfo;
            string index;
            while (true)
            {
                keyInfo = Console.ReadKey();
                Console.WriteLine();
                if (keyInfo.Key >= ConsoleKey.D1 && keyInfo.Key <= ConsoleKey.D5)
                {
                    index = keyInfo.KeyChar.ToString();

                    break;
                }
                else
                {
                    Console.WriteLine("please enter right number");
                    continue;
                }
            }
            return Convert.ToInt32(index);
        }
    }
}
