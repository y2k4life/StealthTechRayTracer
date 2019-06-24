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
        public RtEnvironment(RtVector gravity, RtVector wind)
        {
            Gravity = gravity;
            Wind = wind;
        }

        public RtVector Gravity { get; set; }

        public RtVector Wind { get; set; }
    }
}