//-----------------------------------------------------------------------
// <copyright file="ChapterFive.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;
using System.Threading.Tasks;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterFive
    {
        public void NormalSphere()
        {
            Run(new Sphere());
        }

        public void ShrinkAlongYAxis()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(1, 0.5, 1)
            };

            Run(shape);
        }

        public void ShrinkAlongXAxis()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.5, 1, 1)
            };

            Run(shape);
        }


        public void ShrinkAndRotate()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.5, 1, 1)
                    .RotateZ(Math.PI / 4)
                    
            };

            Run(shape);
        }

        public void ShrinkAndSkew()
        {
            var shape = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.5, 1, 1)
                    .Shearing(1, 0, 0, 0, 0, 0)
            };

            Run(shape);
        }

        public void Run(Sphere shape)
        {
            var rayOrigin = new RtPoint(0, 0, -5);
            var wallZ = 10;
            var color = new RtColor(1, 0, 0);

            var wallSize = 7.0;
            var canvasSize = 800;

            var canvas = new Canvas(canvasSize, canvasSize);

            var pixelSize = wallSize / canvasSize;

            var half = wallSize / 2;

            Parallel.For(0, canvasSize, y =>
            {
                for (int x = 0; x < canvasSize; x++)
                {
                    var worldY = half - pixelSize * y;
                    var worldX = -half + pixelSize * x;

                    var position = new RtPoint(worldX, worldY, wallZ);

                    var ray = new Ray(rayOrigin, (position - rayOrigin).Normalized());

                    if (shape.Intersect(ray).Count > 0)
                    {
                        canvas[x, y] = color;
                    }
                }
            });

            PpmOutput.WriteToFile("sphere.ppm", canvas.GetPPMContent());
        }
    }
}
