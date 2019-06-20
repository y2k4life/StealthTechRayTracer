//-----------------------------------------------------------------------
// <copyright file="ChapterTwo.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Exercise;
using StealthTech.RayTracer.Library;
using System;
using System.IO;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterTwo
    {
        public void Run()
        {
            var projectile = new Projectile(RtTuple.Point(0, 1, 0), RtTuple.Vector(1, 1.8, 0).Normalized * 11.3);
            var environment = new RtEnvironment(RtTuple.Vector(0, -0.1, 0), RtTuple.Vector(-0.01, 0, 0));
            var canvase = new Canvas(900, 550);

            while (projectile.Position.Y >= 0)
            {
                Draw(canvase, projectile.Position);
                projectile = Tick(projectile, environment);
            }

            File.WriteAllText("file.ppm", canvase.GetPPMContent());
        }

        private static Projectile Tick(Projectile projectile, RtEnvironment environment)
        {
            return new Projectile(projectile.Position + projectile.Velocity, 
                projectile.Velocity + environment.Gravity + environment.Wind);
        }

        private static void Draw(Canvas canvas, RtTuple position)
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
