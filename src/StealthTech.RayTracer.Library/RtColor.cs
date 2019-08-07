//-----------------------------------------------------------------------
// <copyright file="RtColor.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    using System;
    public struct RtColor : IEquatable<RtColor>
    {
        public double Red { get; set; }

        public double Green { get; set; }

        public double Blue { get; set; }

        public static readonly RtColor Black = new RtColor(0.0, 0.0, 0.0);

        public static readonly RtColor White = new RtColor(1.0, 1.0, 1.0);

        public double Magnitude => Math.Sqrt(Math.Pow(Red, 2) + Math.Pow(Green, 2) + Math.Pow(Blue, 2));

        public RtColor(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public static RtColor FromRGB(int red, int green, int blue)
        {
            return new RtColor((red * 1.0) / 255, (green * 1.0) / 255, (blue * 1.0) / 255);
        }

        static public RtColor operator +(RtColor left, RtColor right)
        {
            return new RtColor(
                left.Red + right.Red,
                left.Green + right.Green,
                left.Blue + right.Blue
            );
        }

        static public RtColor operator -(RtColor left, RtColor right)
        {
            return new RtColor(
                left.Red - right.Red,
                left.Green - right.Green,
                left.Blue - right.Blue
            );
        }

        static public RtColor operator *(RtColor left, RtColor right)
        {
            return new RtColor(
                left.Red * right.Red,
                left.Green * right.Green,
                left.Blue * right.Blue
            );
        }

        static public RtColor operator *(RtColor left, double multiplier)
        {
            return new RtColor(
                left.Red * multiplier,
                left.Green * multiplier,
                left.Blue * multiplier
            );
        }

        static public RtColor operator *(double multiplier, RtColor left)
        {
            return left * multiplier;
        }

        static public RtColor operator /(RtColor left, int divisor)
        {
            return new RtColor(left.Red / divisor, left.Green / divisor, left.Blue / divisor);
        }

        public string ToRGB()
        {
            return $"{Normalize(Red)} {Normalize(Green)} {Normalize(Blue)}";
        }

        public string[] ToRGBA()
        {
            return new string[] { Normalize(Red).ToString(), Normalize(Green).ToString(), Normalize(Blue).ToString() };
        }

        public int[] ToARGB()
        {
            return new int[] { Normalize(Red), Normalize(Green), Normalize(Blue) };
        }

        private int Normalize(double comp)
        {
            if (comp < 0) comp = 0;
            if (comp > 1) comp = 1;

            return (int)Math.Round(255*comp);
        }

        public override string ToString()
        {
            return $"{Red}, {Green}, {Blue}";
        }

        public override int GetHashCode()
        {
            return Red.GetHashCode() ^ Green.GetHashCode() ^ Blue.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            RtColor other = (RtColor)obj;
            return (other.Red.ApproximateEquals(Red)
                && other.Green.ApproximateEquals(Green)
                && other.Blue.ApproximateEquals(Blue));
        }

        public bool Equals(RtColor other)
        {
            return (other.Red.ApproximateEquals(Red)
                && other.Green.ApproximateEquals(Green)
                && other.Blue.ApproximateEquals(Blue));
        }
    }
}