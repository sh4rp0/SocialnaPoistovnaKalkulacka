using Calculator;

while (true)
{
    try
    {
        Console.WriteLine("Zadajte príklad");

        var calculation = new Calculation(Console.ReadLine());

        Console.WriteLine(calculation.ResultNumericFormat);
        Console.WriteLine(calculation.ResultVerbalFormat);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}