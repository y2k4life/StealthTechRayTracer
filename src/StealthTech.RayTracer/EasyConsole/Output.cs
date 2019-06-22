//-----------------------------------------------------------------------
// <copyright file="Output.cs" company="">
//     Author: splttingatms
//     WebSite: www.sunnyrodriguez.com
//     GitHub: https://github.com/splttingatms/EasyConsole
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace StealthTech.RayTracer.EasyConsole
{
    public static class Output
    {
        public static void WriteLine(ConsoleColor color, string format, params object[] args)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(format, args);
            Console.ResetColor();
        }

        public static void WriteLine(ConsoleColor color, string value)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public static void DisplayPrompt(string format)
        {
            format = format.Trim() + " ";
            Console.Write(format);
        }
    }
}
