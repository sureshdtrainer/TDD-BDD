namespace Calculator.Tests;

[TestFixture]
public class Tests
{
    private Calculator _calculator;
    [SetUp]
    public void Setup()
    {
       _calculator = new Calculator();
    }

    [TestCase(2, 3, 5)]
    [TestCase(1, 1, 2)]
    [TestCase(0, 0, 0)]
    [TestCase(-5, 5, 0)]
    public void Add_TwoNumbers_ReturnsSum(int a, int b, int expected)
    {
        var result = _calculator.Add(a, b);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        
        var result = _calculator.Subtract(5, 3);
        Assert.AreEqual(2, result);
    }
}
