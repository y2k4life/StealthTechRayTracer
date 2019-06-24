//-----------------------------------------------------------------------
// <copyright file="Intersection.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class Intersection
    {
        public Intersection(double time, Sphere item)
        {
            Shape = item;
            Time = time;
        }

        public double Time { get; set; }

        public Sphere Shape { get; set; }
    }
}
