//-----------------------------------------------------------------------
// <copyright file="TransformationsSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs
{
    [Binding]
    public class TransformationsSteps
    {
        readonly TuplesContext _tupleContext;
        readonly TransformationContext _transformationContext;

        public TransformationsSteps(TransformationContext transformationContext, TuplesContext tuplesContext)
        {
            _transformationContext = transformationContext;
            _tupleContext = tuplesContext;
        }

        [Given(@"transform ← translation\((.*), (.*), (.*)\)")]
        public void Given_Transform_Is_Translation_Of_x_y_x(int x, int y, int z)
        {
            _transformationContext.Transform = _transformationContext.Transform.Translation(x, y, z);
        }

        [Then(@"transform \* p = point\((.*), (.*), (.*)\)")]
        public void Then_Transform_Multiplied_By_p_Equals_Point_x_y_x(int x, int y, int z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            var actualPoint = _transformationContext.Transform * _tupleContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Given(@"inv ← inverse\(transform\)")]
        public void Given_Inv_Is_Inverse_Transform()
        {
            _transformationContext.InverseTransform = _transformationContext.Transform.Inverse();
        }

        [Then(@"inv \* p = point\((.*), (.*), (.*)\)")]
        public void Then_Inverse_Transform_Multiplied_By_p_Equals_Point_x_y_x(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));

            var actualPoint = _transformationContext.InverseTransform * _tupleContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"transform \* v = v")]
        public void Then_Transform_Multiplied_By_v_Equals_v()
        {
            RtVector actualVector = _transformationContext.Transform * _tupleContext.Vector;

            Assert.Equal(_tupleContext.Vector, actualVector);
        }

        [Given(@"transform ← scaling\((.*), (.*), (.*)\)")]
        public void Given_Transform_Is_Scaling_x_y_z(int x, int y, int z)
        {
            _transformationContext.Transform = new Transform().Scaling(x, y, z);
        }

        [Then(@"transform \* v = vector\((.*), (.*), (.*)\)")]
        public void Then_Transform_Multiplied_By_v_Equals_Vector_x_y_x(int x, int y, int z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _transformationContext.Transform * _tupleContext.Vector;

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"inv \* v = vector\((.*), (.*), (.*)\)")]
        public void Then_Inverse_Transform_Multiplied_By_v_Equals_Vector_x_y_x(int x, int y, int z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _transformationContext.InverseTransform * _tupleContext.Vector;

            Assert.Equal(expectedVector, actualVector);
        }

        [Given(@"half_quarter ← rotation_x\(π / 4\)")]
        public void Given_Half_Quarter_Is_Rotation_On_X()
        {
            _transformationContext.HalfQuarter = _transformationContext.Transform.RotateX(Math.PI / 4);
        }

        [Given(@"full_quarter ← rotation_x\(π / 2\)")]
        public void Given_Full_Quarter_Is_Rotation_On_X()
        {
            _transformationContext.FullQuarter = _transformationContext.Transform.RotateX(Math.PI / 2);
        }

        [Then(@"half_quarter \* p = point\((.*), (.*), (.*)\)")]
        public void Then_Half_Quarter_Rotation_Multiplied_By_p_Equals_Point_x_y_x(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));

            var actualPoint = _transformationContext.HalfQuarter * _tupleContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"full_quarter \* p = point\((.*), (.*), (.*)\)")]
        public void Then_Full_Quarter_Rotation_Multiplied_By_p_Equals_Point_x_y_x(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));

            var actualPoint = _transformationContext.FullQuarter * _tupleContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Given(@"inv ← inverse\(half_quarter\)")]
        public void Given_Inverse_Is_Half_Quarter_Rotation()
        {
            _transformationContext.InverseTransform = _transformationContext.HalfQuarter.Inverse();
        }

        [Given(@"half_quarter ← rotation_y\(π / 4\)")]
        public void Given_Half_Quarter_Is_Rotation_On_The_Y()
        {
            _transformationContext.HalfQuarter = _transformationContext.Transform.RotateY(Math.PI / 4);
        }

        [Given(@"full_quarter ← rotation_y\(π / 2\)")]
        public void Given_Full_Quarter_Is_Rotation_On_The_Y()
        {
            _transformationContext.FullQuarter = _transformationContext.Transform.RotateY(Math.PI / 2);
        }

        [Given(@"half_quarter ← rotation_z\(π / 4\)")]
        public void Given_Half_Quarter_Is_Rotation_On_The_Z()
        {
            _transformationContext.HalfQuarter = _transformationContext.Transform.RotateZ(Math.PI / 4);
        }

        [Given(@"full_quarter ← rotation_z\(π / 2\)")]
        public void Given_Full_Quarter_Is_Rotation_On_Z()
        {
            _transformationContext.FullQuarter = _transformationContext.Transform.RotateZ(Math.PI / 2);
        }

        [Given(@"transform ← shearing\((.*), (.*), (.*), (.*), (.*), (.*)\)")]
        public void Given_Transform_Shearing_xy_xz_yx_yz_zx_zy(double xy, double xz, double yx, double yz, double zx, double zy)
        {
            _transformationContext.Transform = _transformationContext.Transform.Shearing(xy, xz, yx, yz, zx, zy);
        }

        [Given(@"A ← rotation_x\(π / 2\)")]
        public void Given_Transform_A_Is_Rotation_On_Z()
        {
            _transformationContext.A = _transformationContext.Transform.RotateX(Math.PI / 2);
        }

        [Given(@"B ← scaling\((.*), (.*), (.*)\)")]
        public void Given_Transform_B_Scaling_x_y_z(int x, int y, int z)
        {
            _transformationContext.B = _transformationContext.Transform.Scaling(x, y, z);
        }

        [Given(@"C ← translation\((.*), (.*), (.*)\)")]
        public void Given_Transform_C_Is_Translation_x_y_z(int x, int y, int z)
        {
            _transformationContext.C = _transformationContext.Transform.Translation(x, y, z);
        }

        [When(@"p2 ← A \* p")]
        public void When_p2_Is_A_Multiplied_By_p()
        {
            _tupleContext.Point2 = _transformationContext.A * _tupleContext.Point;
        }

        [Then(@"p2 = point\((.*), (.*), (.*)\)")]
        public void Then_p2_Equals_Point(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));

            Assert.Equal(expectedPoint, _tupleContext.Point2);
        }

        [When(@"p3 ← B \* p2")]
        public void When_p3_Is_B_Multiplied_By_p2()
        {
            _tupleContext.Point3 = _transformationContext.B * _tupleContext.Point2;
        }

        [Then(@"p3 = point\((.*), (.*), (.*)\)")]
        public void Then_p3_Equals_Point_x_y_z(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));

            Assert.Equal(expectedPoint, _tupleContext.Point3);
        }

        [When(@"p4 ← C \* p3")]
        public void When_p4_Is_C_Multiplied_By_p3()
        {
            _tupleContext.Point4 = _transformationContext.C * _tupleContext.Point3;
        }

        [Then(@"p4 = point\((.*), (.*), (.*)\)")]
        public void Then_p4_Equals_Point_x_y_z(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));

            Assert.Equal(expectedPoint, _tupleContext.Point4);
        }

        [When(@"T ← C \* B \* A")]
        public void When_T_Is_C_Multiplied_By_B_Multiplied_By_A()
        {
            _transformationContext.T = _transformationContext.C * _transformationContext.B * _transformationContext.A;
        }

        [Then(@"T \* p = point\((.*), (.*), (.*)\)")]
        public void Then_T_Is_Multiplied_By_p_Equals_Point_x_y_z(string x, string y, string z)
        {
            var expectedPoint = new RtPoint(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));

            var actualPoint = _transformationContext.T * _tupleContext.Point;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [When(@"T ← rotation_x\(π / 2\)\.scaling\((.*), (.*), (.*)\)\.translation\((.*), (.*), (.*)\)")]
        public void When_T_Is_Rotation_X_Scaling_Translation(int sx, int sy, int sz, int tx, int ty, int tz)
        {
            _transformationContext.T = new Transform()
                .RotateX(Math.PI / 2)
                .Scaling(sx, sy, sz)
                .Translation(tx, ty, tz);
        }

        [Given(@"from ← point\((.*), (.*), (.*)\)")]
        public void Given_from_Is_Point(double x, double y, double z)
        {
            _transformationContext.From = new RtPoint(x, y, z);
        }

        [Given(@"to ← point\((.*), (.*), (.*)\)")]
        public void Given_to_Is_Point(double x, double y, double z)
        {
            _transformationContext.To = new RtPoint(x, y, z);
        }

        [Given(@"up ← vector\((.*), (.*), (.*)\)")]
        public void Given_up_Is_A_Vector(double x, double y, double z)
        {
            _transformationContext.Up = new RtVector(x, y, z);
        }

        [When(@"t ← view_transform\(from, to, up\)")]
        public void When_t_Is_View_Transform_With_From_To_Up()
        {
            _transformationContext.Transform = new ViewTransform(_transformationContext.From, 
                                                   _transformationContext.To, 
                                                   _transformationContext.Up);
        }

        [Then(@"t = identity_matrix")]
        public void Then_t_Equals_Identity_Matrix()
        {
            var expectedMatrix = new RtMatrix(4, 4).Identity();

            var actualMatrix = _transformationContext.Transform.Matrix;

            Assert.Equal(expectedMatrix, actualMatrix);
        }

        [Then(@"t = scaling\((.*), (.*), (.*)\)")]
        public void Then_t_Equals_Scaling(double x, double y, double z)
        {
            var expectedMatrix = new Transform().Scaling(x, y, z);

            var actualMatrix = _transformationContext.Transform;

            Assert.Equal(expectedMatrix, actualMatrix);
        }

        [Then(@"t = translation\((.*), (.*), (.*)\)")]
        public void Then_t_Equals_Translation(double x, double y, double z)
        {
            var expectedMatrix = new Transform().Translation(x, y, z);

            var actualMatrix = _transformationContext.Transform;

            Assert.Equal(expectedMatrix, actualMatrix);
        }

        [Then(@"t is the following matrix:")]
        public void Then_t_Is_The_Following_Matrix(Table table)
        {
            var expectedMatrix = table.ToMatrix(true);

            var actualMatrix = _transformationContext.Transform.Matrix;

            Assert.Equal(expectedMatrix, actualMatrix);
        }







        private double ConvertCoordinate(string coordiante)
        {
            if (coordiante.Length == 5)
            {
                return (Math.Sqrt(2) / 2) * -1;
            }
            else if (coordiante.Length == 4)
            {
                return (Math.Sqrt(2) / 2);
            }

            return Convert.ToInt32(coordiante);
        }
    }
}
