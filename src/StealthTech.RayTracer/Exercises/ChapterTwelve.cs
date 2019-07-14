using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterTwelve
    {
        readonly Animation _animation;

        public ChapterTwelve(Animation animation)
        {
            _animation = animation;
        }

        public Canvas Render(int frame = 0, bool parallel = true)
        {
            World world = RoomWithTable();

            // var world = World.DefaultWorld();

            //int width = 1920;
            //int height = 1080;

            int width = 960;
            int height = 540;

            //int width = 200;
            //int height = 100;

            //int width = 400;
            //int height = 200;

            Camera camera = InTheGroundCameraAnim(width, height);

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
                new RtPoint(0, 10, -40),
                new RtPoint(0, 1, 1),
                new RtVector(0, 1, 0))
            };
        }

        private World RoomWithTable()
        {
            var world = new World();

            var degrees = _animation.Offset(1, 13, 0, 360);
            Console.WriteLine(degrees);
            var radians = DegreesToRadians(degrees);

            world.Shapes.Add(new Cube()
            {
                Transform = new Transform()
                    .Scaling(400, 400, 400)
                    .RotateY(Math.PI / 3),
                Material = new Material
                {
                    Color = new RtColor(.80, .80, .80)
                }
            });

            world.Shapes.Add(new Cube()
            {
                Transform = new Transform()
                    .Scaling(10, .5, -5)

                    .Translation(0, .1, 0),
                Material = new Material
                {
                    Pattern = new CheckersPattern(new RtColor(1, 0, 0), new RtColor(0, 0, 1))
                    {
                        Transform = new Transform()
                            .Scaling(.5, .5, .5)
                    }
                    
                }
            });

            world.Lights.Add(new PointLight(new RtPoint(-10, 10, -10), new RtColor(1, 1, 1)));

            return world;
        }

        public double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
}
