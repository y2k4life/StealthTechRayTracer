//-----------------------------------------------------------------------
// <copyright file="RayContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs
{
    public class RayContext
    {
        public Ray Ray { get; set; }

        public Ray Ray2 { get; set; }

        public Transform M { get; set; }
    }
}
