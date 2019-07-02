//-----------------------------------------------------------------------
// <copyright file="SphereContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class SphereContext
    {
        public Sphere Sphere { get; set; }
        
        public Transform Transform { get; set; }

        public RtVector Normal { get; set; }

        public Sphere Sphere1 { get; set; }

        public Sphere Sphere2 { get; set; }
    }
}
