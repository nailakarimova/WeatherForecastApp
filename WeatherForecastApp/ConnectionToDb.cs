using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace WeatherForecastApp
{
    class ConnectionToDb
    {
        private NpgsqlConnection conn;
        public ConnectionToDb()
        {
            try
            {
                conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=123456; Database=weather_forecast;");
                conn.Open();
                
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Insert(string cityName, double wind_speed, double temperature, int pressure, int clouds)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO weather (id_country, id_city, wind_speed, temperature, pressure, clouds, req_time)" +
                                                      $"VALUES ((select cn.id_country from countries cn join cities c on cn.id_country = c.id_country where city_name = '{cityName}')," +
                                                      $"(select c.id_city from cities c join countries cn on c.id_country = cn.id_country where city_name = '{cityName}')," +
                                                      $"{wind_speed}, {temperature}, {pressure}, {clouds}, now()::timestamp);", conn);
            Console.WriteLine(command);
            command.ExecuteNonQuery();
            
            conn.Close();
        }
    }
}

