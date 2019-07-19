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
            var orientation = RtMatrix.Identity;

            orientation.M11 = Left.X;
            orientation.M12 = Left.Y;
            orientation.M13 = Left.Z;
            orientation.M21 = trueUp.X;
            orientation.M22 = trueUp.Y;
            orientation.M23 = trueUp.Z;
            orientation.M31 = -Forward.X;
            orientation.M32 = -Forward.Y;
            orientation.M33 = -Forward.Z;

            Matrix = orientation * Translation(-from.X, -from.Y, -from.Z).Matrix;
        }

        public RtVector Forward { get; }

        public RtPoint From { get; }

        public RtPoint To { get; }

        public RtVector Up { get; }

        public RtVector Left { get; }
    }
}
