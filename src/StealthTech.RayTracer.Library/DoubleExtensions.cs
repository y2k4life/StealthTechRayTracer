//-----------------------------------------------------------------------
// <copyright file="DoubleExtensions.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    using System;
    public static class DoubleExtensions
    {
        private const double EPSILON = 0.0001;

        public static bool ApproximateEquals(this double a, double b)
        {
            if((Math.Abs(a - b))<=EPSILON)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}