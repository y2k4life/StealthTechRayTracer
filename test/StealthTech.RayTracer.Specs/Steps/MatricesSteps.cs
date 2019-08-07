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
        readonly MatrixContext _matrixContext;
        readonly PointsContext _pointsContext;

        public MatricesSteps(MatrixContext matrixContext, PointsContext pointsContext)
        {
            _pointsContext = pointsContext;
            _matrixContext = matrixContext;
        }

        //        [Given(@"B ← inverse\(A\)")]
        //        public void Given_B_Is_Inverse_Of_A()
        //        {
        //            _matrixContext.MatrixB = _matrixContext.MatrixA.Inverse();
        //        }

        [Given(@"C ← A \* B")]
        public void Given_C_Is_A_Multiplied_By_B()
        {
            _matrixContext.MatrixC = _matrixContext.MatrixA * _matrixContext.MatrixB;
        }

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

        [Then(@"A = B")]
        public void Then_A_Should_Equal_B()
        {
            Assert.Equal(_matrixContext.MatrixA, _matrixContext.MatrixB);
        }

        [Then(@"A is not invertible")]
        public void Then_A_Should_Not_Be_Invertible()
        {
            var actualIsInvertible = _matrixContext.MatrixA.IsInvertible();

            Assert.False(actualIsInvertible);
        }

        [Then(@"A is invertible")]
        public void Then_A_Should_Be_Invertible()
        {
            var actualIsInvertible = _matrixContext.MatrixA.IsInvertible();

            Assert.True(actualIsInvertible);
        }

        [Then(@"A \* b = Point\((.*), (.*), (.*)\)")]
        public void Then_A_Multiplied_by_b_Equals_Tuple(double x, double y, double z)
        {
            var expectedPoint = new RtPoint(x, y, z);
            var actualPoint = _matrixContext.MatrixA * _pointsContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"A != B")]
        public void Then_A_Should_Not_Be_Equal_To_B()
        {
            Assert.NotEqual(_matrixContext.MatrixA, _matrixContext.MatrixB);
        }

        [Then(@"C \* inverse\(B\) approximately equal to A")]
        public void Then_C_Multiplied_By_Inverse_Of_B_Should_Equal_A()
        {
            var inverseOfB = _matrixContext.MatrixB.Inverse();

            var actualResults = _matrixContext.MatrixC * inverseOfB;

            Assert.True(_matrixContext.MatrixA.ApproximateEqual(actualResults));
        }

        [Then(@"determinant\(A\) = (.*)")]
        public void Then_Determinant_Of_A_Should_Be(int expectedDeterminant)
        {
            var actualDeterminant = _matrixContext.MatrixA.Determinant();

            Assert.Equal(expectedDeterminant, actualDeterminant);
        }

        [Then(@"identity_matrix \* point = point")]
        public void Then_Identity_Matrix_Multiplied_By_a_Should_equals_a()
        {
            var actual = _matrixContext.MatrixA * _pointsContext.Point;

            Assert.Equal(_pointsContext.Point, actual);
        }

        [Then(@"inverse\(A\) is approximately equal to matrix:")]
        public void Then_The_Inverse_A_Should_Be_The_Following_Matrix(Table table)
        {
            var expectedMatrix = table.ToMatrix();

            var actualMatrix = _matrixContext.MatrixA.Inverse();

            Assert.True(expectedMatrix.ApproximateEqual(actualMatrix));
        }

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
    }
}
