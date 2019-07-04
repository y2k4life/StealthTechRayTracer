using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.Library
{
    public class GradientPattern : Pattern
    {
        public GradientPattern(RtColor white, RtColor black)
        {
            ColorB = black;
            ColorA = white;
        }

        public override RtColor PatternAt(RtPoint point)
        {
            var distance = ColorB - ColorA;
            var fraction = point.X - Math.Floor(point.X);

            return ColorA + distance * fraction;
        }

        public RtColor ColorA { get; set; }
        
        public RtColor ColorB { get; set; }
    }
}
