//-----------------------------------------------------------------------
// <copyright file="RtMatrix.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Runtime.Intrinsics.X86;
using System.Numerics;
using System.Text;
using System.Runtime.Intrinsics;
using System.Globalization;

namespace StealthTech.RayTracer.Library
{
    public struct RtMatrix : IEquatable<RtMatrix>
    {
        /// <summary>
        /// Value at row 1, column 1 of the matrix.
        /// </summary>
        public double M11;
        /// <summary>
        /// Value at row 1, column 2 of the matrix.
        /// </summary>
        public double M12;
        /// <summary>
        /// Value at row 1, column 3 of the matrix.
        /// </summary>
        public double M13;
        /// <summary>
        /// Value at row 1, column 4 of the matrix.
        /// </summary>
        public double M14;

        /// <summary>
        /// Value at row 2, column 1 of the matrix.
        /// </summary>
        public double M21;
        /// <summary>
        /// Value at row 2, column 2 of the matrix.
        /// </summary>
        public double M22;
        /// <summary>
        /// Value at row 2, column 3 of the matrix.
        /// </summary>
        public double M23;
        /// <summary>
        /// Value at row 2, column 4 of the matrix.
        /// </summary>
        public double M24;

        /// <summary>
        /// Value at row 3, column 1 of the matrix.
        /// </summary>
        public double M31;
        /// <summary>
        /// Value at row 3, column 2 of the matrix.
        /// </summary>
        public double M32;
        /// <summary>
        /// Value at row 3, column 3 of the matrix.
        /// </summary>
        public double M33;
        /// <summary>
        /// Value at row 3, column 4 of the matrix.
        /// </summary>
        public double M34;

        /// <summary>
        /// Value at row 4, column 1 of the matrix.
        /// </summary>
        public double M41;
        /// <summary>
        /// Value at row 4, column 2 of the matrix.
        /// </summary>
        public double M42;
        /// <summary>
        /// Value at row 4, column 3 of the matrix.
        /// </summary>
        public double M43;
        /// <summary>
        /// Value at row 4, column 4 of the matrix.
        /// </summary>
        public double M44;

        private static readonly RtMatrix _identity = new RtMatrix
        (
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
        );

        private static readonly bool useIntrinsics = true;
        
        public static RtMatrix Identity
        {
            get { return _identity; }
        }

        public RtMatrix(double m11, double m12, double m13, double m14,
                 double m21, double m22, double m23, double m24,
                 double m31, double m32, double m33, double m34,
                 double m41, double m42, double m43, double m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;

            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;

            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;

            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }

        public static unsafe RtMatrix Transpose(RtMatrix matrix)
        {
            RtMatrix result = new RtMatrix();

            if (Avx2.IsSupported && useIntrinsics)
            {
                var row1 = Avx.LoadVector256(&matrix.M11);
                var row2 = Avx.LoadVector256(&matrix.M21);
                var row3 = Avx.LoadVector256(&matrix.M31);
                var row4 = Avx.LoadVector256(&matrix.M41);

                var l12 = Avx.UnpackLow(row1, row2);
                var l34 = Avx.UnpackLow(row3, row4);
                var h12 = Avx.UnpackHigh(row1, row2);
                var h34 = Avx.UnpackHigh(row3, row4);

                Avx.Store(&result.M11, Avx.Blend(l12, Avx2.Permute4x64(l34, 0x4E), 0x0C));
                Avx.Store(&result.M21, Avx.Blend(h12, Avx2.Permute4x64(h34, 0x4E), 0x0C));
                Avx.Store(&result.M31, Avx.Blend(Avx2.Permute4x64(l12, 0x4E), l34, 0x0c));
                Avx.Store(&result.M41, Avx.Blend(Avx2.Permute4x64(h12, 0x4E), h34, 0x0c));

                return result;
            }

            result.M11 = matrix.M11;
            result.M12 = matrix.M21;
            result.M13 = matrix.M31;
            result.M14 = matrix.M41;
            result.M21 = matrix.M12;
            result.M22 = matrix.M22;
            result.M23 = matrix.M32;
            result.M24 = matrix.M42;
            result.M31 = matrix.M13;
            result.M32 = matrix.M23;
            result.M33 = matrix.M33;
            result.M34 = matrix.M43;
            result.M41 = matrix.M14;
            result.M42 = matrix.M24;
            result.M43 = matrix.M34;
            result.M44 = matrix.M44;

            return result;
        }


