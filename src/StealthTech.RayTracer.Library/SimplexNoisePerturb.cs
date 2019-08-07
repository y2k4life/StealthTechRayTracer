using System;
using System.Collections.Generic;
using System.Text;

namespace StealthTech.RayTracer.Library
{
    public class SimplexNoisePerturb : IPerturbPoint
    {
        private readonly double _factor;

        public SimplexNoisePerturb(double factor)
        {
            _factor = factor;
        }

        public RtPoint Perturb(RtPoint localPoint)
        {
            var noise = new OpenSimplexNoise();
            var newX = localPoint.X + noise.Evaluate(localPoint.X, localPoint.Y, localPoint.Z) * _factor;
            var newY = localPoint.Y + noise.Evaluate(localPoint.X, localPoint.Y, localPoint.Z + 1) * _factor;
            var newZ = localPoint.Z + noise.Evaluate(localPoint.X, localPoint.Y, localPoint.Z + 2) * _factor;

            return new RtPoint(newX, newY, newZ);
        }
    }
}
