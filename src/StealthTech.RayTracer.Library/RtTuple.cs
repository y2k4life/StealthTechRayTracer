//-----------------------------------------------------------------------
// <copyright file="RtTuple.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    using System;

    public class RtTuple : IEquatable<RtTuple>
    {
        public static readonly RtTuple ZeroVector = new RtTuple(0, 0, 0, 0);

        public static RtTuple Point(double x, double y, double z)
        {
            return new RtTuple(x, y, z, 1);
        }

        public static RtTuple Vector(double x, double y, double z)
        {
            return new RtTuple(x, y, z, 0);
        }

        public RtTuple(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double W { get; set; }

        public bool IsPoint { get => W == 1; }

        public bool IsVector { get => W == 0; }

        static public RtTuple operator +(RtTuple left, RtTuple right)
        {
            return new RtTuple(
                left.X + right.X,
                left.Y + right.Y,
                left.Z + right.Z,
                left.W + right.W
            );
        }

        static public RtTuple operator -(RtTuple left, RtTuple right)
        {
            return new RtTuple(
                left.X - right.X,
                left.Y - right.Y,
                left.Z - right.Z,
                left.W - right.W
            );
        }

        public RtTuple Negate()
        {
            return new RtTuple(
                -X,
                -Y,
                -Z,
                -W
            );
        }

        static public RtTuple operator *(RtTuple tuple, double multiplier)
        {
            return new RtTuple(
                tuple.X * multiplier,
                tuple.Y * multiplier,
                tuple.Z * multiplier,
                tuple.W * multiplier
            );
        }
        static public RtTuple operator *(double multiplier, RtTuple tuple)
        {
            return tuple * multiplier;
        }

        static public RtTuple operator /(RtTuple tuple, double divisor)
        {
            return new RtTuple(
                tuple.X / divisor,
                tuple.Y / divisor,
                tuple.Z / divisor,
                tuple.W / divisor
            );
        }

        static public bool operator ==(RtTuple left, RtTuple right)
        {
            if (left is null)
            {
                if (right is null)
                {
                    return true;
                }

                return false;
            }

            return left.Equals(right);
        }

        static public bool operator !=(RtTuple left, RtTuple right)
        {
            return !(left == right);
        }

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));
            }
        }

        public RtTuple Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }

        public double Dot(RtTuple other)
        {
            return
                X * other.X +
                Y * other.Y +
                Z * other.Z +
                W * other.W;
        }

        public RtTuple Cross(RtTuple v)
        {
            return new RtTuple(
                Y * v.Z - Z * v.Y,
                Z * v.X - X * v.Z,
                X * v.Y - Y * v.X,
                0
            );
        }

        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}],({W})";
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            RtTuple other = obj as RtTuple;
            return (other.X.ApproximateEquals(X)
                && other.Y.ApproximateEquals(Y)
                && other.Z.ApproximateEquals(Z)
                && other.W.ApproximateEquals(W));
        }

        public bool Equals(RtTuple other)
        {
            if (other is null)
            {
                return false;
            }

            return (other.X.ApproximateEquals(X)
                && other.Y.ApproximateEquals(Y)
                && other.Z.ApproximateEquals(Z)
                && other.W.ApproximateEquals(W));
        }
    }
}