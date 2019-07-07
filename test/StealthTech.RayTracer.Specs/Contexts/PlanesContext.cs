//-----------------------------------------------------------------------
// <copyright file="PlanesContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class PlanesContext
    {
        public Plane Plane { get; set; }

        public Plane lowerPlane { get; set; }

        public Plane upperPlane { get; set; }

        public Plane Floor { get; set; }
    }
}
