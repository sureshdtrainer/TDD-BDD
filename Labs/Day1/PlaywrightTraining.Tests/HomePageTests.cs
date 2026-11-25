using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTraining.Tests;

[TestFixture]
public class HomePageTests: PageTest
{
    [Test]
    public async Task GoogleHomePage_ShouldDisplayExpectedTitle()
    {
        await Page.GotoAsync("https://www.google.co.in");

        await Expect(Page).ToHaveTitleAsync("Google");

        //locator using xpath
        var searchBox = Page.Locator("//textarea[@class='gLFyf']");
        await searchBox.FillAsync("Playwright", new() { Timeout = 5000 });

        await searchBox.PressAsync("Enter");

        await Page.WaitForLoadStateAsync();

    }

    [Test]
    public async Task BingHomePage_ShouldDisplayExpectedTitle()
    {
        await Page.GotoAsync("https://www.bing.com");

        await Expect(Page).ToHaveTitleAsync("Search - Microsoft Bing");
    }
}
