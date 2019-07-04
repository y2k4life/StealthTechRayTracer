using System;
using System.Collections.Generic;
using System.Text;

namespace StealthTech.RayTracer.Library
{
    public class PerturbedStripePattern : StripePattern
    {
        public PerturbedStripePattern(RtColor colorA, RtColor colorB) 
            : base(colorA, colorB)
        {

        }

        public override RtColor PatternAt(RtPoint localPoint)
        {
            var perlin = new PerlinNoise();

            var point = localPoint * 15;

            var noisex = perlin.Perlin(localPoint);
            var noisey = perlin.Perlin(localPoint + new RtVector(1, 0, 0));
            var noisez = perlin.Perlin(localPoint + new RtVector(2, 0, 0));
            var newPoint = new RtPoint(noisex, noisey, noisez).Normalized();


            var noise2x = PerlinNoise2.Perlin(point);
            var noise2y = PerlinNoise2.Perlin(point + new RtVector(1, 0, 0));
            var noise2z = PerlinNoise2.Perlin(point + new RtVector(2, 0, 0));
            
            var newPoint1 = new RtPoint(noise2x, noise2y, noise2z).Normalized();
            var newPoint2 = new RtPoint(localPoint.X - newPoint1.X, localPoint.Y - newPoint1.Y, localPoint.Z - newPoint1.Z);

            return base.PatternAt(newPoint2);
        }
    }
}
