//-----------------------------------------------------------------------
// <copyright file="ChapterFourteen.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterFourteen
    {
        public void Run()
        {
            World world = CylinderWorld();

            int width = 800;
            int height = 450;

            var camera = new Camera(width, height, 0.314)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(8, 5, -13),
                new RtPoint(0, 0.9, 0),
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
                new RtPoint(5, 8.9, -10.9),
                new RtColor(.8, .8, .8)));

            world.Lights.Add(new PointLight(
                new RtPoint(-5, 8.9, 10.9),
                new RtColor(.25, .25, .25)));

            world.Shapes.Add(new Plane()
            {
                Material = new Material
                {
                    Pattern = new CheckersPattern(new RtColor(0.9, 0.5, 0.5), new RtColor(0.75, 0.75, 0.75))
                    {
                        Transform = new Transform()
                            .Scaling(0.25, 0.25, 0.25)
                            .RotateY(0.3)
                    },
                    Diffuse = 0.1,
                    Specular = 0.9,
                    Shininess = 300,
                    Reflective = 0.9
                }
            });

            var hexagon = Hexagon();
            hexagon.Material = new Material
            {
                Pattern = new PerturbedStripePattern(new RtColor(0, .9, 0), new RtColor(.1, .3, .1))
            };

            hexagon.Transform = new Transform()
                .RotateX(-Math.PI / 3)
                .RotateY(Math.PI / 1.5)
                .Translation(0, 1, 0);

            world.Shapes.Add(hexagon);

            return world;
        }

        private Shape Hexagon()
        {
            var hexagon = new ShapeGroup();

            for (int n = 0; n < 6; n++)
            {
                var side = HexagonSide();
                side.Transform = new Transform()
                    .RotateY(n * Math.PI / 3);
                hexagon.AddChild(side);
            }

            return hexagon;
        }

        private Shape HexagonSide()
        {
            var side = new ShapeGroup()
            {
                InheritMaterial = true
            };

            side.AddChild(HexagonCorner());
            side.AddChild(HexagonEdge());

            return side;
        }

        private Shape HexagonCorner()
        {
            var corner = new Sphere
            {
                Transform = new Transform()
                    .Scaling(0.25, 0.25, 0.25)
                    .Translation(0, 0, -1),
                Material = new Material
                {
                    Color = new RtColor(0.75, 0.75, 0.75),
                    Diffuse = 0.1,
                    Specular = 0.9,
                    Shininess = 300,
                    Reflective = 0.9
                }
            };

            return corner;
        }

        private Shape HexagonEdge()
        {
            var edge = new Cylinder()
            {
                Minimum = 0,
                Maximum = 1,
                Transform = new Transform()
                    .Scaling(0.25, 1, 0.25)
                    .RotateZ(-Math.PI / 2)
                    .RotateY(-Math.PI / 6)
                    .Translation(0, 0, -1),
                InheritMaterial = true
            };

            return edge;
        }
    }
}
