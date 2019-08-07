//-----------------------------------------------------------------------
// <copyright file="AreaLight.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace StealthTech.RayTracer.Library
{
    public class AreaLight : Light
    {
        public AreaLight(RtPoint corner, RtVector uVector, int uSteps, RtVector vVector, int vSteps, RtColor intensity)
        {
            Corner = corner;
            UVector = uVector / uSteps;
            USteps = uSteps;
            VVector = vVector / vSteps;
            VSteps = vSteps;
            Intensity = intensity;

            var middle = (uVector / 2) + (vVector / 2);
            Position = new RtPoint(middle.X, middle.Y, middle.Z);
            Samples = uSteps * vSteps;
        }

        public RtPoint Corner { get; }

        public RtVector UVector { get; }

        public double USteps { get; }

        public RtVector VVector { get; }

        public double VSteps { get; }

        public ISequence JitterBy { get; set; } = new DeterministicSequence(0.5);

        public override double IntensityAt(RtPoint point, World world)
        {
            var total = 0.0;
            for (int v = 0; v < VSteps; v++)
            {
                for (int u = 0; u < USteps; u++)
                {
                    var lightPosition = PointOnLight(u, v);
                    if (!world.IsShadowed(lightPosition, point))
                    {
                        total += 1.0;
                    }
                }
            }

            var results = total / Samples;
            return results;
        }

        public override IEnumerable<RtPoint> GetSamples()
        {
            for (int v = 0; v < VSteps; v++)
            {
                for (int u = 0; u < USteps; u++)
                {
                    yield return PointOnLight(u, v);
                }
            }
        }

        public RtPoint PointOnLight(double u, double v)
        {
            return Corner +
                UVector * (u + JitterBy.Next()) +
                VVector * (v + JitterBy.Next());
        }
    }
}
