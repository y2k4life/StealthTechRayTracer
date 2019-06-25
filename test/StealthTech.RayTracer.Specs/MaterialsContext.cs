//-----------------------------------------------------------------------
// <copyright file="MaterialsContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs
{
    public class MaterialsContext
    {
        public Material Material { get; set; }

        public RtTuple EyeVector { get; set; }

        public RtTuple NormalVector { get; set; }

        public RtColor Results { get; set; }

        public PointLight Light { get; set; }
    }
}
