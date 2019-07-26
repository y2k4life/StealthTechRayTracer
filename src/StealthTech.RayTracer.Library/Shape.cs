using System;
using System.Text;

namespace StealthTech.RayTracer.Library
{
    public abstract class Shape : IEquatable<Shape>
    {
        Material _material = new Material();
        
        public Transform Transform { get; set; } = new Transform();
        
        public bool InheritMaterial { get; set; }
        
        public Material Material
        {
            get
            {
                if (InheritMaterial && Parent != null)
                {
                    return Parent.Material;
                }

                return _material;
            }
            set
            {
                _material = value;
            }
        }
        public bool CastShadow { get; set; } = true;
        
        public string Name { get; set; } = string.Empty;
        public Shape Parent { get; set; }

        public IntersectionList Intersect(Ray ray)
        {
            var transformInverse = Transform.Inverse();
            var transformedRay = ray.Transform(transformInverse);

            return LocalIntersect(transformedRay);
        }

        public RtVector NormalAt(RtPoint worldPoint)
        {
            var localPoint = WorldToShape(worldPoint);
            var localNormal = LocalNormalAt(localPoint);
            var worldNormal = NormalToWorld(localNormal);

            return worldNormal;
        }

        public RtPoint WorldToShape(RtPoint worldPoint)
        {
            if (Parent != null)
            {
                worldPoint = Parent.WorldToShape(worldPoint);
            }

            return Transform.Inverse() * worldPoint;
        }

        public RtVector NormalToWorld(RtVector normal)
        {
            normal = RtMatrix.Transpose(Transform.Inverse()) * normal;
            normal = normal.Normalize();

            if (Parent != null)
            {
                normal = Parent.NormalToWorld(normal);
            }

            return normal;
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

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.AppendLine($"Shape {Name}");

            buffer.AppendLine($"Transform");
            buffer.AppendLine(Transform.ToString());

            var transformInverse = Transform.Inverse();
            buffer.AppendLine($"Inverse Transform");
            buffer.AppendLine(transformInverse.ToString());

            return buffer.ToString();
        }
    }
}
