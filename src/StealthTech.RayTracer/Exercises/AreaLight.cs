using StealthTech.RayTracer.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace StealthTech.RayTracer.Exercises
{
    public class BonusAreaLight
    {
        public Canvas Run()
        {
            var camera = new Camera(400, 160, 0.7854)
            {
                ViewTransform = new ViewTransform(
                    new RtPoint(-3, 1, 2.5),
                    new RtPoint(0, 0.5, 0),
                    new RtVector(0, 1, 0))
            };

            var world = new World();

            world.Lights.Add(new AreaLight(
                new RtPoint(-1, 2, 4),
                new RtVector(2, 0, 0),
                10,
                new RtVector(0, 2, 0),
                10,
                new RtColor(1.5, 1.5, 1.5)));

            world.Shapes.Add(new Plane
            {
                Material = new Material
                {
                    Color = new RtColor(1, 1, 1),
                    Ambient = 0.025,
                    Diffuse = 0.67,
                    Specular = 0
                }
            });

            world.Shapes.Add(new Cube
            {
                CastShadow = false,
                Material = new Material
                {
                    Color = new RtColor(1.5, 1.5, 1.5),
                    Ambient = 1,
                    Diffuse = 0,
                    Specular = 0
                },
                Transform = new Transform()
                    .Scaling(1, 1, 0.1)
                    .Translation(0, 3, 4)
            });

            world.Shapes.Add(new Sphere
            {
                Transform = new Transform()
                    .Scaling(0.5, 0.5, 0.5)
                    .Translation(0.5, 0.5, 0),
                Material = new Material
                {
                    Color = new RtColor(1, 0, 0),
                    Ambient = 0.1,
                    Specular = 0,
                    Diffuse = 0.6,
                    Reflective = 0.3
                }
            });

            world.Shapes.Add(new Sphere
            {
                Transform = new Transform()
                    .Scaling(0.33, 0.33, 0.33)
                    .Translation(-0.25, 0.33, 0),
                Material = new Material
                {
                    Color = new RtColor(0.5, 0.5, 1),
                    Ambient = 0.1,
                    Specular = 0,
                    Diffuse = 0.6,
                    Reflective = 0.3
                }
            });

            return camera.Render(world);
        }
    }
}
