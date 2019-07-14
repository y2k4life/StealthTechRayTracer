//-----------------------------------------------------------------------
// <copyright file="MaterialsContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class MaterialsContext
    {
        public Material Material { get; set; }

        public RtColor Results { get; set; }

        public double Intensity { get; set; }
    }
}
