//-----------------------------------------------------------------------
// <copyright file="PointLight.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class PointLight : IEquatable<PointLight>
    {
        public PointLight(RtPoint position, RtColor color)
        {
            Position = position;
            Intensity = color;
        }

        public RtColor Intensity { get; set; }
        
        public RtPoint Position { get; set; }

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
    }
}