        public static unsafe RtMatrix operator *(RtMatrix value1, RtMatrix value2)
        {
            if (Avx2.IsSupported && useIntrinsics)
            {
                var row = Avx.LoadVector256(&value1.M11);
                Avx.Store(&value1.M11,
                    Avx.Add(Avx.Add(Avx.Multiply(Avx2.Permute4x64(row, 0x00), Avx.LoadVector256(&value2.M11)),
                                    Avx.Multiply(Avx2.Permute4x64(row, 0x55), Avx.LoadVector256(&value2.M21))),
                            Avx.Add(Avx.Multiply(Avx2.Permute4x64(row, 0xAA), Avx.LoadVector256(&value2.M31)),
                                    Avx.Multiply(Avx2.Permute4x64(row, 0xFF), Avx.LoadVector256(&value2.M41)))));

                // 0x00 is _MM_SHUFFLE(0,0,0,0), 0x55 is _MM_SHUFFLE(1,1,1,1), etc.
                // TODO: Replace with a method once it's added to the API.

                row = Avx.LoadVector256(&value1.M21);
                Avx.Store(&value1.M21,
                    Avx.Add(Avx.Add(Avx.Multiply(Avx2.Permute4x64(row, 0x00), Avx.LoadVector256(&value2.M11)),
                                    Avx.Multiply(Avx2.Permute4x64(row, 0x55), Avx.LoadVector256(&value2.M21))),
                            Avx.Add(Avx.Multiply(Avx2.Permute4x64(row, 0xAA), Avx.LoadVector256(&value2.M31)),
                                    Avx.Multiply(Avx2.Permute4x64(row, 0xFF), Avx.LoadVector256(&value2.M41)))));

                row = Avx.LoadVector256(&value1.M31);
                Avx.Store(&value1.M31,
                    Avx.Add(Avx.Add(Avx.Multiply(Avx2.Permute4x64(row, 0x00), Avx.LoadVector256(&value2.M11)),
                                    Avx.Multiply(Avx2.Permute4x64(row, 0x55), Avx.LoadVector256(&value2.M21))),
                            Avx.Add(Avx.Multiply(Avx2.Permute4x64(row, 0xAA), Avx.LoadVector256(&value2.M31)),
                                    Avx.Multiply(Avx2.Permute4x64(row, 0xFF), Avx.LoadVector256(&value2.M41)))));

                row = Avx.LoadVector256(&value1.M41);
                Avx.Store(&value1.M41,
                    Avx.Add(Avx.Add(Avx.Multiply(Avx2.Permute4x64(row, 0x00), Avx.LoadVector256(&value2.M11)),
                                    Avx.Multiply(Avx2.Permute4x64(row, 0x55), Avx.LoadVector256(&value2.M21))),
                            Avx.Add(Avx.Multiply(Avx2.Permute4x64(row, 0xAA), Avx.LoadVector256(&value2.M31)),
                                    Avx.Multiply(Avx2.Permute4x64(row, 0xFF), Avx.LoadVector256(&value2.M41)))));
                return value1;
            }

            RtMatrix m;

            // First row
            m.M11 = value1.M11 * value2.M11 + value1.M12 * value2.M21 + value1.M13 * value2.M31 + value1.M14 * value2.M41;
            m.M12 = value1.M11 * value2.M12 + value1.M12 * value2.M22 + value1.M13 * value2.M32 + value1.M14 * value2.M42;
            m.M13 = value1.M11 * value2.M13 + value1.M12 * value2.M23 + value1.M13 * value2.M33 + value1.M14 * value2.M43;
            m.M14 = value1.M11 * value2.M14 + value1.M12 * value2.M24 + value1.M13 * value2.M34 + value1.M14 * value2.M44;

            // Second row
            m.M21 = value1.M21 * value2.M11 + value1.M22 * value2.M21 + value1.M23 * value2.M31 + value1.M24 * value2.M41;
            m.M22 = value1.M21 * value2.M12 + value1.M22 * value2.M22 + value1.M23 * value2.M32 + value1.M24 * value2.M42;
            m.M23 = value1.M21 * value2.M13 + value1.M22 * value2.M23 + value1.M23 * value2.M33 + value1.M24 * value2.M43;
            m.M24 = value1.M21 * value2.M14 + value1.M22 * value2.M24 + value1.M23 * value2.M34 + value1.M24 * value2.M44;

            // Third row
            m.M31 = value1.M31 * value2.M11 + value1.M32 * value2.M21 + value1.M33 * value2.M31 + value1.M34 * value2.M41;
            m.M32 = value1.M31 * value2.M12 + value1.M32 * value2.M22 + value1.M33 * value2.M32 + value1.M34 * value2.M42;
            m.M33 = value1.M31 * value2.M13 + value1.M32 * value2.M23 + value1.M33 * value2.M33 + value1.M34 * value2.M43;
            m.M34 = value1.M31 * value2.M14 + value1.M32 * value2.M24 + value1.M33 * value2.M34 + value1.M34 * value2.M44;

            // Fourth row
            m.M41 = value1.M41 * value2.M11 + value1.M42 * value2.M21 + value1.M43 * value2.M31 + value1.M44 * value2.M41;
            m.M42 = value1.M41 * value2.M12 + value1.M42 * value2.M22 + value1.M43 * value2.M32 + value1.M44 * value2.M42;
            m.M43 = value1.M41 * value2.M13 + value1.M42 * value2.M23 + value1.M43 * value2.M33 + value1.M44 * value2.M43;
            m.M44 = value1.M41 * value2.M14 + value1.M42 * value2.M24 + value1.M43 * value2.M34 + value1.M44 * value2.M44;

            return m;
        }

