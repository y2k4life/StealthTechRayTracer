//-----------------------------------------------------------------------
// <copyright file="ChapterThirteen.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterThirteen
    {
        public void Run()
        {
            World world = CylinderWorld();

            int width = 800;
            int height = 450;

            var camera = new Camera(width, height, 0.314)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(8, 3.5, -9),
                new RtPoint(0, 0.3, 0),
                new RtVector(0, 1, 0))
            };

            var canvas = camera.Render(world, true);
            // var canvas = camera.Render(world, 317, 58, 2, 1);
            PpmOutput.WriteToFile("world.ppm", canvas.GetPPMContent());

            return;
        }

        public World CylinderWorld()
        {
            var world = new World();

            world.Lights.Add(new PointLight(
                new RtPoint(1, 6.9, -4.9),
                new RtColor(1, 1, 1)));

            world.Shapes.Add(new Plane()
            {
                Material = new Material
                {
                    Pattern = new CheckersPattern(new RtColor(0.5, 0.5, 0.5), new RtColor(0.75, 0.75, 0.75))
                    {
                        Transform = new Transform()
                            .Scaling(0.25, 0.25, 0.25)
                            .RotateY(0.3)
                    },
                    Ambient = 0.2,
                    Diffuse = 0.9,
                    Specular = 0
                }
            });

            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0,
                Maximum = 0.75,
                IsClosed = true,
                Transform = new Transform()
                    .Scaling(0.5, 1, 0.5)
                    .Translation(-1, 0, 1),
                Material = new Material
                {
                    Color = new RtColor(0, 0, 0.6),
                    Diffuse = 0.1,
                    Specular = 0.9,
                    Shininess = 300,
                    Reflective = 0.9
                },
            });

            // concentric circles
            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0,
                Maximum = 0.2,
                Transform = new Transform()
                    .Scaling(0.8, 1, 0.8)
                    .Translation(1, 0, 0),
                Material = new Material
                {
                    Color = new RtColor(1, 1, 0.3),
                    Ambient = 0.1,
                    Diffuse = 0.8,
                    Specular = 0.9,
                    Shininess = 300
                },
            });

            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0,
                Maximum = 0.3,
                Transform = new Transform()
                    .Scaling(0.6, 1, 0.6)
                    .Translation(1, 0, 0),
                Material = new Material
                {
                    Color = new RtColor(1, 0.9, 0.4),
                    Ambient = 0.1,
                    Diffuse = 0.8,
                    Specular = 0.9,
                    Shininess = 300
                },
            });

            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0,
                Maximum = 0.4,
                Transform = new Transform()
                    .Scaling(0.4, 1, 0.4)
                    .Translation(1, 0, 0),
                Material = new Material
                {
                    Color = new RtColor(1, 0.8, 0.5),
                    Ambient = 0.1,
                    Diffuse = 0.8,
                    Specular = 0.9,
                    Shininess = 300
                },
            });

            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0,
                Maximum = 0.5,
                IsClosed = true,
                Transform = new Transform()
                    .Scaling(0.2, 1, 0.2)
                    .Translation(1, 0, 0),
                Material = new Material
                {
                    Color = new RtColor(1, 0.7, 0.6),
                    Ambient = 0.1,
                    Diffuse = 0.8,
                    Specular = 0.9,
                    Shininess = 300
                },
            });

            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0.0,
                Maximum = 0.3,
                IsClosed = true,
                Transform = new Transform()
                    .Scaling(.05, 1, .05)
                    .Translation(0, 0, -.75),
                Material = new Material
                {
                    Color = new RtColor(1, 0, 0),
                    Ambient = 0.1,
                    Diffuse = 0.9,
                    Specular = 0.9,
                    Shininess = 300,
                },
            });

            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0.0,
                Maximum = 0.3,
                IsClosed = true,
                Transform = new Transform()
                    .Scaling(.05, 1, .05)
                    .Translation(0, 0, 1.5)
                    .RotateY(-.15)
                    .Translation(0, 0, -2.25),
                Material = new Material
                {
                    Color = new RtColor(1, 1, 0),
                    Ambient = 0.1,
                    Diffuse = 0.9,
                    Specular = 0.9,
                    Shininess = 300,
                },
            });

            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0.0,
                Maximum = 0.3,
                IsClosed = true,
                Transform = new Transform()
                    .Scaling(.05, 1, .05)
                    .Translation(0, 0, 1.5)
                    .RotateY(-0.3)
                    .Translation(0, 0, -2.25),
                Material = new Material
                {
                    Color = new RtColor(0, 1, 0),
                    Ambient = 0.1,
                    Diffuse = 0.9,
                    Specular = 0.9,
                    Shininess = 300,
                },
            });

            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0.0,
                Maximum = 0.3,
                IsClosed = true,
                Transform = new Transform()
                    .Scaling(.05, 1, .05)
                    .Translation(0, 0, 1.5)
                    .RotateY(-0.45)
                    .Translation(0, 0, -2.25),
                Material = new Material
                {
                    Color = new RtColor(0, 1, 1),
                    Ambient = 0.1,
                    Diffuse = 0.9,
                    Specular = 0.9,
                    Shininess = 300,
                },
            });

            // Glass
            world.Shapes.Add(new Cylinder()
            {
                Minimum = 0.0001,
                Maximum = 0.5,
                IsClosed = true,
                Transform = new Transform()
                    .Scaling(0.33, 1, 0.33)
                    .Translation(0, 0, -1.5),
                Material = new Material
                {
                    Color = new RtColor(0.25, 0, 0),
                    Diffuse = 0.1,
                    Specular = 0.9,
                    Shininess = 300,
                    Reflective = 0.9,
                    Transparency = 0.9,
                    RefractiveIndex = 1.5
                },
            });

            return world;
        }
    }
}
