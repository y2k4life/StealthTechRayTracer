//-----------------------------------------------------------------------
// <copyright file="Projectile.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Exercise
{
    public class Projectile
    {
        public Projectile(RtPoint position, RtVector velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public RtPoint Position { get; set; }

        public RtVector Velocity { get; set; }

        public override string ToString()
        {
            return $"{Position} (v={Velocity})";
        }
    }
}