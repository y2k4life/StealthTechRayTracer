using System;

namespace StealthTech.RayTracer.Library
{
    public class StripePattern : Pattern
    {
        public StripePattern(RtColor colorA, RtColor colorB)
        {
            ColorA = colorA;
            ColorB = colorB;
        }

        public RtColor ColorB { get; set; }

        public RtColor ColorA { get; set; }

        public override RtColor PatternAt(RtPoint point)
        {
            if (Math.Floor(point.X) % 2 == 0)
            {
                return ColorA;
            }

            return ColorB;
        }
    }
}