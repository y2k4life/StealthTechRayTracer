//-----------------------------------------------------------------------
// <copyright file="RtMatrix.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace StealthTech.RayTracer.Library
{
    public class RtMatrix : IEquatable<RtMatrix>
    {
        private readonly double[,] _matrix;

        public int RowCount { get; }

        public int ColumnCount { get; }

        public RtMatrix(int rows, int columns)
        {
            RowCount = rows;
            ColumnCount = columns;

            _matrix = new double[rows, columns];
        }

        public double[] GetRow(int rowIndex)
        {
            var row = new double[ColumnCount];
            for (int c = 0; c < ColumnCount; c++)
            {
                row[c] = _matrix[rowIndex, c];
            }

            return row;
        }

        public double[] GetColumn(int columnIndex)
        {
            var column = new double[RowCount];
            for (int r = 0; r < RowCount; r++)
            {
                column[r] = _matrix[r, columnIndex];
            }

            return column;
        }

        public double this[int row, int column]
        {
            get
            {
                return _matrix[row, column];
            }
            set
            {
                _matrix[row, column] = value;
            }
        }

        public static RtMatrix operator *(RtMatrix left, RtMatrix right)
        {
            int leftRowCount = left.RowCount;
            int rightColumnCount = right.ColumnCount;

            var results = new RtMatrix(leftRowCount, rightColumnCount);
            var columns = new double[right.ColumnCount][];

            for (int r = 0; r < leftRowCount; r++)
            {
                var row = left.GetRow(r);
                for (int c = 0; c < rightColumnCount; c++)
                {
                    if (columns[c] == null)
                    {
                        columns[c] = right.GetColumn(c);
                    }

                    double accumulator = 0;
                    for (int i = 0; i < leftRowCount; i++)
                    {
                        accumulator += row[i] * columns[c][i];
                    }

                    results[r, c] = accumulator;
                }
            }

            return results;
        }

        public static RtTuple operator *(RtMatrix left, RtTuple right)
        {
            var results = new double[4];

            double[] column = { right.X, right.Y, right.Z, right.W };

            for (int r = 0; r < left.RowCount; r++)
            {
                var row = left.GetRow(r);
                double accumulator = 0;
                for (int c = 0; c < 4; c++)
                {
                    accumulator += row[c] * column[c];
                }

                results[r] = accumulator;
            }

            return new RtTuple(results[0], results[1], results[2], results[3]);
        }

        public static RtTuple operator *(RtTuple left, RtMatrix right)
        {
            return right * left;
        }

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

            if (_matrix.GetLength(0) != other._matrix.GetLength(0) || _matrix.GetLength(1) != other._matrix.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] != other[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
