using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MealExplorer.Models;

namespace MealExplorer.Services;

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
    //were pulling name image and id here ONLY <-- !!IMPORTANT (Can add more later if needed prob not
    public async Task<List<MealFilterItem>> GetMealsByIngredientAsync(string ingredient)
    {
        // trim input
        var value = ingredient?.Trim();

        if (string.IsNullOrWhiteSpace(value))
            return new List<MealFilterItem>();

        // build URL parts for the filter to use (?i=)
        var baseUrl = "https://www.themealdb.com/api/json/v1/1/filter.php";
        var encoded = Uri.EscapeDataString(value); // to handle spaces and special chars (&)
        var url = $"{baseUrl}?i={encoded}";

        try
        {
            var response = await http.GetFromJsonAsync<MealFilterResponse>(url);

            // If API rtn null, put empty listo n page.
            return response?.Meals ?? new List<MealFilterItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ingredient search error: {ex.Message}"); //handle search error
            return new List<MealFilterItem>();
        }
    }

    // Get meal details by id
    public async Task<Meal?> GetMealByIdAsync(string id)
    {
        // trim input
        var value = id?.Trim();

        if (string.IsNullOrWhiteSpace(value))
            return null;

        // build URL parts for the filter to use (?i=)
        var baseUrl = "https://www.themealdb.com/api/json/v1/1/lookup.php";
        var encoded = Uri.EscapeDataString(value); // to handle spaces and special chars (&)
        var url = $"{baseUrl}?i={encoded}";

        try
        {
            var response = await http.GetFromJsonAsync<MealResponse>(url);
            return response?.Meals?.FirstOrDefault();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Meal lookup error: {ex.Message}"); //handle error again
            return null;
        }
    }
}
