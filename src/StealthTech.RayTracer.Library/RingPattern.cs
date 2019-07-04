using System;

namespace StealthTech.RayTracer.Library
{
    public class RingPattern : Pattern
    {
        public RtColor ColorA { get; }

        public RtColor ColorB { get; }

        public RingPattern(RtColor white, RtColor black)
        {
            ColorA = white;
            ColorB = black;
        }

        public override RtColor PatternAt(RtPoint point)
        {
            if (Math.Floor(Math.Sqrt(Math.Pow(point.X, 2.0) + Math.Pow(point.Z, 2.0))) % 2 == 0)
            {
                return ColorA;
            }

            return ColorB;
        }
    }
}