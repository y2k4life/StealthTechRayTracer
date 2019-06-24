//-----------------------------------------------------------------------
// <copyright file="Ray.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

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

        public Ray Transform(RtMatrix tranformMatrix)
        {
            var newOrigin = new RtPoint(tranformMatrix * Origin);
            var newDirection = new RtVector(tranformMatrix * Direction);

            return new Ray(newOrigin, newDirection);
        }
    }
}
