# TrainingApi sample UI for Day 3 Playwright lab

Small .NET 8 ASP.NET Core app matching the corrected lab guide's browser exercise.

## Run

```powershell
dotnet restore
dotnet run --urls http://localhost:5055
```

Open `http://localhost:5055/order` in a browser. The app redirects `/order` to the static training page at `/`.

## API

`POST /api/discounts/calculate`

Request:

```json
{ "orderAmount": 200.00 }
```

Response:

```json
{ "orderAmount": 200.00, "discountRate": 0.10, "discountAmount": 20.00, "payableAmount": 180.00 }
```

Negative amounts return HTTP 400.

## Playwright check

Use semantic locators as in the guide:

```csharp
await Page.GetByLabel("Order amount").FillAsync("200.00");
await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync();
await Expect(Page.GetByRole(AriaRole.Status))
    .ToContainTextAsync("Payable amount: 180.00");
```
