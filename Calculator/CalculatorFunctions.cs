using System.Globalization;
using System.Text;

namespace SocialnaPoistovnaKalkulacka
{
    public static class CalculatorFunctions
    {
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static string ResultSecondRow(decimal value)
        {
            StringBuilder sb = new StringBuilder();

            PronounceNumbers(sb, (int)value);

            //sb.Append(" celá ");

            //int decimalpart = (int)((value - Math.Truncate(value)) * 100);

            //PronounceNumbers(sb, decimalpart);

            return sb.ToString();
        }

        public static void PronounceNumbers(StringBuilder sb, int value)
        {
            if (value == 0)
            {
                sb.Append("nula");
            }
            else
            {
                int hundredts = value / 100;

                if (hundredts > 0)
                {
                    sb.Append(PronounceHundredts(hundredts));
                }

                value = value - hundredts * 100;

                int tens = value / 10;
                if (tens > 1)
                {
                    sb.Append(Pronounce2Tens(tens));
                    var num = value - tens * 10;
                    if (num > 0)
                    {
                        sb.Append(PronounceOnes(num));
                    }
                }
                else if (tens == 1)
                {
                    sb.Append(PronounceTeens(value));
                }
                else
                {
                    sb.Append(PronounceOnes(value - tens * 10));
                }
            }
        }

        public static string PronounceHundredts(int i) => i switch
        {
            1 => "sto",
            //_ => throw new NotImplementedException("Unexpected value")
            _ => throw new NotImplementedException("Nečakaná hodnota")
        };

        public static string PronounceOnes(int i) => i switch
        {
            9 => "deväť",
            8 => "osem",
            7 => "sedem",
            6 => "šesť",
            5 => "päť",
            4 => "štyri",
            3 => "tri",
            2 => "dva",
            1 => "jeden",
            0 => "nula",
            //_ => throw new NotImplementedException("Unexpected value")
            _ => throw new NotImplementedException("Nečakaná hodnota")
        };

        public static string PronounceTeens(int i) => i switch
        {
            19 => "deväťnásť",
            18 => "osemnásť",
            17 => "sedemdnásť",
            16 => "šesťnásť",
            15 => "päťnásť",
            14 => "štrnásť",
            13 => "trinásť",
            12 => "dvanásť",
            11 => "jedenásť",
            10 => "desať",
            //_ => throw new NotImplementedException("Unexpected value")
            _ => throw new NotImplementedException("Nečakaná hodnota")
        };

        public static string Pronounce2Tens(int i) => i switch
        {
            9 => "deväťdesiat",
            8 => "osemdesiat",
            7 => "sedemdesiat",
            6 => "šesťdesiat",
            5 => "päťdesiat",
            4 => "štyridsať",
            3 => "tridsať",
            2 => "dvadsať",
            //_ => throw new NotImplementedException("Unexpected value")
            _ => throw new NotImplementedException("Nečakaná hodnota")
        };

        public static string ResultFirstRow(decimal value)
        {

            CultureInfo ci = new CultureInfo("sk-SK");
            return value.ToString("N2", ci);
        }

        public static double Calculate(int num1, int num2, Operation op)
        {
            if (op == Operation.Addition)
            {
                return num1 + num2;
            }
            else if (op == Operation.Substraction)
            {
                return num1 - num2;
            }
            else if (op == Operation.Division)
            {
                if (num2 == 0)
                {
                    throw new Exception("Delenie nulou nie je definované.");
                }
                return num1 / (double)num2;
            }

            //throw new Exception("Calculation operation not recognized.");
            throw new Exception("Matematická operácia nebola rozoznaná.");
        }

        public static void ValidateInput(int num1, int num2)
        {
            if (!(Validations.ValidateRange100(num1) && Validations.ValidateRange100(num2) && num1 > num2))
            {
                //throw new Exception("Numbers are not valid.");
                throw new Exception("Čísla nespĺňajú podmienky.");
            }
        }


        public static (int num1, int num2, Operation op) ParseInput(string? input)
        {
            int num1 = 0;
            int num2 = 0;
            Operation op;

            if (input == null)
            {
                throw new ArgumentNullException((nameof(input)));
            }

            input = input.RemoveWhitespace();

            if (input.Contains('+'))
            {
                var x = SplitOnCharacter(input, '+');
                return (int.Parse(x.num1), int.Parse(x.num2), Operation.Addition);
            }
            else if (input.Contains('-'))
            {
                var x = SplitOnCharacter(input, '-');
                return (int.Parse(x.num1), int.Parse(x.num2), Operation.Substraction);
            }
            else if (input.Contains('/'))
            {
                var x = SplitOnCharacter(input, '/');
                return (int.Parse(x.num1), int.Parse(x.num2), Operation.Division);
            }

            //throw new Exception("Input contains no valid operation symbol");
            throw new Exception("Vstup neobsahuje žiadny platný symbol operácie.");
        }


        public static (string num1, string num2) SplitOnCharacter(string input, char ch)
        {
            var result = input.Split(ch);
            if (result.Length == 2 && result[0].All(x => char.IsNumber(x)) && result[1].All(x => char.IsNumber(x)))
            {
                return (result[0], result[1]);
            }

            //throw new Exception("String contains unexpected characters.");
            throw new Exception("Vstup obsahuje nečakané znaky.");
        }

        public enum Operation
        {
            Addition,
            Substraction,
            Division
        }

        static class Validations
        {
            public static Func<int, bool> ValidateRange100 = (x) => x >= 0 && x <= 100;
        }
    }
}
