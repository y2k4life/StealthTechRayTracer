//-----------------------------------------------------------------------
// <copyright file="Sphere.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace StealthTech.RayTracer.Library
{
    public class Sphere : IEquatable<Sphere>
    {
        public Transform Transform { get; set; } = new Transform();

        public Material Material { get; set; } = new Material();

        public IntersectionList Intersect(Ray ray)
        {
            IntersectionList intersectionList = new IntersectionList();
            
            var transformInverse = Transform.Matrix.Inverse();
            var transformedRay = ray.Transform(transformInverse);

            var saphereToRay = transformedRay.Origin - new RtPoint(0, 0, 0);

            var a = transformedRay.Direction.Dot(transformedRay.Direction);
            var b = 2 * transformedRay.Direction.Dot(saphereToRay);
            var c = saphereToRay.Dot(saphereToRay) - 1;

            var discriminatnt = Math.Pow(b, 2) - 4 * a * c;

            if (discriminatnt < 0)
            {
                return intersectionList;
            }

            var t1 = ((b * -1) - Math.Sqrt(discriminatnt)) / (2 * a);
            var t2 = ((b * -1) + Math.Sqrt(discriminatnt)) / (2 * a);

            intersectionList.Add(new Intersection(t1, this));
            intersectionList.Add(new Intersection(t2, this));

            return intersectionList;
        }

        public RtVector NormalAt(RtPoint worldPoint)
        {
            var shapePoint = new RtPoint(Transform.Matrix.Inverse() * worldPoint);
            var shapeNormal = shapePoint - new RtPoint(0, 0, 0);
            var worldNormal = new RtVector(Transform.Matrix.Inverse().Transpose() * shapeNormal);

            return worldNormal.Normalized();
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
