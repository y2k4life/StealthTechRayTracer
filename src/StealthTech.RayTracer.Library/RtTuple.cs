//-----------------------------------------------------------------------
// <copyright file="RtTuple.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class RtTuple : RtBaseTuple, IEquatable<RtTuple>
    {
        public RtTuple(double x, double y, double z, double w)
           : base (x, y, z, w)
        {
        }

        public RtTuple Negate()
            => new RtTuple(-X, -Y, -Z, -W);

        public RtTuple Normalized() => this / Magnitude();

        public RtTuple Cross(RtTuple other)
            => new RtTuple(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X, 0);

        static public RtTuple operator +(RtTuple left, RtTuple right)
            => new RtTuple(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

        static public RtTuple operator -(RtTuple left, RtTuple right)
            => new RtTuple(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

        static public RtTuple operator *(RtTuple tuple, double multiplier)
            => new RtTuple(tuple.X * multiplier, tuple.Y * multiplier, tuple.Z * multiplier, tuple.W * multiplier);

        static public RtTuple operator *(double multiplier, RtTuple tuple)
            => tuple * multiplier;

        static public RtTuple operator /(RtTuple tuple, double divisor)
            => new RtTuple(tuple.X / divisor, tuple.Y / divisor, tuple.Z / divisor, tuple.W / divisor);

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

            RtTuple other = obj as RtTuple;
            return Equals(other);
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

        public bool Equals(RtVector other)
        {
            return (other.X.ApproximateEquals(X)
                && other.Y.ApproximateEquals(Y)
                && other.Z.ApproximateEquals(Z)
                && other.W.ApproximateEquals(W));
        }

        public bool Equals(RtPoint other)
        {
            return (other.X.ApproximateEquals(X)
                && other.Y.ApproximateEquals(Y)
                && other.Z.ApproximateEquals(Z)
                && other.W.ApproximateEquals(W));
        }
        
    }
}