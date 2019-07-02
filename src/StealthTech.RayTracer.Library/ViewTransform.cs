//-----------------------------------------------------------------------
// <copyright file="ViewTransform.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public class ViewTransform : Transform
    {
        public ViewTransform()
        {
        }

        public ViewTransform(RtPoint from, RtPoint to, RtVector up)
        {
            Up = up;
            To = to;
            From = from;

            Forward = (To - From).Normalize();
            var upNormalized = Up.Normalize();
            Left = Forward.Cross(upNormalized);
            var trueUp = Left.Cross(Forward);
            var orientation = new RtMatrix(4, 4).Identity();

            orientation[0, 0] = Left.X;
            orientation[0, 1] = Left.Y;
            orientation[0, 2] = Left.Z;
            orientation[1, 0] = trueUp.X;
            orientation[1, 1] = trueUp.Y;
            orientation[1, 2] = trueUp.Z;
            orientation[2, 0] = -Forward.X;
            orientation[2, 1] = -Forward.Y;
            orientation[2, 2] = -Forward.Z;

            Matrix = orientation * Translation(-from.X, -from.Y, -from.Z).Matrix;
        }

        public RtVector Forward { get; }

        public RtPoint From { get; }

        public RtPoint To { get; }

        public RtVector Up { get; }

        public RtVector Left { get; }
    }
}
