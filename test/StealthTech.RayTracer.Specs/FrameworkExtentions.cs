using System;

namespace StealthTech.RayTracer.Specs
{
    public static class FrameworkExtentions
    {
        public static double EvaluateExpression(this string expression)
        {
            if (expression.Contains('√'))
            {
                bool negate = false;
                expression = expression.Replace('√', ' ').Trim();
                if (expression.Contains('-'))
                {
                    negate = true;
                    expression = expression.Replace('-', ' ').Trim();
                }
                if (expression.Contains('/'))
                {
                    var left = expression.Substring(0, expression.IndexOf('/'));
                    var right = expression.Substring(expression.IndexOf('/') + 1, expression.Length - expression.IndexOf('/') - 1);
                    if (negate)
                    {
                        return -(Math.Sqrt(Convert.ToDouble(left))) / Convert.ToDouble(right);
                    }

                    return Math.Sqrt(Convert.ToDouble(left)) / Convert.ToDouble(right);
                }
                else
                {
                    return Math.Sqrt(Convert.ToDouble(expression));
                }
            }

            return Convert.ToDouble(expression);
        }
    }
}
