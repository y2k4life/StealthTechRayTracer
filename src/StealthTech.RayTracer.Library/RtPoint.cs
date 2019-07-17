//-----------------------------------------------------------------------
// <copyright file="RtPoint.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public struct RtPoint : IEquatable<RtPoint>
    {
        public double X;

        public double Y;

        public double Z;

        public double W;

        public RtPoint(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1;
        }

        public double Magnitude() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));

        public double Dot(RtBaseTuple other)
        {
            return
                X * other.X +
                Y * other.Y +
                Z * other.Z +
                W * other.W;
        }

        public RtPoint Normalized() => this / Magnitude();

        public RtPoint Cross(RtPoint other)
            => new RtPoint(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);

        public RtVector DistanceFromZero()
        {
            return new RtVector(X - 0, Y - 0, Z - 0);
        }

        static public RtPoint operator +(RtPoint left, RtVector right)
            => new RtPoint(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        static public RtVector operator -(RtPoint left, RtPoint right)
            => new RtVector(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        static public RtPoint operator -(RtPoint left, RtVector right)
            => new RtPoint(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        static public RtPoint operator +(RtPoint tuple, double factor)
            => new RtPoint(tuple.X + factor, tuple.Y + factor, tuple.Z + factor);

        static public RtPoint operator *(RtPoint tuple, double factor)
            => new RtPoint(tuple.X * factor, tuple.Y * factor, tuple.Z * factor);


        static public RtPoint operator /(RtPoint tuple, double divisor)
            => new RtPoint(tuple.X / divisor, tuple.Y / divisor, tuple.Z / divisor);

        static public bool operator ==(RtPoint left, RtPoint right)
        {
            return left.Equals(right);
        }

        static public bool operator !=(RtPoint left, RtPoint right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            RtPoint other = (RtPoint)obj;
            return Equals(other);
        }

        public bool Equals(RtPoint other)
        {
            return (other.X.ApproximateEquals(X)
                && other.Y.ApproximateEquals(Y)
                && other.Z.ApproximateEquals(Z)
                && other.W.ApproximateEquals(W));
        }

        public override string ToString()
        {
            return $"({X.ToString("#####0.000")}, {Y.ToString("#####0.000")}, {Z.ToString("#####0.000")}, {W})";
        }
    }
}
