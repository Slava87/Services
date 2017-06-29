using System;
using System.Text.RegularExpressions;
using Services.IOServices;

namespace Services.DataHandler
{
    public static class StringValidation
    {
        public static string ValidateLength(int length)
        {
            string str = InputService.ReadDataFromConsole();
            while (true)
            {
                if (str.Length <= length && str.Length != 0)
                    return str;
                else if (string.IsNullOrEmpty(str))
                {
                    OutputService.DisplayConsole("Line can not be empty");
                    OutputService.DisplayConsole("Please try again");
                    str = InputService.ReadDataFromConsole();
                }
                else
                {
                    OutputService.DisplayConsole($"Line is too long. Max is {length} symbols");
                    OutputService.DisplayConsole("Please try again");
                    str = InputService.ReadDataFromConsole();
                }
            }
        }

        public static string ValidatePhone()
        {
            string str = InputService.ReadDataFromConsole();
            Regex expression = new Regex(@"^([+]\d{1,2}-? *)?\(?\d{3}\)?-? *\d{3}-? *-?\d{2} *-?\d{2}$");
            while (true)
            {
                if (expression.IsMatch(str))
                    return str;
                else
                {
                    OutputService.DisplayConsole("PhoneNumber is not correct");
                    OutputService.DisplayConsole("Please try again");
                    str = InputService.ReadDataFromConsole();
                }
            }
        }

        public static int ValidatePositiveInt(string data)
        {
            while (true)
            {
                int i = -1;
                Int32.TryParse(data, out i);      
                return i;
            }

        }

    }
}
