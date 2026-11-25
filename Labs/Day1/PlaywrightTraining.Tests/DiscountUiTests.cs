using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTraining.Tests;

public class DiscountUiTests : PageTest
{
    [Test]
    public async Task CalculateDiscount_DisplaysCorrectAmount()
    {
        //Open the Discount UI Web Page
        await Page.GotoAsync("http://localhost:5055");

        //Search for Label called Order amount and fill it with 200 value
        await Page.GetByLabel("Order amount")
            .FillAsync("200");

        //Click on the Button named Calculate using AriaRole
        await Page.GetByRole(
            AriaRole.Button,
            new() { Name = "Calculate" })
            .ClickAsync();

        //Validate using Playwright Expect method if the role="status" field containt below text
        await Expect(
            Page.GetByRole(AriaRole.Status)).ToContainTextAsync("Payable amount: 180.00");
    }
}
