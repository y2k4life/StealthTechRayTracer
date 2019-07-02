//-----------------------------------------------------------------------
// <copyright file="TuplesSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using TechTalk.SpecFlow;
using Xunit;
using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class TuplesSteps
    {
        readonly TupleContext _tupleContext;

        public TuplesSteps(TupleContext tupleContext)
        {
            _tupleContext = tupleContext;
        }

        [Given(@"a ← tuple\((.*), (.*), (.*), (.*)\)")]
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

        [Given(@"b ← tuple\((.*), (.*), (.*), (.*)\)")]
        public void Given_b_Tuple(double x, double y, double z, double w)
        {
            _tupleContext.Tuple2 = new RtTuple(x, y, z, w);
        }

        [Given(@"a1 ← tuple\((.*), (.*), (.*), (.*)\)")]
        public void GivenA1_Tuple(double x, double y, double z, double w)
        {
            _tupleContext.Tuple1 = new RtTuple(x, y, z, w);
        }

        [Given(@"a2 ← tuple\((.*), (.*), (.*), (.*)\)")]
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

        [Then(@"-a = tuple\((.*), (.*), (.*), (.*)\)")]
        public void Then_Negating_a_Equals_Tuple(double x, double y, double z, double w)
        {
            var expectedVector = new RtTuple(x, y, z, w);

            var actualVector = _tupleContext.Tuple.Negate();

            Assert.Equal(expectedVector, actualVector);
        }
    }
}
