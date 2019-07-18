//-----------------------------------------------------------------------
// <copyright file="PointLight.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace StealthTech.RayTracer.Library
{
    public class PointLight : Light, IEquatable<PointLight>
    {
        public PointLight(RtPoint position, RtColor color)
        {
            Position = position;
            Intensity = color;
            Samples = 1;
        }

        public override int GetHashCode()
        {
            return Intensity.GetHashCode() ^ Position.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            PointLight other = obj as PointLight;
            return Equals(other);
        }

        public bool Equals(PointLight other)
        {
            if (other is null)
            {
                return false;
            }

            return (Position.Equals(other.Position) && Intensity.Equals(other.Intensity));
        }

        public override double IntensityAt(RtPoint point, World world)
        {
            if(world.IsShadowed(Position, point))
            {
                return 0.0;
            }
            else
            {
                return 1.0;
            }
        }

        public override IEnumerable<RtPoint> GetSamples()
        {
            var smaples = new List<RtPoint>(new RtPoint[] { Position });
            return smaples;
        }
    }
}
