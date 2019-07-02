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
    public class ChapterNine
    {
        public void Run()
        {
            var canvas = Reference(2);

            PpmOutput.WriteToFile("world.ppm", canvas.GetPPMContent());
        }

        public Canvas Render(bool parallel = true)
        {
            World world = DefaultWorld();

            int width = 400;
            int height = 200;

            Camera camera = TopDownCamera(width, height);

            return camera.Render(world, parallel);
        }

        private static Camera DefaultCamera(int width, int height)
        {
            return new Camera(width, height, Math.PI / 2)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(0, 1.5, -5),
                new RtPoint(0, 1, 0),
                new RtVector(0, 1, 0))
            };
        }

        private static Camera TopDownCamera(int width, int height)
        {
            return new Camera(width, height, Math.PI / 1.5)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(0, 2.5, -1),
                new RtPoint(0, 0, 0),
                new RtVector(0, 1, 0))
            };
        }

        private static World DefaultWorld()
        {
            var world = new World();

            var floor = new Plane()
            {
                Material = new Material()
                {
                    Color = new RtColor(1, .9, .9),
                    Specular = 100
                }
            };

            world.Shapes.Add(floor);

            var middle = new Sphere()
            {
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
            return world;
        }

        public Canvas RenderBackdrop(bool parallel = true)
        {
            var world = new World();

            var floor = new Plane()
            {
                Material = new Material()
                {
                    Color = new RtColor(1, 0.9, 0.9),
                    Specular = 0
                }
            };

            world.Shapes.Add(floor);

            var leftWall = new Plane()
            {
                Transform = new Transform()
                    //                    .Scaling(10, 0.01, 10)
                    .RotateX(Math.PI / 2)
                    .RotateY(-Math.PI / 4)
                    .Translation(0, 0, 3),
                Material = floor.Material
            };

            world.Shapes.Add(leftWall);

            var middle = new Sphere()
            {
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
                Transform = new Transform()
                    .Scaling(0.5, 2, 0.5)
                    .Translation(1.5, 2, -0.5),
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

            world.Lights.Add(new PointLight(new RtPoint(10, 10, -10), new RtColor(1, 1, 1)));

            var camera = new Camera(800, 400, Math.PI / 2)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(0, 1.5, -5),
                new RtPoint(0, 1, 0),
                new RtVector(0, 1, 0))
            };

            // return camera.Render(world, new RtPoint(339, 158, 0), new RtPoint(339, 168, 0));
            return camera.Render(world, parallel);
        }

        public Canvas Reference(double radians)
        {
            var world = new World();

            world.Shapes.Add(CreateWall(0, new RtPoint(0, 0, 125), new RtColor(0, 0, .75)));

            world.Shapes.Add(CreateWall(-(2 * Math.PI / 3), new RtPoint(225, 0, -25), new RtColor(.25, .75, 0)));
            world.Shapes.Add(CreateWall(2 * Math.PI / 3, new RtPoint(225, 0, -25), new RtColor(0, .75, 0)));

            world.Shapes.Add(CreateWall(0, new RtPoint(0, 0, -175), new RtColor(0, 0, .35)));

            world.Shapes.Add(CreateWall(2 * Math.PI / 3, new RtPoint(-225, 0, -25), new RtColor(.25, .75, 0)));
            world.Shapes.Add(CreateWall(-(2 * Math.PI) / 3, new RtPoint(-225, 0, -25), new RtColor(0, .75, 0)));

            var floor = new Plane()
            {
                Material = new Material()
                {
                    Color = new RtColor(0, 0, 0),
                    Specular = 200
                }
            };

            world.Shapes.Add(floor);


            var middle = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(10, 10, 10)
                    .Translation(0, 10, 0),
                Material = new Material()
                {
                    Color = new RtColor(0, 1, 0),
                    Diffuse = 0.7,
                    Specular = 0.3
                }
            };

            world.Shapes.Add(middle);

            world.Lights.Add(new PointLight(new RtPoint(-30, 30, 0), new RtColor(1, 1, 1)));

            var camera = new Camera(800, 400, 1.34913951)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(0, 24, -1),
                new RtPoint(0, 0, 0),
                new RtVector(.1, 1, 0))
            };

            return camera.Render(world);
        }

        private static Plane CreateWall(double yRotate, RtPoint location, RtColor color)
        {
            return new Plane()
            {
                Transform = new Transform()
                    .RotateX(Math.PI / 2)
                    .RotateY(yRotate)
                    .Translation(location),
                Material = new Material()
                {
                    Color = color,
                    Specular = 1
                }
            };
        }
    }
}
