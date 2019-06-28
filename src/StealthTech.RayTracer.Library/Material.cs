//-----------------------------------------------------------------------
// <copyright file="Material.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

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

        public override int GetHashCode()
        {
            return Color.GetHashCode() ^ Ambient.GetHashCode() ^ Diffuse.GetHashCode() ^ Specular.GetHashCode() ^ Shininess.GetHashCode();
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
                && other.Shininess.ApproximateEquals(Shininess));
        }

        public RtColor Lighting(PointLight light, RtPoint point, RtVector eyeVector, RtVector normalVector, bool inShadow = false)
        {
            //Console.Write($"{eyeVector.ToString()}|");
            //Console.Write($"{normalVector.ToString()}|");
            
            var effectiveColor = Color * light.Intensity;
            var lightVector = (light.Position - point).Normalized();
            //Console.Write($"{lightVector.ToString()}|");
            //Console.Write($"{lightVector.Negate().ToString()}|");
            
            var lightDotNormal = lightVector.Dot(normalVector);

            var ambient = effectiveColor * Ambient;

            RtColor diffuse;
            RtColor specular;

            if (lightDotNormal < 0 || inShadow)
            {
                diffuse = RtColor.Black;
                specular = RtColor.Black;
            }
            else
            {
                diffuse = effectiveColor * Diffuse * lightDotNormal;

                var reflectVector = lightVector.Negate().Reflect(normalVector);
                //Console.Write($"{reflectVector.ToString()}|");
                var reflectDotEye = reflectVector.Dot(eyeVector);
                // Console.Write($"{reflectDotEye.ToString()}|");
                
                if (reflectDotEye <= 0)
                {
                    specular = RtColor.Black;
                }
                else
                {
                    var factor = Math.Pow(reflectDotEye, Shininess);
                    specular = light.Intensity * Specular * factor;
                }
                //Console.Write($"{specular}");
            }

            var results = ambient + diffuse + specular;
            return results;
        }
    }
}
