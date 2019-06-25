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
            Run(new Sphere()
            {
                Material = new Material { Color = new RtColor(1, 0.2, 1) }
            });
        }

        public void ShrinkAlongYAxis()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(1, 0.5, 1),
                Material = new Material { Color = new RtColor(1, 0.2, 1) }
            };

            Run(shape);
        }

        public void ShrinkAlongXAxis()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.5, 1, 1),
                Material = new Material { Color = new RtColor(1, 0.2, 1) }
            };

            Run(shape);
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

            Run(shape);
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

            Run(shape);
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

            Run(shape);
        }

        public void Run(Sphere shape)
        {
            var light = new PointLight(new RtPoint(-10, 10, -10), new RtColor(1, 1, 1));

            var rayOrigin = new RtPoint(0, 0, -5);
            var wallZ = 10;

            var wallSize = 7.0;
            var canvasSize = 800;

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

                    var intersections = new IntersectionList(shape.Intersect(ray));
                    var intersection = intersections.Hit();

                    if (intersection != null)
                    {
                        var point = ray.Position(intersection.Time);
                        var normal = intersection.Shape.NormalAt(point);
                        var eye = ray.Direction;
                        var color = intersection.Shape.Material.Lighting(light, point, eye, normal);
                        canvas[x, y] = color;
                    }
                }
            });

            PpmOutput.WriteToFile("sphere.ppm", canvas.GetPPMContent());
        }
    }
}
