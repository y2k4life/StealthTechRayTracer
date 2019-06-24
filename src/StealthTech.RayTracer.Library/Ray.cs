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
        public Ray(RtTuple origin, RtTuple direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public RtTuple Origin { get; set; }

        public RtTuple Direction { get; set; }

        public RtTuple Position(double time)
        {
            return Origin + Direction * time;
        }

        public Ray Transform(RtMatrix tranformMatrix)
        {
            var newOrigin = Origin * tranformMatrix;
            var newDirection = Direction * tranformMatrix;

            return new Ray(newOrigin, newDirection);
        }
    }
}
