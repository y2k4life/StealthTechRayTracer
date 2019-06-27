//-----------------------------------------------------------------------
// <copyright file="WorldContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs
{
    public class WorldContext
    {
        public World World { get; set; }

        public IntersectionList Intersections { get; set; }

        public Sphere Outer { get; set; }

        public Sphere Inner { get; set; }
    }
}
