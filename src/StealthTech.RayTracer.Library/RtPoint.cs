//-----------------------------------------------------------------------
// <copyright file="RtPoint.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public class RtPoint : RtBaseTuple
    {
        public RtPoint(RtBaseTuple tuple)
            : base(tuple.X, tuple.Y, tuple.Z, 1)
        {
        }

        public RtPoint(double x, double y, double z)
            : base(x, y, z, 1)
        {
        }

        public RtPoint Normalized() => this / Magnitude();

        public RtPoint Cross(RtPoint other)
            => new RtPoint(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);

        static public RtPoint operator +(RtPoint left, RtVector right)
            => new RtPoint(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        static public RtVector operator -(RtPoint left, RtPoint right)
            => new RtVector(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        static public RtPoint operator -(RtPoint left, RtVector right)
            => new RtPoint(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        static public RtPoint operator /(RtPoint tuple, double divisor)
            => new RtPoint(tuple.X / divisor, tuple.Y / divisor, tuple.Z / divisor);

        static public bool operator ==(RtPoint left, RtPoint right)
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
            if (obj is null)
            {
                return false;
            }

            RtPoint other = obj as RtPoint;
            return Equals(other);
        }

        public bool Equals(RtPoint other)
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
