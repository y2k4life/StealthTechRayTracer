//-----------------------------------------------------------------------
// <copyright file="TransformationsSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class TransformationsSteps
    {
        readonly PointsContext _pointsContext;
        readonly TransformationsContext _transformationsContext;
        readonly VectorsContext _vectorsContext;

        public TransformationsSteps(TransformationsContext transformationContext,
            PointsContext pointsContext,
            VectorsContext vectorsContext)
        {
            _vectorsContext = vectorsContext;
            _pointsContext = pointsContext;
            _transformationsContext = transformationContext;
        }
        
        [Given(@"fullQuarter ← rotation_y\(π / 2\)")]
        public void Given_fullQuarter_Is_Rotation_On_The_Y()
        {
            _transformationsContext.FullQuarter = _transformationsContext.Transform.RotateY(Math.PI / 2);
        }

        [Given(@"fullQuarter ← rotation_x\(π / 2\)")]
        public void Given_fullQuarter_Is_Rotation_On_X()
        {
            _transformationsContext.FullQuarter = _transformationsContext.Transform.RotateX(Math.PI / 2);
        }

        [Given(@"full_quarter ← rotation_z\(π / 2\)")]
        public void Given_fullQuarter_Is_Rotation_On_Z()
        {
            _transformationsContext.FullQuarter = _transformationsContext.Transform.RotateZ(Math.PI / 2);
        }

        [Given(@"half_quarter ← rotation_y\(π / 4\)")]
        public void Given_halfQuarter_Is_Rotation_On_The_Y()
        {
            _transformationsContext.HalfQuarter = _transformationsContext.Transform.RotateY(Math.PI / 4);
        }

        [Given(@"halfQuarter ← rotation_z\(π / 4\)")]
        public void Given_halfQuarter_Is_Rotation_On_The_Z()
        {
            _transformationsContext.HalfQuarter = _transformationsContext.Transform.RotateZ(Math.PI / 4);
        }

        [Given(@"halfQuarter ← rotation_x\(π / 4\)")]
        public void Given_halfQuarter_Is_Rotation_On_X()
        {
            _transformationsContext.HalfQuarter = _transformationsContext.Transform.RotateX(Math.PI / 4);
        }

        [Given(@"inverseTransform ← inverse\(half_quarter\)")]
        public void Given_inverseTransform_Is_The_Inverse_Of_halfQuarter()
        {
            _transformationsContext.InverseTransform = _transformationsContext.HalfQuarter.Inverse();
        }

        [Given(@"inverseTransform ← inverse\(transform\)")]
        public void Given_inverseTransform_Is_The_Inverse_Of_transform()
        {
            _transformationsContext.InverseTransform = _transformationsContext.Transform.Inverse();
        }

        [Given(@"transform ← scaling\((.*), (.*), (.*)\)")]
        public void Given_transform_Is_Scaling(int x, int y, int z)
        {
            _transformationsContext.Transform = new Transform().Scaling(x, y, z);
        }

        [Given(@"transform ← shearing\((.*), (.*), (.*), (.*), (.*), (.*)\)")]
        public void Given_transform_Is_Shearing(double xy, double xz, double yx, double yz, double zx, double zy)
        {
            _transformationsContext.Transform = _transformationsContext.Transform.Shearing(xy, xz, yx, yz, zx, zy);
        }

        [Given(@"transform ← translation\((.*), (.*), (.*)\)")]
        public void Given_Transform_Is_Translation_Of_x_y_x(int x, int y, int z)
        {
            _transformationsContext.Transform = _transformationsContext.Transform.Translation(x, y, z);
        }

        [Given(@"transform ← rotation_z\(π / 5\)\.scaling\((.*), (.*), (.*)\)")]
        public void Given_transform_Is_Scaling_And_Rotating_z(double x, double y, double z)
        {
            _transformationsContext.Transform =
                new Transform()
                    .RotateZ(Math.PI / 5)
                    .Scaling(x, y, z);
        }

        [Given(@"transformA ← rotation_x\(π / 2\)")]
        public void Given_transformA_Is_Rotation_On_Z()
        {
            _transformationsContext.TransformA = _transformationsContext.Transform.RotateX(Math.PI / 2);
        }

        [Given(@"transformB ← scaling\((.*), (.*), (.*)\)")]
        public void Given_transformB_Is_Scaling(int x, int y, int z)
        {
            _transformationsContext.TransformB = _transformationsContext.Transform.Scaling(x, y, z);
        }

        [Given(@"transformC ← translation\((.*), (.*), (.*)\)")]
        public void Given_transformC_Is_Translation(int x, int y, int z)
        {
            _transformationsContext.TransformC = _transformationsContext.Transform.Translation(x, y, z);
        }

        [When(@"point2 ← transformA \* point")]
        public void When_point2_Is_transformA_Multiplied_By_point()
        {
            _pointsContext.Points[2] = _transformationsContext.TransformA * _pointsContext.Point;
        }

        [When(@"point3 ← transformB \* point2")]
        public void When_point3_Is_transformB_Multiplied_By_point2()
        {
            _pointsContext.Points[3] = _transformationsContext.TransformB * _pointsContext.Points[2];
        }

        [When(@"point4 ← transformC \* point3")]
        public void When_point4_Is_transformC_Multiplied_By_point3()
        {
            _pointsContext.Points[4] = _transformationsContext.TransformC * _pointsContext.Points[3];
        }

        [When(@"transform ← ViewTransform\(from, to, up\)")]
        public void When_t_Is_View_Transform_With_From_To_Up()
        {
            _transformationsContext.Transform = new ViewTransform(_pointsContext.From,
                                                   _pointsContext.To,
                                                   _vectorsContext.Up);
        }

        [When(@"transformT ← rotation_x\(π / 2\)\.scaling\((.*), (.*), (.*)\)\.translation\((.*), (.*), (.*)\)")]
        public void When_transformT_Is_Rotation_X_Scaling_Translation(int sx, int sy, int sz, int tx, int ty, int tz)
        {
            _transformationsContext.TransformT = new Transform()
                .RotateX(Math.PI / 2)
                .Scaling(sx, sy, sz)
                .Translation(tx, ty, tz);
        }

        [When(@"transformT ← transformC \* transformB \* transformA")]
        public void When_transformT_Is_transformC_Multiplied_By_transformB_Multiplied_By_transformA()
        {
            _transformationsContext.TransformT = _transformationsContext.TransformC * _transformationsContext.TransformB * _transformationsContext.TransformA;
        }

        [Then(@"fullQuarter \* point = Point\((.*), (.*), (.*)\)")]
        public void Then_fullQuarter_Multiplied_By_point_Equals_Point(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            var actualPoint = _transformationsContext.FullQuarter * _pointsContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"halfQuarter \* point = Point\((.*), (.*), (.*)\)")]
        public void Then_halfQuarter_Multiplied_By_point_Equals_Point(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            var actualPoint = _transformationsContext.HalfQuarter * _pointsContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"inverseTransform \* vector = Vector\((.*), (.*), (.*)\)")]
        public void Then_Inverse_Transform_Multiplied_By_vector_Equals_Vector(int x, int y, int z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _transformationsContext.InverseTransform * _vectorsContext.Vector;

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"inverseTransform \* p = Point\((.*), (.*), (.*)\)")]
        public void Then_inverseTransform_Multiplied_By_p_Equals_Point(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            var actualPoint = _transformationsContext.InverseTransform * _pointsContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"transform = identity_matrix")]
        public void Then_transform_Equals_Identity_Matrix()
        {
            Assert.True(_transformationsContext.Transform.Equals(RtMatrix.Identity));
        }

        [Then(@"transform \* point = Point\((.*), (.*), (.*)\)")]
        public void Then_Transform_Multiplied_By_point_Equals_A_Point(int x, int y, int z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            var actualPoint = _transformationsContext.Transform * _pointsContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"transform \* v = v")]
        public void Then_Transform_Multiplied_By_vector_Equals_vector()
        {
            var expectedVector = _vectorsContext.Vector;

            var actualVector = _transformationsContext.Transform * _vectorsContext.Vector;

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"transform \* vector = Vector\((.*), (.*), (.*)\)")]
        public void Then_Transform_Multiplied_By_vector_Equals_vector(int x, int y, int z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _transformationsContext.Transform * _vectorsContext.Vector;

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"transform = scaling\((.*), (.*), (.*)\)")]
        public void Then_transform_Should_Equal_scaling(double x, double y, double z)
        {
            var expectedMatrix = new Transform().Scaling(x, y, z);

            var actualMatrix = _transformationsContext.Transform;

            Assert.Equal(expectedMatrix, actualMatrix);
        }

        [Then(@"transform = translation\((.*), (.*), (.*)\)")]
        public void Then_transform_Should_Equal_Translation(double x, double y, double z)
        {
            var expectedMatrix = new Transform().Translation(x, y, z);

            var actualMatrix = _transformationsContext.Transform;

            Assert.Equal(expectedMatrix, actualMatrix);
        }

        //[Then(@"t is the following matrix:")]
        //public void Then_transform_Should_Following_Matrix(Table table)
        //{
        //    var expectedMatrix = table.ToMatrix();

        //    Assert.True(_transformationsContext.Transform.Equals(expectedMatrix));
        //}

        [Then(@"transformT \* point = Point\((.*), (.*), (.*)\)")]
        public void Then_transformT_Is_Multiplied_By_point_Equals_Point(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(x.EvaluateExpression(), y.EvaluateExpression(), z.EvaluateExpression());

            var actualPoint = _transformationsContext.TransformT * _pointsContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }


    }
}
