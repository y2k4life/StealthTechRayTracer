//-----------------------------------------------------------------------
// <copyright file="RtEnvironment.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Exercise
{
    public class RtEnvironment
    {
        public RtEnvironment(RtTuple gravity, RtTuple wind)
        {
            Gravity = gravity;
            Wind = wind;
        }

        public RtTuple Gravity { get; set; }

        public RtTuple Wind { get; set; }
    }
}