//-----------------------------------------------------------------------
// <copyright file="Ray.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class Ray
    {
        public Ray(RtPoint origin, RtVector direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public RtPoint Origin { get; set; }

        public RtVector Direction { get; set; }

        public RtPoint Position(double time)
        {
            return Origin + Direction * time;
        }

        public Ray Transform(RtMatrix tranformation)
        {
            var newOrigin = tranformation * Origin;
            var newDirection = tranformation * Direction;

            return new Ray(newOrigin, newDirection);
        }

        public Ray Transform(Transform transform)
        {
            var newOrigin = transform * Origin;
            var newDirection = transform * Direction;

            return new Ray(newOrigin, newDirection);
        }

        public override string ToString()
        {
            return $"O: {Origin.X.ToString("####.#0000")}, {Origin.Y.ToString("####.#0000")}, {Origin.Z.ToString("####.#0000")} D: {Direction.X.ToString("####.#0000")}, {Direction.Y.ToString("####.#0000")}, {Direction.Z.ToString("####.#0000")}";
        }


    }
}
