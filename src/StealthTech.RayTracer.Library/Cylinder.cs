using System;

namespace StealthTech.RayTracer.Library
{
    public class Cylinder : Shape
    {
        public Cylinder()
        {
        }

        public double Maximum { get; set; } = double.PositiveInfinity;

        public double Minimum { get; set; } = double.NegativeInfinity;

        public bool IsClosed { get; set; }


        public override IntersectionList LocalIntersect(Ray ray)
        {
            var intersections = new IntersectionList();
            var a = Math.Pow(ray.Direction.X, 2) + Math.Pow(ray.Direction.Z, 2);

            if (a.ApproximateEquals(0))
            {
                IntersectCaps(ray, intersections);
                return intersections;
            }

            var b = 2 * ray.Origin.X * ray.Direction.X + 2 * ray.Origin.Z * ray.Direction.Z;
            var c = Math.Pow(ray.Origin.X, 2) + Math.Pow(ray.Origin.Z, 2) - 1;

            var discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant < 0)
                return intersections;

            var t0 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            var t1 = (-b + Math.Sqrt(discriminant)) / (2 * a);

            if (t0 > t1)
            {
                var tt = t0;
                t0 = t1;
                t1 = tt;
            }

            var y0 = ray.Origin.Y + t0 * ray.Direction.Y;
            if (Minimum < y0 && y0 < Maximum)
            {
                intersections.Add(t0, this);
            }

            var y1 = ray.Origin.Y + t1 * ray.Direction.Y;
            if (Minimum < y1 && y1 < Maximum)
            {
                intersections.Add(t1, this);
            }

            IntersectCaps(ray, intersections);

            return intersections;
        }

        private void IntersectCaps(Ray ray, IntersectionList intersections)
        {
            if (!IsClosed || ray.Direction.Y.ApproximateEquals(0))
            {
                return;
            }

            var time = (Minimum - ray.Origin.Y) / ray.Direction.Y;
            if (CheckCap(ray, time))
            {
                intersections.Add(time, this);
            }

            time = (Maximum - ray.Origin.Y) / ray.Direction.Y;
            if (CheckCap(ray, time))
            {
                intersections.Add(time, this);
            }
        }

        private bool CheckCap(Ray ray, double time)
        {
            var x = ray.Origin.X + time * ray.Direction.X;
            var z = ray.Origin.Z + time * ray.Direction.Z;

            return (Math.Pow(x, 2) + Math.Pow(z, 2)) <= 1;
        }

        public override RtVector LocalNormalAt(RtPoint point, Intersection hit)
        {
            var distance = Math.Pow(point.X, 2) + Math.Pow(point.Z, 2);

            if (distance < 1 && point.Y >= Maximum - DoubleExtensions.EPSILON)
            {
                return new RtVector(0, 1, 0);
            }
            else if (distance < 1 && point.Y <= Minimum + DoubleExtensions.EPSILON)
            {
                return new RtVector(0, -1, 0);
            }
            else
            {
                return new RtVector(point.X, 0, point.Z);
            }
        }
    }
}