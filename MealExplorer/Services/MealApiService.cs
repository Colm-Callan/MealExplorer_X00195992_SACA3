using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MealExplorer.Models;

namespace MealExplorer.Services
{
    public class MealApiService
    {
        private readonly HttpClient http;

        public MealApiService(HttpClient httpClient)
        {
            http = httpClient;
        }

        public async Task<Meal?> GetRandomMealAsync()
        {
            try
            { 
                //example in weather page useful
                var response = await http.GetFromJsonAsync<MealResponse>(
                    "https://www.themealdb.com/api/json/v1/1/random.php");

                if (response?.Meals != null && response.Meals.Count > 0)
                {
                    return response.Meals[0];
                }

                return null;
            }
            catch (HttpRequestException ex) //handle error
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
                return null;
            }
            catch (Exception ex) // heandle unexpected error
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return null;
            }
        }
    }
}