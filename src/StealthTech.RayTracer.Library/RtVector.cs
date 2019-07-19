//-----------------------------------------------------------------------
// <copyright file="RtVector.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public struct RtVector : IEquatable<RtVector>
    {
        public double X;

        public double Y;

        public double Z;

        public double W;
        
        public static readonly RtVector ZeroVector = new RtVector(0, 0, 0);

        public RtVector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 0;
        }

        public double Magnitude() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));

        public double Dot(RtVector other)
        {
            return
                X * other.X +
                Y * other.Y +
                Z * other.Z +
                W * other.W;
        }

        public RtVector Reflect(RtVector normal)
        {
            return this - normal * 2 * Dot(normal);
        }

        public RtVector Normalize() => this / Magnitude();

        public RtVector Cross(RtVector other)
            => new RtVector(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);

        public RtVector Negate()
            => new RtVector(-X, -Y, -Z);

        static public RtVector operator +(RtVector left, RtVector right)
            => new RtVector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        static public RtVector operator -(RtVector left, RtVector right)
            => new RtVector(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        static public RtVector operator *(RtVector tuple, double multiplier)
            => new RtVector(tuple.X * multiplier, tuple.Y * multiplier, tuple.Z * multiplier);

        static public RtVector operator /(RtVector tuple, double divisor)
            => new RtVector(tuple.X / divisor, tuple.Y / divisor, tuple.Z / divisor);

        static public bool operator ==(RtVector left, RtVector right)
        {
            return left.Equals(right);
        }

        static public bool operator !=(RtVector left, RtVector right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            RtVector other = (RtVector)obj;
            return Equals(other);
        }

        public bool Equals(RtVector other)
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
