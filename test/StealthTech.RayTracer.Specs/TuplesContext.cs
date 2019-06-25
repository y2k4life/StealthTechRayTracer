//-----------------------------------------------------------------------
// <copyright file="TuppleContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs
{
    public class TuplesContext
    {
        public RtTuple Tuple { get; set; }

        public RtTuple Tuple1 { get; set; }

        public RtTuple Tuple2 { get; set; }

        public RtPoint Point { get; set; }

        public RtPoint Point1 { get; set; }

        public RtPoint Point2 { get; set; }

        public RtPoint Point3 { get; set; }

        public RtPoint Point4 { get; set; }
        
        public RtVector Vector { get; set; }

        public RtVector Vector1 { get; set; }

        public RtVector Vector2 { get; set; }

        public RtVector NormalizedVector { get; set; }

        public RtVector ZeroVector { get; set; }

        public RtPoint Origin { get; set; }
        
        public RtVector Direction { get; set; }

        public RtVector Normal { get; set; }

        public RtVector Reflect { get; set; }

        public RtPoint Position { get; set; }

    }
}
