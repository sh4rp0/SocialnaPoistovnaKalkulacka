using Calculator;

namespace CalculatorTests;

public class CalculationTests
{
    [Theory]
    [InlineData("25+6","31,00","tridsaùjeden")]
    [InlineData("98-56", "42,00", "ötyridsaùdva")]
    [InlineData("98/65", "1,51", "jeden")]
    public void Calculation_WhenCorrectInputIsGiven_ShouldCalculateCorrectly(
        string input,
        string expected1,
        string expected2)
    {
        // Arrange


        // Act
        var calculation = new Calculation(input);

        // Assert
        Assert.Equal(expected1, calculation.ResultNumericFormat);
        Assert.Equal(expected2 , calculation.ResultVerbalFormat);
    }
}