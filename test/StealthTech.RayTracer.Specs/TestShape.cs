using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.Specs
{
    public class TestShape : Shape
    {
        public Ray SavedRay { get; set; }

        public override IntersectionList LocalIntersect(Ray ray)
        {
            SavedRay = ray;
            return null;
        }

        public override RtVector LocalNormalAt(RtPoint point, Intersection hit)
        {
            return new RtVector(point.X, point.Y, point.Z);
        }
    }
}
