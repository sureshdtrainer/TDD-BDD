using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
namespace Training.Ui.Tests;

[TestFixture]
public class OrderPageTests : PageTest
{
    private string Url => Environment.GetEnvironmentVariable("PLAYWRIGHT_BASE_URL") ?? "http://localhost:5055";
    [Test] public async Task CalculatesPayableAmount() { await Page.GotoAsync(Url + "/order"); await Page.GetByLabel("Order amount").FillAsync("200.00"); await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync(); await Expect(Page.GetByRole(AriaRole.Status)).ToContainTextAsync("Payable amount: 180.00"); }
    [Test] public async Task RejectsNegativeAmount() { await Page.GotoAsync(Url + "/order"); await Page.GetByLabel("Order amount").FillAsync("-1"); await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync(); await Expect(Page.GetByRole(AriaRole.Status)).ToContainTextAsync("cannot be negative"); }
}
