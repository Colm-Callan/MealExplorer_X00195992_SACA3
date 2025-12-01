# Link to my page 
https://colm-callan.github.io/MealExplorer_X00195992_SACA3/

# Meal Explorer
Software Architecture CA3 Blazor App — Colm Callan (X00195992)

## Overview
Meal Explorer is a Blazor Web App that uses the Meal DB API:
- Home page shows a Random Meal, with a button to fetch another random mael
- Meal From Ingredients lets you search by ingredient and open a meals details

API: https://www.themealdb.com/api.php

## Technologies Used
- .NET 8
- Blazor Web App
- Playwright for E2E tests

## Project Structure
- MealExplorer/ — Blazor app
- E2E.Tests/ — Playwright 

## Local setup

1) Clone and restore

git clone (https://github.com/Colm-Callan/MealExplorer_X00195992_SACA3.git)
cd MealExplorer_X00195992_SACA3
dotnet restore

2) Run the application
   
dotnet run

The console will print to show where the website it likely (was for me)
- https://localhost:7034
- http://localhost:5207

Open the URL in your browser.

3) Tests
   
dotnet test


## What the Tests Cover
- MyTest_Base_Page: navigate to Meal From Ingredients and assert the Find (Meals By Ingredient) heading is visible
- Clicking_RandomMeal_And_GetAnother_Random_Meal: click the Random Meal heading and the Get Another Random Meal button
- Search_Ingredient_And_Open_Result: search chicken and open a specific result
- Home_Shows_GetAnotherRandomMeal_Button_Enabled: shows get another meal button works
- Brand_Link_Navigates_Home_From_Ingredients: clicking mealexplorer on top left brings back to home
- Ingredient_Search_Shows_Chicken_Results: when you search for chicken it returns results

## Sources
- [TheMealDB API](https://www.themealdb.com/api.php)
- [Microsoft Playwright for .NET](https://playwright.dev/dotnet/)
