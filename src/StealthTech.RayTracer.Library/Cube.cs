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
        private static void SwapNum(ref double x, ref double y)
        {

            double tempswap = x;
            x = y;
            y = tempswap;
        }

        private bool CheckAxis(Ray ray, out double tmin, out double tmax)
        {           
            tmin = (-1 - ray.Origin.X) / ray.Direction.X;
            tmax = (1 - ray.Origin.X) / ray.Direction.X;

            if (tmin > tmax)
                SwapNum(ref tmin, ref tmax);

            var tymin = (-1 - ray.Origin.Y) / ray.Direction.Y;
            var tymax = (1 - ray.Origin.Y) / ray.Direction.Y;

            if (tymin > tymax)
                SwapNum(ref tymin, ref tymax);

            if ((tmin > tymax) || (tymin > tmax))
                return false;

            tmin = tymin > tmin ? tymin : tmin;
            tmax = tymax < tmax ? tymax : tmax;

            var tzmin = (-1 - ray.Origin.Z) / ray.Direction.Z;
            var tzmax = (1 - ray.Origin.Z) / ray.Direction.Z;

            if (tzmin > tzmax)
                SwapNum(ref tzmin, ref tzmax);

            if ((tmin > tzmax) || (tzmin > tmax))
                return false;

            tmin = tzmin > tmin ? tzmin : tmin;
            tmax = tzmax < tmax ? tzmax : tmax;

            return true;
        }

        public override IntersectionList LocalIntersect(Ray ray)
        {
            var intersections = new IntersectionList();

            if (!CheckAxis(ray, out double tmin, out double tmax))
            {
                return intersections;
            }

            intersections.Add(tmin, this);
            intersections.Add(tmax, this);

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
