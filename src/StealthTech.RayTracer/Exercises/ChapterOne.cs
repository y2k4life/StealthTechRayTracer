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
            var projectile = new Projectile(RtTuple.Point(0, 1, 0), RtTuple.Vector(1, 1, 0).Normalized);
            var environment = new RtEnvironment(RtTuple.Vector(0, -0.1, 0), RtTuple.Vector(-0.01, 0, 0));

            int i = 0;
            while (projectile.Position.Y >= 0)
            {
                i++;
                Console.WriteLine($"{i} - {projectile}");
                projectile = new Projectile(projectile.Position + projectile.Velocity,
                    projectile.Velocity + environment.Gravity + environment.Wind);
            }
        }
    }
}
