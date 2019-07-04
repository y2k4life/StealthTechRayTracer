using System;

namespace StealthTech.RayTracer.Library
{
    public class CheckersPattern : Pattern
    {
        public CheckersPattern(RtColor colorA, RtColor colorB)
        {
            ColorB = colorB;
            ColorA = colorA;
        }

        public override RtColor PatternAt(RtPoint point)
        {
            if ((Math.Floor(point.X) + Math.Floor(point.Y) + Math.Floor(point.Z)) % 2 == 0)
            {
                return ColorA;
            }

            return ColorB;
        }

        public RtColor ColorA { get; }

        public RtColor ColorB { get; }
    }
}
