//-----------------------------------------------------------------------
// <copyright file="Sphere.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class Sphere : Shape, IEquatable<Sphere>
    {
        public override IntersectionList LocalIntersect(Ray ray)
        {
            var intersections = new IntersectionList();

            //var shapeToRay = ray.Origin - new RtPoint(0, 0, 0);
            var shapeToRay = ray.Origin.DistanceFromZero();

            var a = ray.Direction.Dot(ray.Direction);
            var b = 2 * ray.Direction.Dot(shapeToRay);
            var c = shapeToRay.Dot(shapeToRay) - 1;

            var discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant < 0)
            {
                return intersections;
            }

            var t1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            var t2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

            intersections.Add(new Intersection(t1, this));
            intersections.Add(new Intersection(t2, this));

            return intersections;
        }

        public override RtVector LocalNormalAt(RtPoint shapePoint, Intersection hit)
        {
            return shapePoint.DistanceFromZero();
        }

        public override int GetHashCode()
        {
            return Transform.GetHashCode() ^ Material.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            Sphere other = obj as Sphere;
            return Equals(other);
        }

        public bool Equals(Sphere other)
        {
            if (other is null)
            {
                return false;
            }

            return (Transform.Equals(other.Transform) && Material.Equals(other.Material));
        }
    }
}