        public static unsafe RtVector operator *(RtMatrix left, RtVector right)
        {
            if (Avx.IsSupported && useIntrinsics)
            {
                var results = new RtMatrix();

                Avx.Store(&results.M11, Avx.Multiply(Avx.LoadVector256(&left.M11), Avx.LoadVector256(&right.X)));
                Avx.Store(&results.M21, Avx.Multiply(Avx.LoadVector256(&left.M21), Avx.LoadVector256(&right.X)));
                Avx.Store(&results.M31, Avx.Multiply(Avx.LoadVector256(&left.M31), Avx.LoadVector256(&right.X)));

                return new RtVector(
                    results.M11 + results.M12 + results.M13,
                    results.M21 + results.M22 + results.M23,
                    results.M31 + results.M32 + results.M33);
            }
            else
            {

                var c1 = (left.M11 * right.X) + (left.M12 * right.Y) + (left.M13 * right.Z) + (left.M14 * right.W);
                var c2 = (left.M21 * right.X) + (left.M22 * right.Y) + (left.M23 * right.Z) + (left.M24 * right.W);
                var c3 = (left.M31 * right.X) + (left.M32 * right.Y) + (left.M33 * right.Z) + (left.M34 * right.W);

                return new RtVector(c1, c2, c3);
            }
        }

        public static unsafe RtPoint operator *(RtMatrix left, RtPoint right)
        {
            if (Avx.IsSupported && useIntrinsics)
            {
                var results = new RtMatrix();

                Avx.Store(&results.M11, Avx.Multiply(Avx.LoadVector256(&left.M11), Avx.LoadVector256(&right.X)));
                Avx.Store(&results.M21, Avx.Multiply(Avx.LoadVector256(&left.M21), Avx.LoadVector256(&right.X)));
                Avx.Store(&results.M31, Avx.Multiply(Avx.LoadVector256(&left.M31), Avx.LoadVector256(&right.X)));

                return new RtPoint(
                    results.M11 + results.M12 + results.M13 + results.M14,
                    results.M21 + results.M22 + results.M23 + results.M24,
                    results.M31 + results.M32 + results.M33 + results.M34);
            }
            else
            {

                var c1 = (left.M11 * right.X) + (left.M12 * right.Y) + (left.M13 * right.Z) + (left.M14 * right.W);
                var c2 = (left.M21 * right.X) + (left.M22 * right.Y) + (left.M23 * right.Z) + (left.M24 * right.W);
                var c3 = (left.M31 * right.X) + (left.M32 * right.Y) + (left.M33 * right.Z) + (left.M34 * right.W);

                return new RtPoint(c1, c2, c3);
            }
        }

