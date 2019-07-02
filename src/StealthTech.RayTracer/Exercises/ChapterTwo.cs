//-----------------------------------------------------------------------
// <copyright file="ChapterTwo.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Exercise;
using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterTwo
    {
        public void Run()
        {
            var projectile = new Projectile(new RtPoint(0, 1, 0), new RtVector(1, 1.8, 0).Normalize() * 11.3);
            var environment = new RtEnvironment(new RtVector(0, -0.1, 0), new RtVector(-0.01, 0, 0));
            var canvas = new Canvas(900, 550);

            while (projectile.Position.Y >= 0)
            {
                Draw(canvas, projectile.Position);
                projectile = Tick(projectile, environment);
            }

            PpmOutput.WriteToFile("file.ppm", canvas.GetPPMContent());
        }

        private static Projectile Tick(Projectile projectile, RtEnvironment environment)
        {
            return new Projectile(projectile.Position + projectile.Velocity,
                projectile.Velocity + environment.Gravity + environment.Wind);
        }

        private static void Draw(Canvas canvas, RtPoint position)
        {
            var x = (int)Math.Round(position.X);
            var y = canvas.Height - (int)Math.Round(position.Y) - 1;

            if (x >= 0 && x <= canvas.Width - 1 && y >= 0 && y <= canvas.Height - 1)
            {
                canvas[x, y] = new RtColor(1, 0, 0);
            }
        }
    }
}
