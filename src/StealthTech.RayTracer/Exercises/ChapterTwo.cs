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
            var p = new Projectile(RtTuple.Point(0, 1, 0), RtTuple.Vector(1, 1.8, 0).Normalized * 11.3);
            var e = new RtEnvironment(RtTuple.Vector(0, -0.1, 0), RtTuple.Vector(-0.01, 0, 0));
            var c = new Canvas(900, 550);
            while (p.Position.Y >= 0)
            {
                Draw(c, p.Position);
                p = Tick(p, e);
            }
            c.Save("file.ppm");
        }

        private static Projectile Tick(Projectile p, RtEnvironment e)
        {
            return new Projectile(p.Position + p.Velocity, p.Velocity + e.Gravity + e.Wind);
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
