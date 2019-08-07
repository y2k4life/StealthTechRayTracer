//-----------------------------------------------------------------------
// <copyright file="World.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace StealthTech.RayTracer.Library
{
    public class World
    {
        public static World DefaultWorld()
        {
            var defaultWorld = new World();
            var shape1 = new Sphere()
            {
                Material =
                {
                    Color = new RtColor(0.8, 1.0, 0.6),
                    Diffuse = 0.7,
                    Specular = 0.2
                }
            };
            defaultWorld.Shapes.Add(shape1);

            var shape2 = new Sphere()
            {
                Transform = new Transform().Scaling(0.5, 0.5, 0.5)
            };
            defaultWorld.Shapes.Add(shape2);

            defaultWorld.Lights.Add(new PointLight(new RtPoint(-10, 10, -10), RtColor.White));

            return defaultWorld;
        }

        public IntersectionList Intersect(Ray ray)
        {
            var intersections = new IntersectionList();
            foreach (var shape in Shapes)
            {
                var shapsesIntersections = shape.Intersect(ray);
                intersections.AddRange(shapsesIntersections);
            }

            return intersections;
        }

        public RtColor ColorAt(Ray ray, int remaining)
        {
            var intersections = Intersect(ray);

            var hit = intersections.Hit();
            if (hit == null)
            {
                return RtColor.Black;
            }

            var computations = hit.PrepareComputations(ray, intersections);
            return ShadeHit(computations, remaining);
        }

        public RtColor ShadeHit(Computations computations, int remaining)
        {
            var colorTotal = RtColor.Black;

            foreach (var light in Lights)
            {
                // var inShadow = IsShadowed(light.Position, computations.OverPosition);
                var intensity = light.IntensityAt(computations.OverPosition, this);
                var surface = computations.Shape.Material.Lighting(
                    computations,
                    light,
                    intensity);

                var reflected = ReflectedColor(computations, remaining);
                var refracted = RefractedColor(computations, remaining);

                var material = computations.Shape.Material;
                if (material.Reflective > 0 && material.Transparency > 0)
                {
                    var reflectance = computations.Schlick();
                    colorTotal += surface + reflected * reflectance + refracted * (1 - reflectance);
                }
                else
                {
                    colorTotal += surface + reflected + refracted;
                }
            }

            return colorTotal;
        }

        public RtColor ReflectedColor(Computations computations, int remaining)
        {
            if (computations.Shape.Material.Reflective == 0 || remaining <= 0)
            {
                return RtColor.Black;
            }

            var reflectRay = new Ray(computations.OverPosition, computations.ReflectVector);
            var reflectColor = ColorAt(reflectRay, remaining - 1);

            return reflectColor * computations.Shape.Material.Reflective;
        }

        public bool IsShadowed(RtPoint lightPosition, RtPoint point)
        {
            var vector = lightPosition - point;
            var distance = vector.Magnitude();
            var direction = vector.Normalize();

            var ray = new Ray(point, direction);
            var intersetions = Intersect(ray);

            var hit = intersetions.ShadowHit();

            if (hit != null && hit.Time < distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public RtColor RefractedColor(Computations computations, int remaining)
        {
            if (computations.Shape.Material.Transparency == 0 || remaining == 0)
            {
                return RtColor.Black;
            }

            var nRatio = computations.n1 / computations.n2;
            var cosi = computations.EyeVector.Dot(computations.NormalVector);
            var sin2t = Math.Pow(nRatio, 2) * (1 - Math.Pow(cosi, 2));

            if (sin2t > 1)
            {
                return RtColor.Black;
            }

            var cost = Math.Sqrt(1.0 - sin2t);
            var direction = computations.NormalVector * (nRatio * cosi - cost) - computations.EyeVector * nRatio;
            var refractRay = new Ray(computations.UnderPosition, direction);

            var color = ColorAt(refractRay, remaining - 1) * computations.Shape.Material.Transparency;

            return color;
        }

        public List<Shape> Shapes { get; } = new List<Shape>();

        public List<Light> Lights { get; } = new List<Light>();
    }
}
