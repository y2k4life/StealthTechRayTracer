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

            defaultWorld.Lights.Add(new PointLight(new RtPoint(-10, 10, -10), new RtColor(1, 1, 1)));

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

        public RtColor ShadeHit(Computations computations)
        {
            var colorTotal = RtColor.Black;
            
            foreach (var light in Lights)
            {
                var inShadow = IsShadowed(computations.OverPoint, light);
                var lighting = computations.Shape.Material.Lighting(
                    computations.Shape,
                    light,
                    computations.Point,
                    computations.EyeVector,
                    computations.NormalVector,
                    inShadow);

                colorTotal += lighting;
            }

            return colorTotal;
        }

        public RtColor ColorAt(Ray ray)
        {
            var intersections = Intersect(ray);

            var hit = intersections.Hit();
            if (hit == null)
            {
                return RtColor.Black;
            }
            
            var computations = hit.PrepareComputations(ray);
            return ShadeHit(computations);
        }

        public bool IsShadowed(RtPoint point, PointLight light)
        {
            var vector = light.Position - point;
            var distance = vector.Magnitude();
            var direction = vector.Normalize();

            var ray = new Ray(point, direction);
            var intersetions = Intersect(ray);

            var hit = intersetions.Hit();
            if (hit != null && hit.Time < distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Shape> Shapes { get; } = new List<Shape>();

        public List<PointLight> Lights { get; } = new List<PointLight>();
    }
}
