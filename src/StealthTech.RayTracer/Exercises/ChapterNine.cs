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
        // readonly Animation _animation;

        public ChapterNine(Animation animation)
        {
           // _animation = animation;
        }

        public ChapterNine()
        {
        }

        public void Run()
        {
            var canvas = Render();

            PpmOutput.WriteToFile("world.ppm", canvas.GetPPMContent());
        }

        public Canvas Render(int frame = 0, bool parallel = true)
        {
            World world = Lake();

            // var world = World.DefaultWorld();

            int width = 1920;
            int height = 1080;

            //int width = 960;
            //int height = 540;

            //int width = 200;
            //int height = 100;

            //int width = 400;
            //int height = 200;

            Camera camera = InTheGroundCamera(width, height);

            return camera.Render(world, true);
            // return camera.Render(world, 319, 138, 4, 4);
        }

        private Camera InTheGroundCameraAnim(int width, int height)
        {
            //var camerYValue = _animation.Offset(1, 300, .25, 0.7457627118644068);

            //var camerYPoint = _animation.Offset(1, 210, 1.0, 1.5);

            return new Camera(width, height, Math.PI / 2)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(.5, 0.7457627118644068, -4),
                new RtPoint(-.25, 1.5, 0),
                new RtVector(0, 1, 0))
            };
        }

        private Camera InTheGroundCamera(int width, int height)
        {
            //var camerYValue = _animation.Offset(1, 100, 0, 0.7457627118644068);

            //var camerYPoint = _animation.Offset(1, 70, 1.0, 1.5);

            return new Camera(width, height, Math.PI / 2)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(.5, 0.7457627118644068, -4),
                new RtPoint(-.25, 1.5, 0),
                new RtVector(0, 1, 0))
            };
        }

        private static Camera DefaultCamera(int width, int height)
        {
            return new Camera(width, height, Math.PI / 2)
            {
                ViewTransform = new ViewTransform(
                new RtPoint(.5, 1, -5),
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
                    Pattern = new CheckersPattern(new RtColor(0, 0, 0), new RtColor(1, 1, 1))
                    {
                        Transform = new Transform()
                            .RotateY(Math.PI / 4)
                    },
                    Specular = 10,
                    Reflective = .75

                }
            };

            world.Shapes.Add(floor);

            var leftWall = new Plane()
            {
                Transform = new Transform()
                    .RotateX(Math.PI / 2)
                    .RotateY(-Math.PI / 4)
                    .Translation(0, 0, 5),
                Material = new Material()
                {
                    Color = new RtColor(.25, .25, .25)
                }
            };

            world.Shapes.Add(leftWall);

            var rightWall = new Plane()
            {
                Transform = new Transform()
                    .RotateX(Math.PI / 2)
                    .RotateY(Math.PI / 4)
                    .Translation(0, 0, 5),
                Material = new Material()
                {
                    Color = new RtColor(.25, .25, .25)
                }
            };

            world.Shapes.Add(rightWall);

            var middle = new Sphere()
            {
                Transform = new Transform()
                    .Translation(0, 1, 0),
                Material = new Material
                {
                    Pattern = new PerturbedStripePattern(new RtColor(.90, 0, 0), new RtColor(.99, .99, .99))
                    {
                        Transform = new Transform()
                            .Scaling(.25, .25, .25)
                            .RotateZ(Math.PI / 3)
                    }
                }
            };

            //world.Shapes.Add(middle);

            var right = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.5, 0.5, 0.5)
                    .Translation(.5, 0.5, -2),
                Material = new Material()
                {
                    Reflective = .5,
                    Transparency = 1,
                    RefractiveIndex = 1.5,
                    Diffuse = .2,
                    Ambient = 0,
                    Specular = 1,
                    Shininess = 200
                }
            };

            world.Shapes.Add(right);

            var left = new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.33, 0.33, 0.33)
                    .Translation(-.5, 0.33, 0),
                Material = new Material()
                {
                    Color = new RtColor(1, 0.8, 0.1),
                    //Diffuse = 0.7,
                    //Specular = 0.3
                }
            };

            world.Shapes.Add(left);

            world.Lights.Add(new PointLight(new RtPoint(-10, 20, -10), new RtColor(.75, .75, .75)));
            //world.Lights.Add(new PointLight(new RtPoint(10, 20, -10), new RtColor(.25, .25, .25)));
            return world;
        }

        private World Lake()
        {
            var world = new World();

            // var waterY = _animation.Offset(120, 300, 1.75, .1);

            var water = new Plane()
            {
                Transform = new Transform()
                    .Translation(0, 1, 0),
                CastShadow = false,
                Material = new Material()
                {
                    Color = new RtColor(0, 0, 1),
                    Reflective = 1.2,
                    Transparency = 1,
                    RefractiveIndex = 1.3333,
                    Diffuse = .2,
                    Ambient = .1,
                    Specular = 1,
                    Shininess = 200
                }
            };

            //if (_animation.CurrentFrame < 295)
            //{
            //    world.Shapes.Add(water);
            //}

            // Floor
            world.Shapes.Add(new Plane()
            {
                Material = new Material()
                {
                    Pattern = new CheckersPattern(new RtColor(0.50, 1.00, 0.92), new RtColor(0.00, 0.50, 0.42))
                    {
                        Transform = new Transform()
                            .Scaling(0.5, 0.5, 0.5)
                    },
                    Ambient = .4,
                    Diffuse = .6,
                }
            });

            world.Shapes.Add(
                new Plane()
                {
                    Transform = new Transform()
                        .RotateX(Math.PI / 2)
                        .RotateY(-Math.PI / 4)
                        .Translation(0, 0, 10),
                    Material = new Material()
                    {
                        Color = new RtColor(0.00, 0.75, 1.00),
                        Reflective = .1,
                        Shininess = 100,
                        Ambient = .4,
                        Diffuse = .1
                    }
                });

            // Center Ball
            world.Shapes.Add(new Sphere()
            {
                Transform = new Transform()
                    .Scaling(0.75, 0.75, 0.75)
                    .Translation(.5, 0.75, 0),
                Material = new Material()
                {
                    Pattern = new PerturbedStripePattern(new RtColor(1, 0, 0), new RtColor(1, 1, 1))
                    {
                        Transform = new Transform()
                            .Scaling(0.25, 0.25, 0.25)
                            .RotateZ(Math.PI / 3.2)
                    }
                }
            });

            // Clear Egg
            world.Shapes.Add(
                new Sphere()
                {
                    Transform = new Transform()
                        .Scaling(0.33, 1, 0.33)
                        .Translation(-.75, 1, -1.75),
                    Material = new Material()
                    {
                        Reflective = 1.5,
                        Transparency = 1,
                        RefractiveIndex = 1.0,
                        Diffuse = .2,
                        Ambient = .1,
                        Specular = 1,
                        Shininess = 300
                    }
                });

            // Clear Egg 2
            world.Shapes.Add(
                new Sphere()
                {
                    Transform = new Transform()
                        .Scaling(1, .30, 0.33)
                        .Translation(1.5, .3, -1.75),
                    Material = new Material()
                    {
                        Reflective = 1.5,
                        Transparency = 1,
                        RefractiveIndex = 1.0,
                        Diffuse = .2,
                        Ambient = .1,
                        Specular = 1,
                        Shininess = 300
                    }
                });

            // Purple Ball
            world.Shapes.Add(
                new Sphere()
                {
                    Transform = new Transform()
                        .Translation(-2, 1, -1),
                    Material = new Material()
                    {
                        Color = new RtColor(0.73, 0.60, 1.00),
                        Ambient = .25,
                        Specular = .1,
                        Diffuse = 1,
                        Shininess = 100
                    }
                });

            // Gold Ball
            world.Shapes.Add(new Sphere()
            {
                Transform = new Transform()
                    .Scaling(1.25, 1.25, 1.25)
                    .Translation(2.75, 1.25, -0.60),
                Material = new Material()
                {
                    Color = new RtColor(1, 0.8, 0.1),
                    Specular = .9,
                    Reflective = 0.7,
                    Shininess = 300
                }
            });

            world.Lights.Add(new PointLight(new RtPoint(-15, 30, -15), new RtColor(1, 1, 1)));
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