        //public static RtPoint operator *(RtMatrix left, RtPoint right)
        //{
        //    var c1 = (left[0, 0] * right.X) + (left[0, 1] * right.Y) + (left[0, 2] * right.Z) + (left[0, 3] * right.W);
        //    var c2 = (left[1, 0] * right.X) + (left[1, 1] * right.Y) + (left[1, 2] * right.Z) + (left[1, 3] * right.W);
        //    var c3 = (left[2, 0] * right.X) + (left[2, 1] * right.Y) + (left[2, 2] * right.Z) + (left[2, 3] * right.W);

        //    return new RtPoint(c1, c2, c3);
        //}

        public RtPoint MultipliedByPointOrigin()

        {
            return this * new RtPoint(0, 0, 0);
        }

        public double Determinant()
        {
            double a = M11, b = M12, c = M13, d = M14;
            double e = M21, f = M22, g = M23, h = M24;
            double i = M31, j = M32, k = M33, l = M34;
            double m = M41, n = M42, o = M43, p = M44;

            double kp_lo = k * p - l * o;
            double jp_ln = j * p - l * n;
            double jo_kn = j * o - k * n;
            double ip_lm = i * p - l * m;
            double io_km = i * o - k * m;
            double in_jm = i * n - j * m;

            double a11 = +(f * kp_lo - g * jp_ln + h * jo_kn);
            double a12 = -(e * kp_lo - g * ip_lm + h * io_km);
            double a13 = +(e * jp_ln - f * ip_lm + h * in_jm);
            double a14 = -(e * jo_kn - f * io_km + g * in_jm);

            return a * a11 + b * a12 + c * a13 + d * a14;
        }

        public bool IsInvertible()
        {
            if (Math.Abs(Determinant()) < double.Epsilon)
            {
                return false;
            }

            return true;
        }

        public RtMatrix Inverse()
        {
            RtMatrix result;

            double a = M11, b = M12, c = M13, d = M14;
            double e = M21, f = M22, g = M23, h = M24;
            double i = M31, j = M32, k = M33, l = M34;
            double m = M41, n = M42, o = M43, p = M44;

            double kp_lo = k * p - l * o;
            double jp_ln = j * p - l * n;
            double jo_kn = j * o - k * n;
            double ip_lm = i * p - l * m;
            double io_km = i * o - k * m;
            double in_jm = i * n - j * m;

            double a11 = +(f * kp_lo - g * jp_ln + h * jo_kn);
            double a12 = -(e * kp_lo - g * ip_lm + h * io_km);
            double a13 = +(e * jp_ln - f * ip_lm + h * in_jm);
            double a14 = -(e * jo_kn - f * io_km + g * in_jm);

            double det = a * a11 + b * a12 + c * a13 + d * a14;

            if (Math.Abs(det) < double.Epsilon)
            {
                result = new RtMatrix(double.NaN, double.NaN, double.NaN, double.NaN,
                                       double.NaN, double.NaN, double.NaN, double.NaN,
                                       double.NaN, double.NaN, double.NaN, double.NaN,
                                       double.NaN, double.NaN, double.NaN, double.NaN);
                return result;
            }

            double invDet = 1.0f / det;

            result.M11 = a11 * invDet;
            result.M21 = a12 * invDet;
            result.M31 = a13 * invDet;
            result.M41 = a14 * invDet;

            result.M12 = -(b * kp_lo - c * jp_ln + d * jo_kn) * invDet;
            result.M22 = +(a * kp_lo - c * ip_lm + d * io_km) * invDet;
            result.M32 = -(a * jp_ln - b * ip_lm + d * in_jm) * invDet;
            result.M42 = +(a * jo_kn - b * io_km + c * in_jm) * invDet;

            double gp_ho = g * p - h * o;
            double fp_hn = f * p - h * n;
            double fo_gn = f * o - g * n;
            double ep_hm = e * p - h * m;
            double eo_gm = e * o - g * m;
            double en_fm = e * n - f * m;

            result.M13 = +(b * gp_ho - c * fp_hn + d * fo_gn) * invDet;
            result.M23 = -(a * gp_ho - c * ep_hm + d * eo_gm) * invDet;
            result.M33 = +(a * fp_hn - b * ep_hm + d * en_fm) * invDet;
            result.M43 = -(a * fo_gn - b * eo_gm + c * en_fm) * invDet;

            double gl_hk = g * l - h * k;
            double fl_hj = f * l - h * j;
            double fk_gj = f * k - g * j;
            double el_hi = e * l - h * i;
            double ek_gi = e * k - g * i;
            double ej_fi = e * j - f * i;

            result.M14 = -(b * gl_hk - c * fl_hj + d * fk_gj) * invDet;
            result.M24 = +(a * gl_hk - c * el_hi + d * ek_gi) * invDet;
            result.M34 = -(a * fl_hj - b * el_hi + d * ej_fi) * invDet;
            result.M44 = +(a * fk_gj - b * ek_gi + c * ej_fi) * invDet;

            return result;
        }

