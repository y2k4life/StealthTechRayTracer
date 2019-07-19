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
            var newOrigin = tranformMatrix * Origin;
            var newDirection = tranformMatrix * Direction;

            return new Ray(newOrigin, newDirection);
        }

        public override string ToString()
        {
            return $"O: {Origin.X.ToString("####.#0000")}, {Origin.Y.ToString("####.#0000")}, {Origin.Z.ToString("####.#0000")} D: {Direction.X.ToString("####.#0000")}, {Direction.Y.ToString("####.#0000")}, {Direction.Z.ToString("####.#0000")}";
        }
    }
}
