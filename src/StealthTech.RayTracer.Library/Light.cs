//-----------------------------------------------------------------------
// <copyright file="Light.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace StealthTech.RayTracer.Library
{
    public abstract class Light
    {
        public RtPoint Position { get; set; }

        public RtColor Intensity { get; set; }

        public int Samples { get; protected set; }

        public abstract double IntensityAt(RtPoint point, World world);

        public abstract IEnumerable<RtPoint> GetSamples();
    }
}
