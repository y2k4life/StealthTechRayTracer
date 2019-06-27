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
                if (shape.Intersect(ray, out (double, double) hits))
                {
                    intersections.Add(new Intersection(hits.Item1, shape));
                    intersections.Add(new Intersection(hits.Item2, shape));
                }
            }

            return intersections;
        }

        public RtColor ShadeHit(Computations computations)
        {
            var colorTotal = RtColor.Black;
            
            foreach (var light in Lights)
            {
                var inShadow = IsShadowed(computations.OverPoint, light);
                var lighting = computations.Shape.Material.Lighting(light,
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
            if (intersections.Count == 0)
            {
                return RtColor.Black;
            }

            var hit = intersections[0];
            var computations = hit.PrepareComputations(ray);
            return ShadeHit(computations);
        }

        public bool IsShadowed(RtPoint point, PointLight light)
        {
            var vector = light.Position - point;
            var distance = vector.Magnitude();
            var direction = vector.Normalized();

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

        public List<Sphere> Shapes { get; } = new List<Sphere>();

        public List<PointLight> Lights { get; } = new List<PointLight>();
    }
}
