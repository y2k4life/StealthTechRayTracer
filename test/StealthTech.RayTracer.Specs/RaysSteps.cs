//-----------------------------------------------------------------------
// <copyright file="RaysSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs
{

    [Binding]
    public class RaysSteps
    {
        private readonly TuplesContext _tupleContext;
        readonly RayContext _rayContext;

        public RaysSteps(TuplesContext tupleContext, RayContext rayContext)
        {
            _rayContext = rayContext;
            _tupleContext = tupleContext;
        }

        [When(@"r ← ray\(origin, direction\)")]
        public void When_r_OriginDirection()
        {
            _rayContext.Ray = new Ray(_tupleContext.Origin, _tupleContext.Direction);
        }

        [Then(@"r\.origin = origin")]
        public void Then_r_Origin_Equal_Origin()
        {
            Assert.Equal(_tupleContext.Origin, _rayContext.Ray.Origin);
        }

        [Then(@"r\.direction = direction")]
        public void ThenR_DirectionDirection()
        {
            Assert.Equal(_tupleContext.Direction, _rayContext.Ray.Direction);
        }

        [Given(@"r ← ray\(point\((.*), (.*), (.*)\), vector\((.*), (.*), (.*)\)\)")]
        public void Given_r_Is_Point_Vector(double pX, double pY, double pZ, double dX, double dY, double dZ)
        {
            _rayContext.Ray = new Ray(new RtPoint(pX, pY, pZ), new RtVector(dX, dY, dZ));
        }

        [Then(@"position\((.*)\) = point\((.*), (.*), (.*)\)")]
        public void Then_Position_p_Equals_Point_x_y_z(double p, double x, double y, double z)
        {
            var expectedPosition = new RtPoint(x, y, z);

            RtPoint actualPosition = _rayContext.Ray.Position(p);

            Assert.Equal(expectedPosition, actualPosition);
        }

        [Given(@"m ← translation\((.*), (.*), (.*)\)")]
        public void Given_m_Is_Translation_Of_(double x, double y, double z)
        {
            _rayContext.M = new Transform().Translation(x, y, z);
        }

        [When(@"r2 ← transform\(r, m\)")]
        public void WhenRTransformRM()
        {
            _rayContext.Ray2 = _rayContext.Ray.Transform(_rayContext.M.Matrix);
        }

        [Then(@"r2\.origin = point\((.*), (.*), (.*)\)")]
        public void Then_r2_Origin_Equals_Point(double x, double y, double z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            Assert.Equal(_rayContext.Ray2.Origin, expectedPoint);
        }

        [Then(@"r2\.direction = vector\((.*), (.*), (.*)\)")]
        public void Then_r2_Direction_Equals_Vector(double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(_rayContext.Ray2.Direction, expectedVector);
        }

        [Given(@"m ← scaling\((.*), (.*), (.*)\)")]
        public void GivenMScaling(double x, double y, double z)
        {
            _rayContext.M = new Transform().Scaling(x, y, z);
        }

    }
}
