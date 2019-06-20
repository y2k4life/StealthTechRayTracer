//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="">
//     Author: splttingatms
//     WebSite: www.sunnyrodriguez.com
//     GitHub: https://github.com/splttingatms/EasyConsole
// </copyright>
//-----------------------------------------------------------------------
namespace StealthTech.RayTracer.EasyConsole
{
    public static class StringExtensions
    {
        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
