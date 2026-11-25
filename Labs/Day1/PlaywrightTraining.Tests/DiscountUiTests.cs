using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTraining.Tests;

public class DiscountUiTests : PageTest
{
    [Test]
    public async Task CalculateDiscount_DisplaysCorrectAmount()
    {
        await Page.GotoAsync("http://localhost:5055");

        await Page.GetByLabel("Order amount")
            .FillAsync("200");

        await Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Calculate" })
            .ClickAsync();

        await Expect(
            Page.GetByRole(AriaRole.Status)).ToContainTextAsync("Payable amount: 180.00");
    }
}