        //public override string ToString()
        //{
        //    var buffer = new StringBuilder();
        //    for (int j = 0; j < 4; j++)
        //    {
        //        for (int i = 0; i < 4; i++)
        //        {
        //            buffer.Append(ToPadding(_matrix[j, i]));
        //        }
        //        buffer.AppendLine();
        //    }
        //    buffer.AppendLine();
        //    return buffer.ToString();
        //}

        //private string ToPadding(double number)
        //{
        //    var buffer = number.ToString("###.0000");
        //    buffer = buffer.PadLeft(10, ' ');
        //    return buffer;
        //}

        private static bool Equal(Vector256<double> vector1, Vector256<double> vector2)
        {
            return Avx.MoveMask(Avx.Compare(vector1, vector2, FloatComparisonMode.OrderedNotEqualNonSignaling)) == 0;
        }

        private static bool NotEqual(Vector256<double> vector1, Vector256<double> vector2)
        {
            return Avx.MoveMask(Avx.Compare(vector1, vector2, FloatComparisonMode.OrderedNotEqualNonSignaling)) != 0;
        }


        /// <summary>
        /// Returns a boolean indicating whether the given two matrices are equal.
        /// </summary>
        /// <param name="value1">The first matrix to compare.</param>
        /// <param name="value2">The second matrix to compare.</param>
        /// <returns>True if the given matrices are equal; False otherwise.</returns>
        public static unsafe bool operator ==(RtMatrix value1, RtMatrix value2)
        {
            if (Avx.IsSupported && useIntrinsics)
            {
                return
                    Equal(Avx.LoadVector256(&value1.M11), Avx.LoadVector256(&value2.M11)) &&
                    Equal(Avx.LoadVector256(&value1.M21), Avx.LoadVector256(&value2.M21)) &&
                    Equal(Avx.LoadVector256(&value1.M31), Avx.LoadVector256(&value2.M31)) &&
                    Equal(Avx.LoadVector256(&value1.M41), Avx.LoadVector256(&value2.M41));
            }

            return (value1.M11 == value2.M11 && value1.M22 == value2.M22 && value1.M33 == value2.M33 && value1.M44 == value2.M44 && // Check diagonal element first for early out.
                    value1.M12 == value2.M12 && value1.M13 == value2.M13 && value1.M14 == value2.M14 && value1.M21 == value2.M21 &&
                    value1.M23 == value2.M23 && value1.M24 == value2.M24 && value1.M31 == value2.M31 && value1.M32 == value2.M32 &&
                    value1.M34 == value2.M34 && value1.M41 == value2.M41 && value1.M42 == value2.M42 && value1.M43 == value2.M43);
        }

