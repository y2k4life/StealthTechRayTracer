//-----------------------------------------------------------------------
// <copyright file="ChapterFifteen.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterFifteen
    {
        public void Run()
        {
            World world = TriangleWorld();

            int width = 800;
            int height = 400;

            var camera = new Camera(width, height, Math.PI / 2)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(0, 1.5, -1.5),
                new RtPoint(0, 1, 0),
                new RtVector(0, 1, 0))
            };

            //var canvas = camera.Render(world, 441, 253, 1, 2);
            var canvas = camera.Render(world, false);
            PpmOutput.WriteToFile("world.ppm", canvas.GetPPMContent());

            return;
        }

        public World TriangleWorld()
        {
            var world = new World();

            world.Lights.Add(new PointLight(
                new RtPoint(-5, 8.9, -3),
                new RtColor(1, 1, 1)));

            world.Shapes.Add(new Plane()
            {
                Material = new Material
                {
                    Pattern = new CheckersPattern(new RtColor(1, 0, 0), new RtColor(0.75, 0.75, 0.75))
                    {
                        Transform = new Transform()
                            .Scaling(0.1, 0.1, 0.1)
                    },
                    Diffuse = 0.1,
                    Specular = 0.9,
                    Shininess = 300,
                    Reflective = 0.9
                }
            });

            var parser = new ObjReader();
            var objFile = parser.ParseFile(@"./ObjFiles/teapot.obj");
            // var teapot = objFile.Mesh.Scale();

            var teapot = new Cube();

            teapot.Material = new Material
            {
                Pattern = new GradientRingPattern(new RtColor(1, 0, 0), new RtColor(0, 0, 1), new RtColor(0, 0, 1))
                {
                    Transform = new Transform()
                        .Scaling(0.1, 0.1, 0.1)
                }
            };

            teapot.Transform = new Transform()
                .Scaling(0.5, 0.5, 0.5)
                .RotateX(-Math.PI / 2)
                .Translation(0, 1, 0);

            world.Shapes.Add(teapot);

            return world;
        }

    }
}
