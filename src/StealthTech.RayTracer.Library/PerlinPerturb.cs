//-----------------------------------------------------------------------
// <copyright file="PerlinPerturb.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public class PerlinPerturb : IPerturbPoint
    {
        private readonly double _factor;

        public PerlinPerturb(double factor)
        {
            _factor = factor;
        }

        public RtPoint Perturb(RtPoint localPoint)
        {
            var newX = localPoint.X + PerlinNoise2.Perlin(localPoint.X, localPoint.Y, localPoint.Z) * _factor;
            var newY = localPoint.Y + PerlinNoise2.Perlin(localPoint.X, localPoint.Y, localPoint.Z + 1) * _factor;
            var newZ = localPoint.Z + PerlinNoise2.Perlin(localPoint.X, localPoint.Y, localPoint.Z + 2) * _factor;

            var newPoint = new RtPoint(newX, newY, newZ);

            return newPoint;
        }
    }
}
