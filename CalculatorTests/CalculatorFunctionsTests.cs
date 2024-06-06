using System.Text;
using static SocialnaPoistovnaKalkulacka.CalculatorFunctions;

namespace CalculatorTests;

public class CalculatorFunctionsTests
{
    [Fact]
    public void ParseInput_WhenInputNull_ShouldThrow()
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => ParseInput(null));
    }

    [Theory]
    [InlineData(-5, 0)]
    [InlineData(101, 95)]
    [InlineData(10, 105)]
    public void ValidateInput_WhenOutValidOfRange_ShouldThrow(int num1, int num2)
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws<Exception>(() => ValidateInput(num1, num2));
    }

    [Theory]
    [InlineData(4, 25)]
    [InlineData(65, 90)]
    public void ValidateInput_WhenNum2BiggerThenNum1_ShouldThrow(int num1, int num2)
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws<Exception>(() => ValidateInput(num1, num2));
    }

    [Theory]
    [InlineData(95, 25)]
    [InlineData(65, 4)]
    public void ValidateInput_WhenValid_ShouldNotThrow(int num1, int num2)
    {
        // Arrange

        // Act
        var ex = Record.Exception(() => ValidateInput(num1, num2));

        // Assert
        Assert.Null(ex);
    }

    [Theory]
    [InlineData(10, "desať")]
    [InlineData(94, "deväťdesiatštyri")]
    [InlineData(169, "stošesťdesiatdeväť")]
    [InlineData(14, "štrnásť")]
    [InlineData(8, "osem")]
    [InlineData(88, "osemdesiatosem")]
    [InlineData(0, "nula")]
    public void PronounceNumbers_WhenValid_ShouldReturnCorrectResult(int value, string expected)
    {
        // Arrange
        var sb = new StringBuilder();

        // Act
        PronounceNumbers(sb, value);
        var actual = sb.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }
}
