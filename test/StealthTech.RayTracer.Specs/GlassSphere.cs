//-----------------------------------------------------------------------
// <copyright file="GlassSphere.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs
{
    public class GlassSphere : Sphere
    {
        public GlassSphere()
            : base()
        {
            Material = new Material
            {
                Transparency = 1.0,
                RefractiveIndex = 1.5
            };
        }
    }
}
