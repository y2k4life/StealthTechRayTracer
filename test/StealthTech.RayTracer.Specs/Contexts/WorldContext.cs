//-----------------------------------------------------------------------
// <copyright file="WorldContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class WorldContext
    {
        public World World { get; set; }

        public Sphere OuterShape { get; set; }

        public Sphere Inner { get; set; }
    }
}
