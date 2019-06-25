﻿//-----------------------------------------------------------------------
// <copyright file="Transform.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class Transform
    {
        public RtMatrix Matrix { get; private set; } = new RtMatrix(4, 4).Identity();

        public Transform()
        {
        }

        public Transform(RtMatrix matrix)
        {
            Matrix = matrix;
        }

        public static RtPoint operator *(Transform transform, RtPoint point)
        {
            var results = transform.Matrix * point;
            return new RtPoint(results);
        }

        public static RtVector operator *(Transform transform, RtVector vector)
        {
            var results = transform.Matrix * vector;
            return new RtVector(results);
        }

        public static Transform operator *(Transform right, Transform left)
        {
            var results = right.Matrix * left.Matrix;
            return new Transform(results);
        }

        public Transform Translation(double x, double y, double z)
        {
            var translation = new RtMatrix(4, 4).Identity();
            translation[0, 3] = x;
            translation[1, 3] = y;
            translation[2, 3] = z;

            return new Transform(translation * Matrix);
        }

        public Transform Scaling(double x, double y, double z)
        {
            var scaling = new RtMatrix(4, 4).Identity();
            scaling[0, 0] = x;
            scaling[1, 1] = y;
            scaling[2, 2] = z;

            return new Transform(scaling * Matrix);
        }

        public Transform RotateX(double radians)
        {
            var rotateX = new RtMatrix(4, 4).Identity();
            rotateX[1, 1] = Math.Cos(radians);
            rotateX[1, 2] = Math.Sin(radians) * -1;
            rotateX[2, 1] = Math.Sin(radians);
            rotateX[2, 2] = Math.Cos(radians);

            return new Transform(rotateX * Matrix);
        }

        public Transform RotateY(double radians)
        {
            var rotateY = new RtMatrix(4, 4).Identity();
            rotateY[0, 0] = Math.Cos(radians);
            rotateY[0, 2] = Math.Sin(radians);
            rotateY[2, 0] = Math.Sin(radians) * -1;
            rotateY[2, 2] = Math.Cos(radians);

            return new Transform(Matrix * rotateY);
        }

        public Transform RotateZ(double radians)
        {
            var rotateZ = new RtMatrix(4, 4).Identity();
            rotateZ[0, 0] = Math.Cos(radians);
            rotateZ[0, 1] = Math.Sin(radians) * -1;
            rotateZ[1, 0] = Math.Sin(radians);
            rotateZ[1, 1] = Math.Cos(radians);

            return new Transform(Matrix * rotateZ);
        }

        public Transform Shearing(double xy, double xz, double yx, double yz, double zx, double zy)
        {
            var shearing = new RtMatrix(4, 4).Identity();
            shearing[0, 1] = xy;
            shearing[0, 2] = xz;
            shearing[1, 0] = yx;
            shearing[1, 2] = yz;
            shearing[2, 0] = zx;
            shearing[2, 1] = zy;

            return new Transform(Matrix * shearing);
        }

        public Transform Inverse()
        {
            Matrix = Matrix.Inverse();

            return this;
        }
    }
}