        /// <summary>
        /// Returns a boolean indicating whether the given two matrices are not equal.
        /// </summary>
        /// <param name="value1">The first matrix to compare.</param>
        /// <param name="value2">The second matrix to compare.</param>
        /// <returns>True if the given matrices are not equal; False if they are equal.</returns>
        public static unsafe bool operator !=(RtMatrix value1, RtMatrix value2)
        {
            if (Avx.IsSupported && useIntrinsics)
            {
                return
                    NotEqual(Avx.LoadVector256(&value1.M11), Avx.LoadVector256(&value2.M11)) ||
                    NotEqual(Avx.LoadVector256(&value1.M21), Avx.LoadVector256(&value2.M21)) ||
                    NotEqual(Avx.LoadVector256(&value1.M31), Avx.LoadVector256(&value2.M31)) ||
                    NotEqual(Avx.LoadVector256(&value1.M41), Avx.LoadVector256(&value2.M41));
            }

            return (value1.M11 != value2.M11 || value1.M12 != value2.M12 || value1.M13 != value2.M13 || value1.M14 != value2.M14 ||
                    value1.M21 != value2.M21 || value1.M22 != value2.M22 || value1.M23 != value2.M23 || value1.M24 != value2.M24 ||
                    value1.M31 != value2.M31 || value1.M32 != value2.M32 || value1.M33 != value2.M33 || value1.M34 != value2.M34 ||
                    value1.M41 != value2.M41 || value1.M42 != value2.M42 || value1.M43 != value2.M43 || value1.M44 != value2.M44);
        }

        /// <summary>
        /// Returns a boolean indicating whether this matrix instance is equal to the other given matrix.
        /// </summary>
        /// <param name="other">The matrix to compare this instance to.</param>
        /// <returns>True if the matrices are equal; False otherwise.</returns>
        public readonly bool Equals(RtMatrix other) => this == other;

        /// <summary>
        /// Returns a boolean indicating whether the given Object is equal to this matrix instance.
        /// </summary>
        /// <param name="obj">The Object to compare against.</param>
        /// <returns>True if the Object is equal to this matrix; False otherwise.</returns>
        public override readonly bool Equals(object? obj) => (obj is RtMatrix other) && (this == other);

        public bool ApproximateEqual(RtMatrix other)
        {
            return M11.ApproximateEquals(other.M11) && M12.ApproximateEquals(other.M12) && M13.ApproximateEquals(other.M13) && M14.ApproximateEquals(other.M14) &&
                M21.ApproximateEquals(other.M21) && M22.ApproximateEquals(other.M22) && M23.ApproximateEquals(other.M23) && M24.ApproximateEquals(other.M24) &&
                M31.ApproximateEquals(other.M31) && M32.ApproximateEquals(other.M32) && M33.ApproximateEquals(other.M33) && M34.ApproximateEquals(other.M34) &&
                M41.ApproximateEquals(other.M41) && M42.ApproximateEquals(other.M42) && M43.ApproximateEquals(other.M43) && M44.ApproximateEquals(other.M44);
        }

        /// <summary>
        /// Returns a String representing this matrix instance.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override readonly string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{ {{M11:{0} M12:{1} M13:{2} M14:{3}}} {{M21:{4} M22:{5} M23:{6} M24:{7}}} {{M31:{8} M32:{9} M33:{10} M34:{11}}} {{M41:{12} M42:{13} M43:{14} M44:{15}}} }}",
                                 M11, M12, M13, M14,
                                 M21, M22, M23, M24,
                                 M31, M32, M33, M34,
                                 M41, M42, M43, M44);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override readonly int GetHashCode()
        {
            unchecked
            {
                return M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() + M14.GetHashCode() +
                       M21.GetHashCode() + M22.GetHashCode() + M23.GetHashCode() + M24.GetHashCode() +
                       M31.GetHashCode() + M32.GetHashCode() + M33.GetHashCode() + M34.GetHashCode() +
                       M41.GetHashCode() + M42.GetHashCode() + M43.GetHashCode() + M44.GetHashCode();
            }
        }
    }
}

