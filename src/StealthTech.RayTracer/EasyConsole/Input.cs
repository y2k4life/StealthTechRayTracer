﻿//-----------------------------------------------------------------------
// <copyright file="Input.cs" company="">
//     Author: splttingatms
//     WebSite: www.sunnyrodriguez.com
//     GitHub: https://github.com/splttingatms/EasyConsole
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;

namespace StealthTech.RayTracer.EasyConsole
{
    public static class Input
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static int ReadInt(string prompt, int[] ints)
        {
            Output.DisplayPrompt(prompt);
            int value = ReadInt();

            while (!ints.Contains(value))
            {
                Output.DisplayPrompt($"Please enter an integer");
                value = ReadInt();
            }

            return value;
        }

        public static int ReadInt(int min, int max)
        {
            int value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt($"Please enter an integer between {min} and {max} (inclusive)");
                value = ReadInt();
            }

            return value;
        }

        public static int ReadInt()
        {
            string input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer");
                input = Console.ReadLine();
            }

            return value;
        }

        public static double ReadDouble(string prompt)
        {
            Output.DisplayPrompt(prompt);
            string input = Console.ReadLine();
            double value;

            while (!double.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an float");
                input = Console.ReadLine();
            }

            return value;
        }

        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            Type type = typeof(TEnum);

            if (!type.IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            Output.WriteLine(prompt);
            Menu menu = new Menu();

            TEnum choice = default;
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            return choice;
        }

    }
}
