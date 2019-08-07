//-----------------------------------------------------------------------
// <copyright file="Triangle.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;
using System.Collections.Generic;

namespace StealthTech.RayTracer.Library
{
    public class Triangle : Shape
    {
        public Triangle(RtPoint point1, RtPoint point2, RtPoint point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public Triangle(RtPoint point1, RtPoint point2, RtPoint point3, RtVector normal1, RtVector normal2, RtVector normal3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
            Normal1 = normal1;
            Normal2 = normal2;
            Normal3 = normal3;
        }

        public RtPoint Point1 { get; protected set; }
        
        public RtPoint Point2 { get; protected set; }
        
        public RtPoint Point3 { get; protected set; }
        
        public RtVector Normal1 { get; protected set; }

        public RtVector Normal2 { get; protected set; }

        public RtVector Normal3 { get; protected set; }

        public RtVector Edge1
        {
            get
            {
                return Point2 - Point1;
            }
        }

        public RtVector Edge2
        {
            get
            {
                return Point3 - Point1;
            }
        }

        public RtVector Normal
        {
            get
            {
                return Edge2.Cross(Edge1).Normalize();
            }
        }

        public override IntersectionList LocalIntersect(Ray ray)
        {
            var intersections = new IntersectionList();

            var directionCrossEdge2 = ray.Direction.Cross(Edge2);
            var determinant = Edge1.Dot(directionCrossEdge2);

            if (Math.Abs(determinant) < DoubleExtensions.EPSILON)
            {
                return intersections;
            }

            var f = 1.0 / determinant;
            var point1ToOrigin = ray.Origin - Point1;
            var u = f * point1ToOrigin.Dot(directionCrossEdge2);
            if (u < 0 || u > 1)
            {
                return intersections;
            }

            var originCrossEdge1 = point1ToOrigin.Cross(Edge1);
            var v = f * ray.Direction.Dot(originCrossEdge1);
            if (v < 0 || (u + v) > 1)
            {
                return intersections;
            }

            var t = f * Edge2.Dot(originCrossEdge1);
            var intersection = new Intersection
            {
                Shape = this,
                Time = t,
                U = u,
                V = v
            };

            intersections.Add(intersection);

            return intersections;
        }

        public override RtVector LocalNormalAt(RtPoint point, Intersection hit)
        {
            if (hit == null)
            {
                return Normal;
            }
            else
            {
                return Normal2 * hit.U + Normal3 * hit.V + Normal1 * (1 - hit.U - hit.V);
            }
        }
    }
}