using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Module_6_Task_6
{
    class InOut
    {
        const char DelimiterHorizontal = '-';
        const char DelimiterVertical = '|';
        const string EOL = "\r\n";

        public static int Select(string message, List<string> options)
        {
            Console.WriteLine(message);
            int i = 1;

            foreach (string option in options)
            {
                Console.WriteLine($"{i++}){option}");
            }
            string selected = Console.ReadKey(true).KeyChar.ToString();

            while( !Regex.IsMatch(selected.ToString(), @"^\d+$") || Convert.ToInt32(selected) > options.Count+1 )
            {
                selected = Console.ReadKey(true).KeyChar.ToString();
            }
            return Convert.ToInt32(selected)-1;
        }

        public static void Alert(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static string Dialog(string title)
        {
            Console.Write(title);
            return Console.ReadLine();
        }

        public static int DialogInt(string title = null)
        {
            string userInput = Dialog(title);

            while (!Regex.IsMatch(userInput, @"^\d+$"))
            {
                Console.Clear();
                Console.WriteLine("The value must be numeric! The number must be positive!");

                userInput = Dialog(title);

            }
            return Convert.ToInt32(userInput);
        }

        public static void BlockyPrint(String[] texts)
        {
            string top = "";
            string middle = "";
            string bottom = "";

            foreach (string text in texts) {
                middle += DelimiterVertical.ToString() + text;
            }
            middle += DelimiterVertical.ToString();
            top = top.PadRight(middle.Length, DelimiterHorizontal);
            bottom = bottom.PadRight(middle.Length, DelimiterHorizontal);
            Console.WriteLine(top + EOL + middle + EOL + bottom);
        }
    }

}
