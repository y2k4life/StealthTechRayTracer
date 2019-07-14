//-----------------------------------------------------------------------
// <copyright file="Light.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public abstract class Light
    {
        public RtPoint Position { get; set; }

        public RtColor Intensity { get; set; }

        public abstract double IntensityAt(RtPoint point, World world);
    }
}
