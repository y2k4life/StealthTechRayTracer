//-----------------------------------------------------------------------
// <copyright file="IntersectionsContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace StealthTech.RayTracer.Library
{
    public class Computations
    {
        public double Time { get; set; }

        public Sphere Shape { get; set; }

        public RtPoint Point { get; set;  }
        
        public RtVector EyeVector { get; set; }
        
        public RtVector NormalVector { get; set; }

        public RtPoint OverPoint
        {
            get
            {
                return Point + NormalVector * DoubleExtensions.EPSILON;
            }
        }

        public bool Inside { get; set; }


    }
}