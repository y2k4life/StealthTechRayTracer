//-----------------------------------------------------------------------
// <copyright file="ChapterOne.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Exercise;
using StealthTech.RayTracer.Library;
using System;

namespace StealthTech.RayTracer.Exercises
{
    public class ChapterOne
    {
        public void Run()
        {
            var p = new Projectile(RtTuple.Point(0, 1, 0), RtTuple.Vector(1, 1, 0).Normalized);
            var e = new RtEnvironment(RtTuple.Vector(0, -0.1, 0), RtTuple.Vector(-0.01, 0, 0));
            int i = 0;
            while (p.Position.Y >= 0)
            {
                i++;
                Console.WriteLine($"{i} - {p}");
                p = Update(p, e);
            }
        }

        public static Projectile Update(Projectile p, RtEnvironment e)
        {
            return new Projectile(p.Position + p.Velocity, p.Velocity + e.Gravity + e.Wind);
        }
    }
}
