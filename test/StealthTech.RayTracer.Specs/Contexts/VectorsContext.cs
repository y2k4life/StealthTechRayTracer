//-----------------------------------------------------------------------
// <copyright file="VectorsContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class VectorsContext
    {
        public RtVector Vector { get; set; }

        public RtVector Vector1 { get; set; }

        public RtVector Vector2 { get; set; }

        public RtVector ZeroVector { get; set; }

        public RtVector NormalizedVector { get; set; }

        public RtVector NormalVector1 { get; set; }

        public RtVector NormalVector2 { get; set; }

        public RtVector NormalVector3 { get; set; }

        public RtVector Reflect { get; set; }

        public RtVector Up { get; set; }

        public RtVector Direction { get; set; }

        public RtVector NormalVector { get; set; }
    }
}
