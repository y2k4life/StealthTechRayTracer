//-----------------------------------------------------------------------
// <copyright file="RtBaseTuple.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class RtBaseTuple
    {
        public RtBaseTuple(double x, double y, double z, double w)
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

        public double Magnitude() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2));

        public double Dot(RtBaseTuple other)
        {
            return
                X * other.X +
                Y * other.Y +
                Z * other.Z +
                W * other.W;
        }

        public override string ToString()
        {
            return $"({X.ToString("#####0.000")}, {Y.ToString("#####0.000")}, {Z.ToString("#####0.000")}, {W})";
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

            RtBaseTuple other = obj as RtBaseTuple;
            return (other.X.ApproximateEquals(X)
                && other.Y.ApproximateEquals(Y)
                && other.Z.ApproximateEquals(Z)
                && other.W.ApproximateEquals(W));
        }
    }
}
