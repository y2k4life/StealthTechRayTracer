//-----------------------------------------------------------------------
// <copyright file="LightsContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class LightsContext
    {
        public RtColor Intensity { get; set; }

        public RtPoint Position { get; set; }

        public PointLight Light { get; set; }
    }
}
