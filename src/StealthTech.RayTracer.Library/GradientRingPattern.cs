using System;

namespace StealthTech.RayTracer.Library
{
    public class GradientRingPattern : Pattern
    {
        public RtColor ColorA1 { get; }

        public RtColor ColorA2 { get; }

        public RtColor ColorB { get; }

        public GradientRingPattern(RtColor colorA1, RtColor colorA2, RtColor colorB)
        {
            ColorA1 = colorA1;
            ColorA2 = colorA2;
            ColorB = colorB;
        }

        public override RtColor PatternAt(RtPoint point)
        {
            if (Math.Floor(Math.Sqrt(Math.Pow(point.X, 2.0) + Math.Pow(point.Z, 2.0))) % 2 == 0)
            {
                var distance = ColorA2 - ColorA1;
                var distance1 = (ColorA2 - ColorA1) / 2;

                var t = Math.Atan2(point.Z, point.X);

                var fraction = Math.Abs(t) / Math.PI * 2;

                if (t >= 0)
                {
                    return ColorA2 - distance * fraction;
                }
                else
                {
                    return ColorA2 + distance * fraction;
                }
            }

            return ColorB;
        }
    }
}