//-----------------------------------------------------------------------
// <copyright file="IntersectionsContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class Computations
    {
        public double Time { get; set; }

        public Shape Shape { get; set; }

        public RtPoint Position { get; set;  } = new RtPoint(0, 0, 0);

        public RtVector EyeVector { get; set; } = new RtVector(0, 0, 0);

        public RtVector NormalVector { get; set; } = new RtVector(0, 0, 0);

        public RtPoint OverPosition
        {
            get
            {
                return Position + NormalVector * DoubleExtensions.EPSILON;
            }
        }

        public RtPoint UnderPosition
        {
            get
            {
                return Position - NormalVector * DoubleExtensions.EPSILON;
            }
        }

        public bool Inside { get; set; }

        public RtVector ReflectVector { get; set; }

        public double n1 { get; set; }

        public double n2 { get; set; }

        public double Schlick()
        {
            var cos = EyeVector.Dot(NormalVector);

            if (n1 > n2)
            {
                var n = n1 / n2;
                var sin2T = Math.Pow(n, 2) * (1.0 - Math.Pow(cos, 2));
                if (sin2T > 1.0)
                {
                    return 1.0;
                }

                var cosT = Math.Sqrt(1.0 - sin2T);

                cos = cosT;
            }

            var r0 = Math.Pow((n1 - n2) / (n1 + n2), 2);
            return r0 + (1 - r0) * Math.Pow((1 - cos), 5);
        }
    }
}