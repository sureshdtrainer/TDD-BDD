using Reqnroll;

[Binding]
public class ScenarioHooks
{
    [BeforeFeature]
    public static void BeforeFeature()
    {
        Console.WriteLine("Before Feature");
    }

    [BeforeScenario]
    public void BeforeScenario(ScenarioContext context)
    {
        Console.WriteLine("Starting scenario");
    }

    [AfterScenario]
    public void AfterScenario(ScenarioContext context)
    {
        Console.WriteLine("Completed scenario");
    }


    [AfterFeature]
    public static void AfterFeature()
    {
        Console.WriteLine("After Feature");
    }
}