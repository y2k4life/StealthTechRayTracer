using StealthTech.RayTracer.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace StealthTech.RayTracer.Specs
{
    public class TestPattern : Pattern
    {
        public override RtColor PatternAt(RtPoint point)
        {
            return new RtColor(point.X, point.Y, point.Z);
        }
    }
}
