using static SocialnaPoistovnaKalkulacka.CalculatorFunctions;

namespace Calculator;

public class Calculation
{
    public string ResultNumericFormat { get; private set; }

    public string ResultVerbalFormat { get; private set; }

    public Calculation(string? input)
    {
        (int num1, int num2, Operation op) = ParseInput(input);

        ValidateInput(num1, num2);

        double result = Calculate(num1, num2, op);

        decimal roundedResult = decimal.Round((decimal)result, 2, MidpointRounding.AwayFromZero);

        ResultNumericFormat = ResultFirstRow(roundedResult);
        ResultVerbalFormat = ResultSecondRow(roundedResult);
    }
}
