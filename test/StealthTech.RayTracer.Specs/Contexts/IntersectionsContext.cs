//-----------------------------------------------------------------------
// <copyright file="IntersectionsContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class IntersectionsContext
    {
        public IntersectionList Intersections { get; set; } = new IntersectionList();

        public Intersection Intersection { get; set; }

        public Intersection Intersection1 { get; set; }

        public Intersection Intersection2 { get; set; }

        public Intersection Intersection3 { get; set; }

        public Intersection Intersection4 { get; set; }
        
        public Intersection Hit { get; set; }

        public Computations Computations { get; set; }
    }
}
