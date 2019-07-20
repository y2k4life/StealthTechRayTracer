//-----------------------------------------------------------------------
// <copyright file="BonusAreaLight.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Exercises
{
    public class BonusAreaLight
    {
        private Animation _animation;

        public BonusAreaLight(Animation animation)
        {
            _animation = animation;


        }

        public BonusAreaLight()
        {
        }

        public Canvas Animate()
        {
            var offset = _animation.Offset(0, 400, 0, 360);

            var angle = offset * System.Math.PI / 180;
            var x = 3 * System.Math.Cos(angle);
            var z = 3 * System.Math.Sin(angle);

            var camera = new Camera(1920, 1080, 0.7854)
            {
                ViewTransform = new ViewTransform(
                    new RtPoint(x, 1, z),
                    new RtPoint(0, 0.5, 0),
                    new RtVector(0, 1, 0))
            };

            World world = BuildWorld();

            return camera.Render(world);
        }

        public Canvas Run()
        {
            var camera = new Camera(800, 400, 0.7854)
            {
                ViewTransform = new ViewTransform(
                    new RtPoint(-3, 1, 2.5),
                    new RtPoint(0, 0.5, 0),
                    new RtVector(0, 1, 0))
            };

            World world = BuildWorld();

            return camera.Render(world);
        }

        private static World BuildWorld()
        {
            var world = new World();

            var areaLight = new AreaLight(
                new RtPoint(-1, 2, 4),
                new RtVector(8, 0, 0),
                20,
                new RtVector(0, 8, 0),
                20,
                new RtColor(1.5, 1.5, 1.5));
            areaLight.JitterBy = new NoneDeterministicSequence();

            world.Lights.Add(areaLight);

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
            return world;
        }
    }
}
