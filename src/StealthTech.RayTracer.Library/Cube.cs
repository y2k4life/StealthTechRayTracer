//-----------------------------------------------------------------------
// <copyright file="Cube.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;

namespace StealthTech.RayTracer.Library
{
    public class Cube : Shape
    {
        public Cube()
        {
        }

        (double timeMin, double timeMax) CheckAxis(double origin, double direction)
        {
            var timeMinNumerator = -1 - origin;
            var timeMaxNumerator = 1 - origin;

            double timeMin = 0;
            double timeMax = 0;

            timeMin = timeMinNumerator / direction;
            timeMax = timeMaxNumerator / direction;

            if (timeMin > timeMax)
            {
                var temp = timeMin;
                timeMin = timeMax;
                timeMax = temp;
            }

            return (timeMin, timeMax);
        }

        public override IntersectionList LocalIntersect(Ray ray)
        {
            var intersections = new IntersectionList();

            (double xTimeMin, double xTimeMax) = CheckAxis(ray.Origin.X, ray.Direction.X);
            (double yTimeMin, double yTimeMax) = CheckAxis(ray.Origin.Y, ray.Direction.Y);
            (double zTimeMin, double zTimeMax) = CheckAxis(ray.Origin.Z, ray.Direction.Z);

            var mins = new double[] { xTimeMin, yTimeMin, zTimeMin };
            var timeMin = mins.Max();
            var timeMax = (new double[] { xTimeMax, yTimeMax, zTimeMax }).Min();

            if (timeMin > timeMax)
            {
                return intersections;
            }

            intersections.Add(timeMin, this);
            intersections.Add(timeMax, this);

            return intersections;
        }

        public override RtVector LocalNormalAt(RtPoint point)
        {
            var maxC = (new double[] { Math.Abs(point.X), Math.Abs(point.Y), Math.Abs(point.Z) }).Max();

            if (maxC == Math.Abs(point.X))
            {
                return new RtVector(point.X, 0, 0);
            }
            else if (maxC == Math.Abs(point.Y))
            {
                return new RtVector(0, point.Y, 0);
            }

            return new RtVector(0, 0, point.Z);
        }
    }
}
