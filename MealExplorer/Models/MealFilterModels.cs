using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MealExplorer.Models;
    // Response for: filter.php?i=INGREDIENT
    public class MealFilterResponse
    {
        [JsonPropertyName("meals")]
        public List<MealFilterItem>? Meals { get; set; }
    }

    // Each item has only a these fields
    public class MealFilterItem
    {
        [JsonPropertyName("strMeal")]
        public string? Name { get; set; }

        [JsonPropertyName("strMealThumb")]
        public string? Thumbnail { get; set; }

        [JsonPropertyName("idMeal")]
        public string? IdMeal { get; set; }
    }
