using System;

namespace StealthTech.RayTracer.Library
{
    public abstract class Shape : IEquatable<Shape>
    {
        public Transform Transform { get; set; } = new Transform();

        public Material Material { get; set; } = new Material();

        public IntersectionList Intersect(Ray ray)
        {
            var transformInverse = Transform.Matrix.Inverse();
            var transformedRay = ray.Transform(transformInverse);

            return LocalIntersect(transformedRay);
        }

        public RtVector NormalAt(RtPoint worldPoint)
        {
            var shapePoint = new RtPoint(Transform.Matrix.Inverse() * worldPoint);
            var shapeNormal = LocalNormalAt(shapePoint);
            var worldNormal = new RtVector(Transform.Matrix.Inverse().Transpose() * shapeNormal);

            return worldNormal.Normalize();
        }

        public abstract IntersectionList LocalIntersect(Ray ray);

        public abstract RtVector LocalNormalAt(RtPoint point);

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

            Shape other = obj as Shape;
            return Equals(other);
        }

        public bool Equals(Shape other)
        {
            if (other is null)
            {
                return false;
            }

            return (Transform.Equals(other.Transform) && Material.Equals(other.Material));
        }
    }
}
