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
                    OutputService.Display("Line can not be empty");
                    OutputService.Display("Please try again");
                    str = InputService.ReadDataFromConsole();
                }
                else
                {
                    OutputService.Display($"Line is too long. Max is {length} symbols");
                    OutputService.Display("Please try again");
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
                    OutputService.Display("PhoneNumber is not correct");
                    OutputService.Display("Please try again");
                    str = InputService.ReadDataFromConsole();
                }
            }
        }
    }
}
