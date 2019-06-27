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

        public Computations PrepareComputations(Ray ray)
        {
            var computations = new Computations()
            {
                Time = Time,
                Shape = Shape,
                Point = ray.Position(Time),
                EyeVector = ray.Direction.Negate(),
            };

            computations.NormalVector = Shape.NormalAt(computations.Point);

            if(computations.NormalVector.Dot(computations.EyeVector) < 0)
            {
                computations.Inside = true;
                computations.NormalVector = computations.NormalVector.Negate();
            }
            else
            {
                computations.Inside = false;
            }

            return computations;
        }
    }
}
