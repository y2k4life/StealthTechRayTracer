//-----------------------------------------------------------------------
// <copyright file="PointLight.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public class PointLight
    {
        public PointLight(RtTuple position, RtColor color)
        {
            Position = position;
            Intensity = color;
        }

        public RtColor Intensity { get; set; }
        
        public RtTuple Position { get; set; }
    }
}
