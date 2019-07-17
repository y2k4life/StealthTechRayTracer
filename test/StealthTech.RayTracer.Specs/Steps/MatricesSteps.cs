////-----------------------------------------------------------------------
//// <copyright file="MatricesSteps.cs" company="StealthTech">
////     Author: Guy Boicey
////     Copyright (c) 2019 Guy Boicey
//// </copyright>
////-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class MatricesSteps
    {
        readonly TupleContext _tupleContext;

        readonly MatrixContext _matrixContext;

        public MatricesSteps(TupleContext tupleContext, MatrixContext matrixContext)
        {
            _matrixContext = matrixContext;
            _tupleContext = tupleContext;
        }

        //        [Given(@"B ← inverse\(A\)")]
        //        public void Given_B_Is_Inverse_Of_A()
        //        {
        //            _matrixContext.MatrixB = _matrixContext.MatrixA.Inverse();
        //        }

        //        [Given(@"C ← A \* B")]
        //        public void Given_C_Is_A_Multiplied_By_B()
        //        {
        //            _matrixContext.MatrixC = _matrixContext.MatrixA * _matrixContext.MatrixB;
        //        }

        //        [Given(@"B ← submatrix\(A, (.*), (.*)\)")]
        //        public void Given_B_Is_Submatrix_Of_A(int row, int column)
        //        {
        //            _matrixContext.MatrixB = _matrixContext.MatrixA.Remove(row, column);
        //        }

        [Given(@"the following matrix A:")]
        public void Given_The_Following_Matrix_For_A(Table table)
        {
            _matrixContext.MatrixA = table.ToMatrix();
        }

        [Given(@"the following matrix B:")]
        public void Given_The_Following_Matrix_For_B(Table table)
        {
            _matrixContext.MatrixB = table.ToMatrix();
        }

        //        [Given(@"the following (.*)x(.*) matrix M:")]
        //        public void Given_The_Following_Matrix(int rows, int columns, Table table)
        //        {
        //            _matrixContext.MatrixA = new RtMatrix(rows, columns);
        //            table.FillMatrix(_matrixContext.MatrixA);
        //        }

        [Then(@"A = B")]
        public void Then_A_Should_Equal_B()
        {
            Assert.Equal(_matrixContext.MatrixA, _matrixContext.MatrixB);
        }

        //        [Then(@"A is not invertible")]
        //        public void Then_A_Should_Not_Be_Invertible()
        //        {
        //            var actualIsInvertible = _matrixContext.MatrixA.IsInvertible();

        //            Assert.False(actualIsInvertible);
        //        }

        //        [Then(@"A is invertible")]
        //        public void Then_A_Should_Be_Invertible()
        //        {
        //            var actualIsInvertible = _matrixContext.MatrixA.IsInvertible();

        //            Assert.True(actualIsInvertible);
        //        }

        //        [Then(@"A \* b = tuple\((.*), (.*), (.*), (.*)\)")]
        //        public void Then_A_Multiplied_by_b_Equals_Tuple(double x, double y, double z, double w)
        //        {
        //            var expectedTuple = new RtTuple(x, y, z, w);
        //            var actualTuple = _matrixContext.MatrixA * _tupleContext.Tuple2;

        //            Assert.Equal(expectedTuple, actualTuple);
        //        }

        [Then(@"A != B")]
        public void Then_A_Should_Not_Be_Equal_To_B()
        {
            Assert.NotEqual(_matrixContext.MatrixA, _matrixContext.MatrixB);
        }

        //        [Then(@"A is the following matrix:")]
        //        public void Then_A_Should_Be_The_Following_Matrix(Table table)
        //        {
        //            var expectedMatrix = table.ToMatrix();

        //            Assert.Equal(expectedMatrix, _matrixContext.MatrixB);
        //        }

        //        [Then(@"C \* inverse\(B\) = A")]
        //        public void Then_C_Multiplied_By_Inverse_Of_B_Should_Equal_A()
        //        {
        //            var inverseOfB = _matrixContext.MatrixB.Inverse();

        //            var actualResults = _matrixContext.MatrixC * inverseOfB;

        //            Assert.Equal(_matrixContext.MatrixA, actualResults);
        //        }

        //        [Then(@"determinant\(A\) = (.*)")]
        //        public void Then_Determinant_Of_A_Should_Be(int expectedDeterminant)
        //        {
        //            var actualDeterminant = _matrixContext.MatrixA.Determinant();

        //            Assert.Equal(expectedDeterminant, actualDeterminant);
        //        }

        //        [Then(@"identity_matrix \* a = a")]
        //        public void Then_Identity_Matrix_Multiplied_By_a_Should_equals_a()
        //        {
        //            var actual = _matrixContext.MatrixA * _tupleContext.Tuple;

        //            Assert.Equal(_tupleContext.Tuple, actual);
        //        }

        //        [Then(@"cofactor\(A, (.*), (.*)\) = (.*)")]
        //        public void Then_The_Cofactor_Of_A_At_Row_Column_Should_Be(int row, int column, int expectedCofactor)
        //        {
        //            var actualCofactor = _matrixContext.MatrixA.Cofactor(row, column);

        //            Assert.Equal(expectedCofactor, actualCofactor);
        //        }

        //        [Then(@"determinant\(B\) = (.*)")]
        //        public void Then_The_Determinant_Of_B_Should_Be(int expectedDeterminant)
        //        {
        //            var actualDeterminante = _matrixContext.MatrixB.Determinant();

        //            Assert.Equal(expectedDeterminant, actualDeterminante);
        //        }

        //        [Then(@"inverse\(A\) is the following matrix:")]
        //        public void Then_The_Inverse_A_Should_Be_The_Following_Matrix(Table table)
        //        {
        //            var expectedMatrix = table.ToMatrix();

        //            var actualMatrix = _matrixContext.MatrixA.Inverse();

        //            Assert.Equal(expectedMatrix, actualMatrix);

        //        }

        //        [Then(@"minor\(A, (.*), (.*)\) = (.*)")]
        //        public void Then_The_Minor_Of_A_At_row_column_Should_Be_expectedMinor(int row, int column, int expectedMinor)
        //        {
        //            var actualMinor = _matrixContext.MatrixA.Minor(row, column);

        //            Assert.Equal(expectedMinor, actualMinor);
        //        }

        //        [Then(@"submatrix\(A, (.*), (.*)\) is the following matrix:")]
        //        public void Then_The_Submatrix_Of_A_Is_The_Following_Matrix(int row, int column, Table table)
        //        {
        //            RtMatrix expectedMatrix = table.ToMatrix();

        //            RtMatrix actual = _matrixContext.MatrixA.Remove(row, column);

        //            Assert.Equal(expectedMatrix, actual);
        //        }

        [Then(@"transpose\(A\) is the following matrix:")]
        public void Then_Transpose_A_Should_Be_The_Following_Matrix(Table table)
        {
            var expectedMatrix = table.ToMatrix();

            var actual = RtMatrix.Transpose(_matrixContext.MatrixA);

            Assert.Equal(expectedMatrix, actual);
        }

        [Then(@"A \* B is the following matrix:")]
        public void The_A_Multiplied_By_B_Should_Be_The_Following_Matrix(Table table)
        {
            var expectedMatrix = table.ToMatrix();

            var actualMatrix = _matrixContext.MatrixA * _matrixContext.MatrixB;

            Assert.Equal(expectedMatrix, actualMatrix);
        }

        [Then(@"A \* identity_matrix = A")]
        public void Then_A_Multiplied_By_Identity_Should_Be_A()
        {
            var identity = RtMatrix.Identity;

            var actual = _matrixContext.MatrixA * identity;

            Assert.Equal(_matrixContext.MatrixA, actual);
        }

        //        [Then(@"B\[(.*),(.*)] = (.*)/(.*)")]
        //        public void The_B_At_row_column_Should_Equal_numerator_Divided_By_denominator(int row, int column, double numerator, double denominator)
        //        {
        //            var expectedValue = numerator / denominator;

        //            var actualValue = _matrixContext.MatrixB[row, column];

        //            AssertDouble.ApproximateEquals(expectedValue, actualValue);
        //        }

        //        [Then(@"B is the following matrix:")]
        //        public void Then_B_Should_Be_The_Following_Matrix(Table table)
        //        {
        //            var expectedMatrix = table.ToMatrix();

        //            Assert.Equal(expectedMatrix, _matrixContext.MatrixB);
        //        }

        //        [Then(@"M\[(.*),(.*)] = (.*)")]
        //        public void Then_M_At_row_column_Should_Be_epectedValue(int row, int column, int expectedValue)
        //        {
        //            Assert.Equal(expectedValue, _matrixContext.MatrixA[row, column]);
        //        }

        //        [Then(@"The identity of A is:")]
        //        public void The_The_Identity_of_A_Should_Be(Table table)
        //        {
        //            var expectedMatrix = table.ToMatrix();

        //            var identity = _matrixContext.MatrixA.Identity();
        //            Assert.Equal(expectedMatrix, identity);
        //        }
    }
}
