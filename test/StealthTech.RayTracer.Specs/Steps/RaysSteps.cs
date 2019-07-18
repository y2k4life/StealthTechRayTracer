//-----------------------------------------------------------------------
// <copyright file="RaysSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{

    [Binding]
    public class RaysSteps
    {
        readonly CameraContext _cameraContext;
        readonly PointsContext _pointsContext;
        readonly RayContext _rayContext;
        readonly VectorsContext _vectorsContext;
        readonly TransformationsContext _transformationsContext;

        public RaysSteps(TupleContext tupleContext,
            RayContext rayContext,
            CameraContext cameraContext,
            PointsContext pointsContext,
            VectorsContext vectorsContext,
            TransformationsContext transformationsContext)
        {
            _transformationsContext = transformationsContext;
            _vectorsContext = vectorsContext;
            _pointsContext = pointsContext;
            _cameraContext = cameraContext;
            _rayContext = rayContext;
        }

        [Given(@"ray ← Ray\(Point\((.*), (.*), (.*)\), Vector\((.*), (.*), (.*)\)\)")]
        public void Given_ray_Is_Ray(string pX, string pY, string pZ, string dX, string dY, string dZ)
        {
            _rayContext.Ray = new Ray(
                new RtPoint(pX.EvaluateExpression(), pY.EvaluateExpression(), pZ.EvaluateExpression()), 
                new RtVector(dX.EvaluateExpression(), dY.EvaluateExpression(), dZ.EvaluateExpression()));
        }

          [Then(@"ray\.Origin = origin")]
        public void Then_Origin_Of_ray_Should_Equal_Origin()
        {
            var expectedOrigin = _pointsContext.Origin;
            var actualOrigin = _rayContext.Ray.Origin;

            Assert.Equal(expectedOrigin, actualOrigin);
        }

        [Then(@"position\((.*)\) = Point\((.*), (.*), (.*)\)")]
        public void Then_Position_Of_p_Should_Equal_Point(double p, double x, double y, double z)
        {
            var expectedPosition = new RtPoint(x, y, z);

            RtPoint actualPosition = _rayContext.Ray.Position(p);

            Assert.Equal(expectedPosition, actualPosition);
        }

        [Then(@"ray\.Direction = Vector\((.*), (.*), (.*)\)")]
        public void Then_Direction_Of_Ray_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedDirection = new RtVector(x, y, z);

            var actualDirection = _rayContext.Ray.Direction;

            Assert.Equal(expectedDirection, actualDirection);
        }

        [Then(@"ray\.Origin = Point\((.*), (.*), (.*)\)")]
        public void Then_Origin_Of_ray_Should_Equal_Point(double x, double y, double z)
        {
            var expectedOrigin = new RtPoint(x, y, z);

            var actualOrigin = _rayContext.Ray.Origin;

            Assert.Equal(expectedOrigin, actualOrigin);
        }

        [Then(@"ray2\.Direction = Vector\((.*), (.*), (.*)\)")]
        public void Then_Direction_Of_ray2_Should_Equal_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            var actualVector = _rayContext.Ray2.Direction;

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"ray2\.Origin = Point\((.*), (.*), (.*)\)")]
        public void Then_Origin_Of_ray2_Should_Equal_Point(double x, double y, double z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            var actualPoint = _rayContext.Ray2.Origin;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"ray\.Direction = direction")]
        public void Then_Direction_Of_r_Equals_direction()
        {
            var expectedDirection = _vectorsContext.Direction;

            var actualDirection = _rayContext.Ray.Direction;

            Assert.Equal(expectedDirection, actualDirection);
        }

        [When(@"ray ← Ray\(origin, direction\)")]
        public void When_r_Is_A_Ray()
        {
            _rayContext.Ray = new Ray(_pointsContext.Origin, _vectorsContext.Direction);
        }

        [When(@"ray2 ← transform\(r, transform\)")]
        public void WhenRTransformRM()
        {
            _rayContext.Ray2 = _rayContext.Ray.Transform(_transformationsContext.Transform.Matrix);
        }
    }
}
