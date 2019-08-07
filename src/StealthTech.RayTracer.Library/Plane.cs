using System;

namespace StealthTech.RayTracer.Library
{
    public class Plane : Shape
    {
        public Plane()
        {
        }

        public override IntersectionList LocalIntersect(Ray ray)
        {
            var intersecitons = new IntersectionList();
            if (Math.Abs(ray.Direction.Y) < DoubleExtensions.EPSILON)
            {
                return intersecitons;
            }

            var time = -ray.Origin.Y / ray.Direction.Y;
            intersecitons.Add(new Intersection(time, this));
            return intersecitons;
        }

        public override RtVector LocalNormalAt(RtPoint point, Intersection hit)
        {
            return new RtVector(0, 1, 0);
        }
    }
}