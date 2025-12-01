using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace E2E.Tests;

[Parallelizable(ParallelScope.Self)]
public class RecordedTests : PageTest
{
    private string BaseUrl => Environment.GetEnvironmentVariable("E2E_BASE_URL") ?? "http://localhost:5207";

    [Test]
    public async Task MyTest_Base_Page()
    {
        await Page.GotoAsync($"{BaseUrl}/");

        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { NameString = "Meal From Ingredients" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { NameString = "Find Meals By Ingredient" }))
            .ToBeVisibleAsync();
    }

    [Test]
    public async Task Clicking_RandomMeal_And_GetAnother_RandomMeal()
    {
        await Page.GotoAsync($"{BaseUrl}/");

        await Page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { NameString = "Random Meal" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { NameString = "Get Another Random Meal" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { NameString = "Random Meal" }))
            .ToBeVisibleAsync();
    }

    [Test]
    public async Task Search_Ingredient_And_Open_Result()
    {
        await Page.GotoAsync($"{BaseUrl}/");

        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { NameString = "MealExplorer" }).ClickAsync();

        await Page.Locator("#sidebarMenu div").Filter(new LocatorFilterOptions { HasTextString = "Home" }).ClickAsync();

        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { NameString = "Meal From Ingredients" }).ClickAsync();

        await Page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { NameString = "Ingredient:" }).ClickAsync();
        await Page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { NameString = "Ingredient:" }).FillAsync("chicken");
        await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { NameString = "Search" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { NameString = "Brown Stew ChickenBrown Stew" }))
            .ToBeVisibleAsync();
        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { NameString = "Brown Stew ChickenBrown Stew" }).ClickAsync();
    }

    [Test]
    public async Task Home_Shows_GetAnotherRandomMeal_Button_Enabled()
    {
        await Page.GotoAsync($"{BaseUrl}/");

        var button = Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { NameString = "Get Another Random Meal" });
        await Expect(button).ToBeVisibleAsync();
        await Expect(button).ToBeEnabledAsync();
    }

    [Test]
    public async Task Brand_Link_Navigates_Home_From_Ingredients()
    {
        await Page.GotoAsync($"{BaseUrl}/");

        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { NameString = "Meal From Ingredients" }).ClickAsync();
        await Expect(Page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { NameString = "Find Meals By Ingredient" }))
            .ToBeVisibleAsync();

        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { NameString = "MealExplorer" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { NameString = "Random Meal" }))
            .ToBeVisibleAsync();
    }

    [Test]
    public async Task Ingredient_Search_Shows_Chicken_Results()
    {
        await Page.GotoAsync($"{BaseUrl}/");

        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { NameString = "Meal From Ingredients" }).ClickAsync();

        var ingredientInput = Page.GetByRole(AriaRole.Textbox, new PageGetByRoleOptions { NameString = "Ingredient:" });
        await ingredientInput.FillAsync("chicken");
        await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { NameString = "Search" }).ClickAsync();

        var chickenResults = Page.Locator("a").Filter(new LocatorFilterOptions { HasTextString = "Chicken" });

        await Expect(chickenResults.First).ToBeVisibleAsync();
        var count = await chickenResults.CountAsync();
        Assert.That(count, Is.GreaterThan(0), "Expected at least one search result containing 'Chicken'.");
    }
}
