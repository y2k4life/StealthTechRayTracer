//-----------------------------------------------------------------------
// <copyright file="Transform.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class Transform : IEquatable<Transform>
    {
        public RtMatrix Matrix { get; protected set; } = RtMatrix.Identity;

        public Transform()
        {
        }

        public Transform(RtMatrix matrix)
        {
            Matrix = matrix;
        }

        public static RtPoint operator *(Transform transform, RtPoint point)
        {
            return transform.Matrix * point;
        }

        public static RtVector operator *(Transform transform, RtVector vector)
        {
            return transform.Matrix * vector;
        }

        public static Transform operator *(Transform right, Transform left)
        {
            var results = right.Matrix * left.Matrix;
            return new Transform(results);
        }

        public Transform Translation(RtPoint location)
        {
            return Translation(location.X, location.Y, location.Z);
        }

        public Transform Translation(double x, double y, double z)
        {
            var translation = RtMatrix.Identity;
            translation.M14 = x;
            translation.M24 = y;
            translation.M34 = z;

            return new Transform(translation * Matrix);
        }

        public Transform Scaling(double x, double y, double z)
        {
            var scaling = RtMatrix.Identity;
            scaling.M11 = x;
            scaling.M22 = y;
            scaling.M33 = z;

            return new Transform(scaling * Matrix);
        }

        public Transform RotateX(double radians)
        {
            var rotateX = RtMatrix.Identity;
            rotateX.M22 = Math.Cos(radians);
            rotateX.M23 = Math.Sin(radians) * -1;
            rotateX.M32 = Math.Sin(radians);
            rotateX.M33 = Math.Cos(radians);

            return new Transform(rotateX * Matrix);
        }

        public Transform RotateY(double radians)
        {
            var rotateY = RtMatrix.Identity;
            rotateY.M11 = Math.Cos(radians);
            rotateY.M13 = Math.Sin(radians);
            rotateY.M31 = Math.Sin(radians) * -1;
            rotateY.M33 = Math.Cos(radians);

            return new Transform(rotateY * Matrix);
        }

        public Transform RotateZ(double radians)
        {
            var rotateZ = RtMatrix.Identity;
            rotateZ.M11 = Math.Cos(radians);
            rotateZ.M12 = Math.Sin(radians) * -1;
            rotateZ.M21 = Math.Sin(radians);
            rotateZ.M22 = Math.Cos(radians);

            return new Transform(Matrix * rotateZ);
        }

        public Transform Shearing(double xy, double xz, double yx, double yz, double zx, double zy)
        {
            var shearing = RtMatrix.Identity;
            shearing.M12 = xy;
            shearing.M13 = xz;
            shearing.M21 = yx;
            shearing.M23 = yz;
            shearing.M31 = zx;
            shearing.M32 = zy;

            return new Transform(Matrix * shearing);
        }

        public Transform Inverse()
        {
            Matrix = Matrix.Inverse();

            return this;
        }

        public override int GetHashCode()
        {
            return Matrix.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            Transform other = obj as Transform;
            return Equals(other);
        }

        public bool Equals(Transform other)
        {
            if (other is null)
            {
                return false;
            }

            return Matrix.Equals(other.Matrix);
        }

        public override string ToString()
        {
            return Matrix.ToString();
        }
    }
}
