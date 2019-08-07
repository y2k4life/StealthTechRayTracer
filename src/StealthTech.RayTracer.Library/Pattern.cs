using System;

namespace StealthTech.RayTracer.Library
{
    public abstract class Pattern
    {
        public Transform Transform { get; set; } = new Transform();

        public abstract RtColor PatternAt(RtPoint point);

        public bool IsPerturbed { get; set; }

        public IPerturbPoint PerturbBy { get; set; }

        public RtColor PatternAtShape(Shape shape, RtPoint worldPoint)
        {
            var shapePoint = shape.Transform.Inverse() * worldPoint;
            var patterPoint = Transform.Inverse() * shapePoint;

            if(IsPerturbed && PerturbBy != null)
            {
                patterPoint = PerturbBy.Perturb(patterPoint);
            }

            return PatternAt(patterPoint);
        }

    }
}