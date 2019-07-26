//-----------------------------------------------------------------------
// <copyright file="ChapterOne.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterSeven
    {
        
        public void Run()
        {
            var canvas = Render();

            PpmOutput.WriteToFile("world.ppm", canvas.GetPPMContent());
        }

        public Canvas Render(bool parallel = true)
        {
            var world = new World();

            var floor = new Sphere()
            {
                Name = "Floor",
                Transform = new Transform().Scaling(10, 0.01, 10),
                Material = new Material()
                {
                    Color = new RtColor(1, 0.9, 0.9),
                    Specular = 0
                }
            };

            world.Shapes.Add(floor);

            var leftWall = new Sphere()
            {
                Name = "Left Wall",
                Transform = new Transform()
                    .Scaling(10, 0.01, 10)
                    .RotateX(Math.PI / 2)
                    .RotateY(-Math.PI / 4)
                    .Translation(0, 0, 5),
                Material = new Material()
                {
                    Color = new RtColor(0, 1, 0),
                    Specular = 0
                }
            };

            world.Shapes.Add(leftWall);

            var rightWall = new Sphere()
            {
                Name = "Right Wall",
                Transform = new Transform()
                    .Scaling(10, 0.01, 10)
                    .RotateX(Math.PI / 2)
                    .RotateY(Math.PI / 4)
                    .Translation(0, 0, 5),
                Material = floor.Material
            };

            world.Shapes.Add(rightWall);

            var middle = new Sphere()
            {
                Name = "Middle Ball",
                Transform = new Transform()
                    .Translation(-0.5, 1, 0.5),
                Material = new Material()
                {
                    Color = new RtColor(0.1, 1, 0.5),
                    Diffuse = 0.7,
                    Specular = 0.3
                }
            };

            world.Shapes.Add(middle);

            var right = new Sphere()
            {
                Name = "Right Ball",
                Transform = new Transform()
                    .Scaling(0.5, 0.5, 0.5)
                    .Translation(1.5, 0.5, -0.5),
                Material = new Material()
                {
                    Color = new RtColor(0.5, 1, 0.1),
                    Diffuse = 0.7,
                    Specular = 0.3
                }
            };

            world.Shapes.Add(right);

            var left = new Sphere()
            {
                Name = "Left Ball",
                Transform = new Transform()
                    .Scaling(0.33, 0.33, 0.33)
                    .Translation(-1.5, 0.33, -0.75),
                Material = new Material()
                {
                    Color = new RtColor(1, 0.8, 0.1),
                    Diffuse = 0.7,
                    Specular = 0.3
                }
            };

            world.Shapes.Add(left);

            world.Lights.Add(new PointLight(new RtPoint(-10, 10, -10), new RtColor(1, 1, 1)));

            var camera = new Camera(1920, 1080, Math.PI / 2)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(0, 1.5, -5),
                new RtPoint(0, 1, 0),
                new RtVector(0, 1, 0))
            };

            return camera.Render(world);
            // return camera.Render(world, 94, 18, 1, 1);
        }
    }
}
