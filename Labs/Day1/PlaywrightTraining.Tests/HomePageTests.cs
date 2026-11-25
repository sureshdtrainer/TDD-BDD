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
    }

    [Test]
    public async Task BingHomePage_ShouldDisplayExpectedTitle()
    {
        await Page.GotoAsync("https://www.bing.com");

        await Expect(Page).ToHaveTitleAsync("Search - Microsoft Bing");
    }
}
