//-----------------------------------------------------------------------
// <copyright file="RtVector.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public class RtVector : RtBaseTuple
    {
        public static readonly RtVector ZeroVector = new RtVector(0, 0, 0);

        public RtVector(double x, double y, double z)
            : base(x, y, z, 0)
        {
        }

        public RtVector(RtBaseTuple tuple)
            : base(tuple.X, tuple.Y, tuple.Z, 0)
        {
        }

        public RtVector Normalized() => this / Magnitude();

        public RtVector Cross(RtVector other)
            => new RtVector(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);

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

            RtVector other = obj as RtVector;
            return Equals(other);
        }

        public bool Equals(RtVector other)
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
