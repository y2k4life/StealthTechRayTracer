//-----------------------------------------------------------------------
// <copyright file="TuplesSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using TechTalk.SpecFlow;
using Xunit;
using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs
{
    [Binding]
    public class TuplesSteps
    {
        readonly TuplesContext _tupleContext;

        public TuplesSteps(TuplesContext tupleContext)
        {
            _tupleContext = tupleContext;
        }

        [Given(@"a <- tuple\((.*), (.*), (.*), (.*)\)")]
        public void Given_a_Tuple(double x, double y, double z, double w)
        {
            _tupleContext.Tuple = new RtTuple(x, y, z, w);
        }
        
        [Then(@"a\.X = (.*)")]
        public void ThenA_X(double x)
        {
            Assert.Equal(x, _tupleContext.Tuple.X);
        }
        
        [Then(@"a\.Y = (.*)")]
        public void ThenA_Y(double y)
        {
            Assert.Equal(y, _tupleContext.Tuple.Y);
        }
        
        [Then(@"a\.Z = (.*)")]
        public void Then_a_Z_Equals(double z)
        {
            Assert.Equal(z, _tupleContext.Tuple.Z);
        }
        
        [Then(@"a\.W = (.*)")]
        public void ThenA_W(double w)
        {
            Assert.Equal(w, _tupleContext.Tuple.W);
        }
        
        [Then(@"a is a point")]
        public void Then_a_Is_A_Point()
        {
            Assert.True(_tupleContext.Tuple.IsPoint);
        }
        
        [Then(@"a is not a vector")]
        public void Then_aIs_Not_A_Vector()
        {
            Assert.False(_tupleContext.Tuple.IsVector);
        }

        [Then(@"a is not a point")]
        public void Then_a_Is_Not_A_Point()
        {
            Assert.False(_tupleContext.Tuple.IsPoint);
        }

        [Then(@"a is a vector")]
        public void Then_a_Is_A_Vector()
        {
            Assert.True(_tupleContext.Tuple.IsVector);
        }

        [Given(@"b <- tuple\((.*), (.*), (.*), (.*)\)")]
        public void Given_b_Tuple(double x, double y, double z, double w)
        {
            _tupleContext.Tuple2 = new RtTuple(x, y, z, w);
        }

        [Given(@"p <- point\((.*), (.*), (.*)\)")]
        public void GivenP_Point(double x, double y, double z)
        {
            _tupleContext.Point = RtTuple.Point(x, y, z);
        }

        [Then(@"p = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_p_Equals_Tuple(double x, double y, double z, double w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);

            Assert.Equal(expectedTuple, _tupleContext.Point);
        }

        [Given(@"v <- vector\((.*), (.*), (.*)\)")]
        public void Given_v_Vector(double x, double y, double z)
        {
            _tupleContext.Vector = RtTuple.Vector(x, y, z);
        }

        [Then(@"v = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_v_Equals_Tuple(double x, double y, double z, double w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);

            Assert.Equal(expectedTuple, _tupleContext.Vector);
        }

        [Given(@"a1 <- tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenA1_Tuple(double x, double y, double z, double w)
        {
            _tupleContext.Tuple1 = new RtTuple(x, y, z, w);
        }

        [Given(@"a2 <- tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenA2_Tuple(double x, double y, double z, double w)
        {
            _tupleContext.Tuple2 = new RtTuple(x, y, z, w);
        }

        [Then(@"a1 \+ a2 = tuple\((.*), (.*), (.*), (.*)\)")]
        public void ThenAATuple(double x, double y, double z, double w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);

            Assert.Equal(expectedTuple, _tupleContext.Tuple1 + _tupleContext.Tuple2);
        }

        [Given(@"p1 <- point\((.*), (.*), (.*)\)")]
        public void GivenP1_Point(double x, double y, double z)
        {
            _tupleContext.Point1 = RtTuple.Point(x, y, z);
        }

        [Given(@"p2 <- point\((.*), (.*), (.*)\)")]
        public void GivenP2_Point(double x, double y, double z)
        {
            _tupleContext.Point2 = RtTuple.Point(x, y, z);
        }

        [Then(@"p1 - p2 = vector\((.*), (.*), (.*)\)")]
        public void Then_p1_minus_p2_Equals_Vector(double x, double y, double z)
        {
            var expectedTuple = RtTuple.Vector(x, y, z);

            Assert.Equal(expectedTuple, _tupleContext.Point1 - _tupleContext.Point2);
        }

        [Then(@"p - v = point\((.*), (.*), (.*)\)")]
        public void Then_p_Minus_v_Equals_Point(double x, double y, double z)
        {
            var expectedTuple = RtTuple.Point(x, y, z);

            Assert.Equal(expectedTuple, _tupleContext.Point - _tupleContext.Vector);
        }

        [Then(@"a \* (.*) = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_a_Multiplied_By_Number_Equals_Tuple(double number, double x, double y, double z, double w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);

            Assert.Equal(expectedTuple, _tupleContext.Tuple * number);
        }

        [Then(@"(.*) \* a = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_Number_Multiplied_By_a_Equals_Tuple(double number, double x, double y, double z, double w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);

            Assert.Equal(expectedTuple, number * _tupleContext.Tuple);
        }

        [Then(@"a / (.*) = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_a_Divided_By_Number_Equals_Tuple(double number, double x, double y, double z, double w)
        {
            var expectedTuple = new RtTuple(x, y, z, w);

            Assert.Equal(expectedTuple, _tupleContext.Tuple / number);
        }

        [Then(@"magnitude\(v\) = (.*)")]
        public void Then_Magnitude_v(double expectedMagnitude)
        {
            Assert.True(_tupleContext.Vector.Magnitude.ApproximateEquals(expectedMagnitude));
        }

        [Then(@"normalize\(v\) = vector\((.*), (.*), (.*)\)")]
        public void Then_Normalize_v_equals_Vector(double x, double y, double z)
        {
            var expectedVector = RtTuple.Vector(x, y, z);

            var actual = _tupleContext.Vector.Normalized;

            Assert.Equal(expectedVector, actual);
        }

        [Then(@"normalize\(v\) = approximately vector\((.*), (.*), (.*)\)")]
        public void Then_Normalize_v_Equals_Approximately_Vector(double x, double y, double z)
        {
            var expectedVector = RtTuple.Vector(x, y, z);

            var actual = _tupleContext.Vector.Normalized;

            Assert.Equal(expectedVector, actual);
        }

        [When(@"norm <- normalize\(v\)")]
        public void When_norm_Equals_Normalize_v()
        {
            _tupleContext.NormalizedVector = _tupleContext.Vector.Normalized;
        }

        [Then(@"magnitude\(norm\) = (.*)")]
        public void Then_Magnitude_norm(double expectedNormal)
        {
            Assert.Equal(expectedNormal, _tupleContext.NormalizedVector.Magnitude);
        }

        [Given(@"v1 <- vector\((.*), (.*), (.*)\)")]
        public void Given_v1_Vector(double x, double y, double z)
        {
            _tupleContext.Vector1 = RtTuple.Vector(x, y, z);
        }

        [Given(@"v2 <- vector\((.*), (.*), (.*)\)")]
        public void Given_v2_Vector(double x, double y, double z)
        {
            _tupleContext.Vector2 = RtTuple.Vector(x, y, z);
        }

        [Then(@"dot\(v1, v2\) = (.*)")]
        public void Then_Dot_v1_v2(int expectedDot)
        {
            Assert.Equal(expectedDot, _tupleContext.Vector1.Dot(_tupleContext.Vector2));
        }

        [Then(@"cross\(v1, v2\) = vector\((.*), (.*), (.*)\)")]
        public void ThenCross_v1_v2_Equals_Vector(double x, double y, double z)
        {
            var expectedVector = RtTuple.Vector(x, y, z);

            Assert.Equal(expectedVector, _tupleContext.Vector1.Cross(_tupleContext.Vector2));
        }

        [Then(@"cross\(v2, v1\) = vector\((.*) (.*), (.*)\)")]
        public void ThenCrossVVVector(double x, double y, double z)
        {
            var expectedVector = RtTuple.Vector(x, y, z);

            Assert.Equal(expectedVector, _tupleContext.Vector2.Cross(_tupleContext.Vector1));
        }

        [Then(@"v1 - v2 = vector\((.*), (.*), (.*)\)")]
        public void Then_v1_minus_v2_equals_Vector(double x, double y, double z)
        {
            var expectedVector = RtTuple.Vector(x, y, z);

            Assert.Equal(expectedVector, _tupleContext.Vector1 - _tupleContext.Vector2);
        }

        [Given(@"zero <- vector\(0, 0, 0\)")]
        public void Given_Zero_Vector()
        {
            _tupleContext.ZeroVector = RtTuple.ZeroVector;
        }

        [Then(@"zero - v = vector\((.*), (.*), (.*)\)")]
        public void ThenZero_VVector(double x, double y, double z)
        {
            var expectedVector = RtTuple.Vector(x, y, z);

            var actualVector = _tupleContext.ZeroVector - _tupleContext.Vector;

            Assert.Equal(expectedVector, actualVector);
        }

        [Then(@"-a = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_Negating_a_Equals_Tuple(double x, double y, double z, double w)
        {
            var expectedVector = new RtTuple(x, y, z, w);

            var actualVector = _tupleContext.Tuple.Negate();

            Assert.Equal(expectedVector, actualVector);
        }

    }
}
