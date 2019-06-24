//-----------------------------------------------------------------------
// <copyright file="RtMatrix.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace StealthTech.RayTracer.Library
{
    public class RtMatrix : IEquatable<RtMatrix>
    {
        private readonly double[,] _matrix;

        private RtMatrix _invertatedMatrix;

        public int RowCount { get; }

        public int ColumnCount { get; }

        public RtMatrix(int rows, int columns)
        {
            RowCount = rows;
            ColumnCount = columns;

            _matrix = new double[rows, columns];
        }

        public double this[int row, int column]
        {
            get
            {
                return _matrix[row, column];
            }
            set
            {
                if (_matrix[row, column] != value)
                {
                    _matrix[row, column] = value;
                    _invertatedMatrix = null;
                }
            }
        }

        public static RtMatrix operator *(RtMatrix left, RtMatrix right)
        {
            int leftRowCount = left.RowCount;
            int leftColumnCount = left.ColumnCount;

            int rightColumnCount = right.ColumnCount;

            var results = new RtMatrix(leftRowCount, rightColumnCount);

            double accumulator = 0;

            for (int li = 0; li < leftRowCount; li++)
            {
                for (int rj = 0; rj < rightColumnCount; rj++)
                {
                    for (int i1 = 0; i1 < leftColumnCount; i1++)
                    {
                        accumulator += left[li, i1] * right[i1, rj];
                    }

                    results[li, rj] = accumulator;
                    accumulator = 0;
                }
            }

            return results;
        }

        public static RtTuple operator *(RtMatrix left, RtBaseTuple right)
        {
            var results = new double[4];

            double[] column = { right.X, right.Y, right.Z, right.W };

            for (int r = 0; r < left.RowCount; r++)
            {
                double accumulator = 0;
                for (int c = 0; c < 4; c++)
                {
                    accumulator += left[r, c] * column[c];
                }

                results[r] = accumulator;
            }

            return new RtTuple(results[0], results[1], results[2], results[3]);
        }

        //public static RtTuple operator *(RtTuple left, RtMatrix right)
        //{
        //    return right * left;
        //}

        public override int GetHashCode()
        {
            return _matrix.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return Equals(obj as RtMatrix);
        }

        public bool Equals(RtMatrix other)
        {
            if (other is null)
            {
                return false;
            }

            if (RowCount != other.RowCount || ColumnCount != other.ColumnCount)
            {
                return false;
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (!_matrix[i, j].ApproximateEquals(other[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public RtMatrix Identity()
        {
            if (RowCount != ColumnCount)
                throw new Exception("Not a square matrix");

            var results = new RtMatrix(RowCount, ColumnCount);

            for (int i = 0; i < RowCount; i++)
            {
                results[i, i] = 1;
            }

            return results;
        }

        public RtMatrix Transpose()
        {
            var results = new RtMatrix(ColumnCount, RowCount);

            for(int i=0; i < RowCount; i++)
            {
                for(int j = 0; j < ColumnCount; j++)
                {
                    results[j, i] = _matrix[i, j];
                }
            }

            return results;
        }

        public double Determinant()
        {
            if (ColumnCount != RowCount)
                throw new Exception("Not a square");

            if (ColumnCount == 2)
                return _matrix[0, 0] * _matrix[1, 1] - _matrix[0, 1] * _matrix[1, 0];

            double results = 0;
            for (int j=0; j < ColumnCount; j++)
            {
                results += _matrix[0, j] * Cofactor(0, j);
            }

            return results;
        }

        public RtMatrix Remove(int row, int column)
        {
            var results = new RtMatrix(RowCount - 1, ColumnCount - 1);

            int i2 = 0;
            for (int i = 0; i < RowCount; i++)
            {
                if(i == row)
                    continue;

                int j2 = 0;
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (j == column)
                        continue;

                    results[i2, j2] = _matrix[i, j];
                    j2++;
                }

                i2++;
            }

            return results;
        }

        public double Minor(int row, int column)
        {
            var submatrix = Remove(row, column);
            return submatrix.Determinant();
        }

        public double Cofactor(int row, int column)
        {
            var minor = Minor(row, column);
            return (row + column) % 2 == 1 ? minor * -1 : minor;
        }

        public bool IsInvertible()
        {
            return Determinant() != 0;
        }

        public RtMatrix Inverse()
        {
            if (_invertatedMatrix != null)
            {
                return _invertatedMatrix;
            }

            if (!IsInvertible())
            {
                throw new Exception("Not invertible");
            }

            _invertatedMatrix = new RtMatrix(RowCount, ColumnCount);
            var determinante = Determinant();
            if (RowCount == 2 && ColumnCount == 2)
            {
                determinante = 1 / determinante;
                _invertatedMatrix[0, 0] = _matrix[1, 1] * determinante;
                _invertatedMatrix[0, 1] = (Math.Abs(_matrix[0, 1]) * -1) * determinante;
                _invertatedMatrix[1, 0] = (Math.Abs(_matrix[1, 0]) * -1) * determinante;
                _invertatedMatrix[1, 1] = _matrix[0, 0] * determinante;
                return _invertatedMatrix;
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    var cofactor = Cofactor(i, j);
                    _invertatedMatrix[j, i] = cofactor / determinante;
                }
            }

            return _invertatedMatrix;
        }
    }
}
