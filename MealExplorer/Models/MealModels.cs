using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MealExplorer.Models
{ 
    public class MealResponse
    {
        [JsonPropertyName("meals")]
        public List<Meal>? Meals { get; set; }
    }

    public class Meal
    {
        [JsonPropertyName("idMeal")]
        public string? IdMeal { get; set; }

        [JsonPropertyName("strMeal")]
        public string? Name { get; set; }

        [JsonPropertyName("strCategory")]
        public string? Category { get; set; }

        [JsonPropertyName("strArea")]
        public string? Area { get; set; }

        [JsonPropertyName("strInstructions")]
        public string? Instructions { get; set; }

        [JsonPropertyName("strMealThumb")]
        public string? Thumbnail { get; set; }

        [JsonPropertyName("strYoutube")]
        public string? Youtube { get; set; }

        // Ingredients & Measures (1 - 20) seperate
        // this isnt very effective but not sure any way round it
        [JsonPropertyName("strIngredient1")] public string? StrIngredient1 { get; set; }
        [JsonPropertyName("strIngredient2")] public string? StrIngredient2 { get; set; }
        [JsonPropertyName("strIngredient3")] public string? StrIngredient3 { get; set; }
        [JsonPropertyName("strIngredient4")] public string? StrIngredient4 { get; set; }
        [JsonPropertyName("strIngredient5")] public string? StrIngredient5 { get; set; }
        [JsonPropertyName("strIngredient6")] public string? StrIngredient6 { get; set; }
        [JsonPropertyName("strIngredient7")] public string? StrIngredient7 { get; set; }
        [JsonPropertyName("strIngredient8")] public string? StrIngredient8 { get; set; }
        [JsonPropertyName("strIngredient9")] public string? StrIngredient9 { get; set; }
        [JsonPropertyName("strIngredient10")] public string? StrIngredient10 { get; set; }
        [JsonPropertyName("strIngredient11")] public string? StrIngredient11 { get; set; }
        [JsonPropertyName("strIngredient12")] public string? StrIngredient12 { get; set; }
        [JsonPropertyName("strIngredient13")] public string? StrIngredient13 { get; set; }
        [JsonPropertyName("strIngredient14")] public string? StrIngredient14 { get; set; }
        [JsonPropertyName("strIngredient15")] public string? StrIngredient15 { get; set; }
        [JsonPropertyName("strIngredient16")] public string? StrIngredient16 { get; set; }
        [JsonPropertyName("strIngredient17")] public string? StrIngredient17 { get; set; }
        [JsonPropertyName("strIngredient18")] public string? StrIngredient18 { get; set; }
        [JsonPropertyName("strIngredient19")] public string? StrIngredient19 { get; set; }
        [JsonPropertyName("strIngredient20")] public string? StrIngredient20 { get; set; }

        [JsonPropertyName("strMeasure1")] public string? StrMeasure1 { get; set; }
        [JsonPropertyName("strMeasure2")] public string? StrMeasure2 { get; set; }
        [JsonPropertyName("strMeasure3")] public string? StrMeasure3 { get; set; }
        [JsonPropertyName("strMeasure4")] public string? StrMeasure4 { get; set; }
        [JsonPropertyName("strMeasure5")] public string? StrMeasure5 { get; set; }
        [JsonPropertyName("strMeasure6")] public string? StrMeasure6 { get; set; }
        [JsonPropertyName("strMeasure7")] public string? StrMeasure7 { get; set; }
        [JsonPropertyName("strMeasure8")] public string? StrMeasure8 { get; set; }
        [JsonPropertyName("strMeasure9")] public string? StrMeasure9 { get; set; }
        [JsonPropertyName("strMeasure10")] public string? StrMeasure10 { get; set; }
        [JsonPropertyName("strMeasure11")] public string? StrMeasure11 { get; set; }
        [JsonPropertyName("strMeasure12")] public string? StrMeasure12 { get; set; }
        [JsonPropertyName("strMeasure13")] public string? StrMeasure13 { get; set; }
        [JsonPropertyName("strMeasure14")] public string? StrMeasure14 { get; set; }
        [JsonPropertyName("strMeasure15")] public string? StrMeasure15 { get; set; }
        [JsonPropertyName("strMeasure16")] public string? StrMeasure16 { get; set; }
        [JsonPropertyName("strMeasure17")] public string? StrMeasure17 { get; set; }
        [JsonPropertyName("strMeasure18")] public string? StrMeasure18 { get; set; }
        [JsonPropertyName("strMeasure19")] public string? StrMeasure19 { get; set; }
        [JsonPropertyName("strMeasure20")] public string? StrMeasure20 { get; set; }

        public List<(string Ingredient, string Measure)> GetIngredients()
        {
            var ingredients = new List<(string Ingredient, string Measure)>();

            for (int index = 1; index <= 20; index++)
            {
                // Geting PropertyInfo 
                var ingredientProperty = GetType().GetProperty($"StrIngredient{index}");
                var measureProperty = GetType().GetProperty($"StrMeasure{index}");

                // Geting string from Meal 
                var ingredientValue = (string?)ingredientProperty?.GetValue(this);
                var measureValue = (string?)measureProperty?.GetValue(this);

                if (!string.IsNullOrWhiteSpace(ingredientValue))
                {
                    ingredients.Add((
                        ingredientValue.Trim(),
                        string.IsNullOrWhiteSpace(measureValue) ? "" : measureValue!.Trim()
                    ));
                }
            }

            return ingredients;
        }
    }
}