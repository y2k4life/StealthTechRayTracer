//-----------------------------------------------------------------------
// <copyright file="PointContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class PointsContext
    {
        public RtPoint Point { get; set; }

        public RtPoint[] Points { get; set; } = new RtPoint[5];

        //public RtPoint Point2 { get; set; }

        //public RtPoint Point3 { get; set; }
        
        public RtPoint Position { get; set; }

        public RtPoint Origin { get; set; }

        //public RtPoint Point4 { get; set; }
        
        public RtPoint From { get; set; }

        public RtPoint To { get; set; }

        public RtPoint LightPosition { get; set; }

        public RtPoint Corner { get; set; }

        public RtPoint Eye { get; set; }
    }
}
