//-----------------------------------------------------------------------
// <copyright file="Material.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace StealthTech.RayTracer.Library
{
    public class Material
    {
        public Material()
        {
            Color = new RtColor(1, 1, 1);
            Ambient = 0.1;
            Diffuse = 0.9;
            Specular = 0.9;
            Shininess = 200.0;
        }

        public RtColor Color { get; set; }

        public double Ambient { get; set; }

        public double Diffuse { get; set; }

        public double Specular { get; set; }

        public double Shininess { get; set; }

        public Pattern Pattern { get; set; }

        public double Reflective { get; set;  }

        public double Transparency { get; set; }

        public double RefractiveIndex { get; set; } = 1.0;

        public override int GetHashCode()
        {
            return
                Color.GetHashCode() ^
                Ambient.GetHashCode() ^
                Diffuse.GetHashCode() ^
                Specular.GetHashCode() ^
                Shininess.GetHashCode() ^
                Pattern.GetHashCode() ^
                Reflective.GetHashCode() ^
                Transparency.GetHashCode() ^
                RefractiveIndex.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            Material other = obj as Material;
            return Equals(other);
        }

        public bool Equals(Material other)
        {
            if (other is null)
            {
                return false;
            }

            return (other.Color.Equals(Color)
                && other.Ambient.ApproximateEquals(Ambient)
                && other.Diffuse.ApproximateEquals(Diffuse)
                && other.Specular.ApproximateEquals(Specular)
                && other.Shininess.ApproximateEquals(Shininess)
                && other.Reflective.ApproximateEquals(Reflective)
                && other.RefractiveIndex.ApproximateEquals(RefractiveIndex)
                && other.Transparency.ApproximateEquals(Transparency));
        }

        public RtColor Lighting(Computations computations, Light light, double intensity)
        {
            var color = Color;

            if (Pattern !=null)
            {
                color = Pattern.PatternAtShape(computations.Shape, computations.OverPosition);
            }
            
            var effectiveColor = color * light.Intensity;
            var lightVector = (light.Position - computations.Position).Normalize();
            
            var lightDotNormal = lightVector.Dot(computations.NormalVector);

            var ambient = effectiveColor * Ambient;

            RtColor diffuse;
            RtColor specular;

            if (lightDotNormal < 0 || intensity == 0)
            {
                diffuse = RtColor.Black;
                specular = RtColor.Black;
            }
            else
            {
                diffuse = effectiveColor * Diffuse * lightDotNormal * intensity;

                var reflectVector = lightVector.Negate().Reflect(computations.NormalVector);
                var reflectDotEye = reflectVector.Dot(computations.EyeVector);
                
                if (reflectDotEye <= 0)
                {
                    specular = RtColor.Black;
                }
                else
                {
                    var factor = Math.Pow(reflectDotEye, Shininess);
                    specular = light.Intensity * Specular * factor * intensity;
                }
            }

            var results = ambient + diffuse + specular;
            return results;
        }
    }
}
