using static SocialnaPoistovnaKalkulacka.Calculator;

while (true)
{
    try
    {
        Console.WriteLine("Zadajte príklad");

        string input = Console.ReadLine();

        (int num1, int num2, Operation op) = ParseInput(input);

        ValidateInput(num1, num2);

        double result = Calculate(num1, num2, op);

        decimal roundedResult = decimal.Round((decimal)result, 2, MidpointRounding.AwayFromZero);

        Console.WriteLine(ResultFirstRow(roundedResult));
        Console.WriteLine(ResultSecondRow(roundedResult));
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}