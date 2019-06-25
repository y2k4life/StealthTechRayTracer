//-----------------------------------------------------------------------
// <copyright file="ChapterFive.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.EasyConsole;
using StealthTech.RayTracer.Library;
using System;
using System.Threading.Tasks;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterSix
    {
        public void NormalSphere()
        {
            var canvas = Run(new Sphere()
            {
                Material = new Material { Color = new RtColor(1, 0.2, 1) }
            });

            PpmOutput.WriteToFile("sphere.ppm", canvas.GetPPMContent());
        }

        public void ShrinkAlongYAxis()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(1, 0.5, 1),
                Material = new Material { Color = new RtColor(1, 0.2, 1) }
            };
            
            var canvas = Run(shape);
            PpmOutput.WriteToFile("sphere.ppm", canvas.GetPPMContent());
        }

        public void ShrinkAlongXAxis()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.5, 1, 1),
                Material = new Material { Color = new RtColor(1, 0.2, 1) }
            };

            var canvas = Run(shape);
            PpmOutput.WriteToFile("sphere.ppm", canvas.GetPPMContent());
        }

        public void ShrinkAndRotate()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.5, 1, 1)
                    .RotateZ(Math.PI / 4),
                Material = new Material { Color = new RtColor(1, 0.2, 1) }
            };

            var canvas = Run(shape);
            PpmOutput.WriteToFile("sphere.ppm", canvas.GetPPMContent());
        }

        public void ShrinkAndSkew()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.5, 1, 1)
                    .Shearing(1, 0, 0, 0, 0, 0),
                Material = new Material { Color = new RtColor(1, 0.2, 1) }
            };

            var canvas = Run(shape);
            PpmOutput.WriteToFile("sphere.ppm", canvas.GetPPMContent());
        }

        public void Custom()
        {
            var ambiant = Input.ReadDouble("Enter ambient: ");
            var diffuse = Input.ReadDouble("Enter diffuse: ");
            var shininess = Input.ReadDouble("Enter shininess: ");
            var specular = Input.ReadDouble("Enter specular: ");

            var shape = new Sphere()
            {
                Material = new Material
                {
                    Color = new RtColor(1, 0.2, 1),
                    Ambient = ambiant,
                    Diffuse = diffuse,
                    Shininess = shininess,
                    Specular = specular
                }
            };

            var canvas = Run(shape);
            PpmOutput.WriteToFile("sphere.ppm", canvas.GetPPMContent());
        }

        public Canvas Run(Sphere shape)
        {
            var light = new PointLight(new RtPoint(-10, 10, -10), new RtColor(1, 1, 1));

            var rayOrigin = new RtPoint(0, 0, -5);
            var wallZ = 10;

            var wallSize = 7.0;
            var canvasSize = 100;

            var canvas = new Canvas(canvasSize, canvasSize);

            var pixelSize = wallSize / canvasSize;

            var half = wallSize / 2;

            Parallel.For(0, canvasSize, y =>
            {
                var worldY = half - pixelSize * y;
                for (int x = 0; x < canvasSize; x++)
                {
                    var worldX = -half + pixelSize * x;

                    var position = new RtPoint(worldX, worldY, wallZ);

                    var ray = new Ray(rayOrigin, (position - rayOrigin).Normalized());

                    if (shape.Intersect(ray, out (double, double) hits))
                    {
                        var hit = hits.Item1 < hits.Item2 ? hits.Item1 : hits.Item2;

                        var point = ray.Position(hit);
                        var normal = shape.NormalAt(point);
                        var eye = ray.Direction;
                        var color = shape.Material.Lighting(light, point, eye, normal);
                        canvas[x, y] = color;
                    }
                }
            });

            return canvas;
        }
    }
}
