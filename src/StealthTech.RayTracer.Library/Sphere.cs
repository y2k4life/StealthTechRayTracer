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
    public class Sphere
    {
        public Transform Transform { get; set; } = new Transform();

        public List<Intersection> Intersect(Ray ray)
        {
            var transformedRay = ray.Transform(Transform.Matrix.Inverse());

            var saphereToRay = transformedRay.Origin - new RtPoint(0, 0, 0);

            var a = transformedRay.Direction.Dot(transformedRay.Direction);
            var b = 2 * transformedRay.Direction.Dot(saphereToRay);
            var c = saphereToRay.Dot(saphereToRay) - 1;

            var discriminatnt = Math.Pow(b, 2) - 4 * a * c;

            var results = new List<Intersection>();

            if (discriminatnt < 0)
            {
                return results;
            }

            var t1 = ((b * -1) - Math.Sqrt(discriminatnt)) / (2 * a);
            var t2 = ((b * -1) + Math.Sqrt(discriminatnt)) / (2 * a);

            results.Add(new Intersection(t1, this));
            results.Add(new Intersection(t2, this));

            return results;
        }
    }
}
