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
            var projectile = new Projectile(new RtPoint(0, 1, 0), new RtVector(1, 1, 0).Normalize());
            var environment = new RtEnvironment(new RtVector(0, -0.1, 0), new RtVector(-0.01, 0, 0));

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
