//-----------------------------------------------------------------------
// <copyright file="LightsSteps.cs" company="StealthTech">
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
    public class LightsSteps
    {
        readonly LightsContext _lightsContext;
        readonly PointsContext _pointsContext;
        readonly WorldContext _worldContext;
        readonly VectorsContext _vectorsContext;

        public LightsSteps(LightsContext lightsContext, 
            PointsContext pointsContext, 
            WorldContext worldContext, 
            VectorsContext vectorsContext)

        {
            _vectorsContext = vectorsContext;
            _worldContext = worldContext;
            _pointsContext = pointsContext;
            _lightsContext = lightsContext;
        }

        [Given(@"intensity ← color\((.*), (.*), (.*)\)")]
        public void Given_Intensity_Color(float red, float green, float blue)
        {
            _lightsContext.Intensity = new RtColor(red, green, blue);
        }

        [Given(@"light ← PointLight\(Point\((.*), (.*), (.*)\), Color\((.*), (.*), (.*)\)\)")]
        public void Given_light_Is_A_PointLight(float x, float y, float z, float red, float green, float blue)
        {
            _lightsContext.Light = new PointLight(new RtPoint(x, y, z), new RtColor(red, green, blue));
        }

        [Given(@"light ← AreaLight\(corner, vector1, (.*), vector2, (.*), Color\((.*), (.*), (.*)\)\)")]
        public void Given_light_Is_AreaLight(int uSteps, int vSteps, float red, float green, float blue)
        {
            _lightsContext.Light = new AreaLight(
                _pointsContext.Corner,
                _vectorsContext.Vector1,
                uSteps,
                _vectorsContext.Vector2,
                vSteps,
                new RtColor(red, green, blue));
        }

        [Given(@"areaLight ← AreaLight\(corner, vector1, (.*), vector2, (.*), Color\((.*), (.*), (.*)\)\)")]
        public void Given_areaLight_Is_AreaLight(int uSteps, int vSteps, float red, float green, float blue)
        {
            _lightsContext.AreaLight = new AreaLight(
                _pointsContext.Corner,
                _vectorsContext.Vector1,
                uSteps,
                _vectorsContext.Vector2,
                vSteps,
                new RtColor(red, green, blue));
        }

        [Given(@"areaLight\.JitterBy ← Sequence\((.*), (.*)\)")]
        public void Given_JitterBy_Of_Light_Is_Sequence(double n1, double n2)
        {
            _lightsContext.AreaLight.JitterBy = new DeterministicSequence(n1, n2);
        }

        [Given(@"areaLight\.JitterBy ← Sequence\((.*), (.*), (.*), (.*), (.*)\)")]
        public void Given_JitterBy_Of_Light_Is_Sequence(double n1, double n2, double n3, double n4, double n5)
        {
            _lightsContext.AreaLight.JitterBy = new DeterministicSequence(n1, n2, n3, n4, n5);
        }

        [When(@"point ← areaLight\.PointOnLight\((.*), (.*)\)")]
        public void When_point_Is_PointOnLight(int u, int v)
        {
            _pointsContext.Point = _lightsContext.AreaLight.PointOnLight(u, v);
        }

        [When(@"areaLight ← AreaLight\(corner, vector1, (.*), vector2, (.*), Color\((.*), (.*), (.*)\)\)")]
        public void When_light_Is_AreaLight(int uSteps, int vSteps, float red, float green, float blue)
        {
            _lightsContext.AreaLight = new AreaLight(
                _pointsContext.Corner,
                _vectorsContext.Vector1,
                uSteps,
                _vectorsContext.Vector2,
                vSteps,
                new RtColor(red, green, blue));
        }

        [When(@"light ← point_light\(position, intensity\)")]
        public void WhenLightPoint_LightPositionIntensity()
        {
            _lightsContext.Light = new PointLight(_lightsContext.Position, _lightsContext.Intensity);
        }

        [When(@"intensityAt ← light\.IntensityAt\(point, world\)")]
        public void When_intensityAt_Is_The_Result_Of_IntensityAtPointWorld_Of_Light()
        {
            _lightsContext.IntensityAt = _lightsContext.Light.IntensityAt(_pointsContext.Point, _worldContext.World);
        }

        [When(@"intensityAt ← areaLight\.IntensityAt\(point, world\)")]
        public void When_intensityAt_Is_The_Result_Of_IntensityAtPointWorld_Of_AreaLight()
        {
            _lightsContext.IntensityAt = _lightsContext.AreaLight.IntensityAt(_pointsContext.Point, _worldContext.World);
        }

        [Then(@"light\.position = position")]
        public void Then_Light_Position_Equals_Position()
        {
            Assert.Equal(_lightsContext.Position, _lightsContext.Light.Position);
        }

        [Then(@"light\.intensity = intensity")]
        public void Then_Light_Intensity_Equals_Intensity()
        {
            Assert.Equal(_lightsContext.Position, _lightsContext.Light.Position);
        }

        [Then(@"intensityAt = (.*)")]
        public void Then_Intensity_Should_Equal(float expectedIntensity)
        {
            AssertDouble.ApproximateEquals(expectedIntensity, _lightsContext.IntensityAt);
        }

        [Then(@"areaLight\.Corner = corner")]
        public void Then_areaLight_Corner_Should_Equal_corner()
        {
            Assert.Equal(_pointsContext.Corner, _lightsContext.AreaLight.Corner);
        }

        [Then(@"areaLight\.UVector = Vector\((.*), (.*), (.*)\)")]
        public void Then_UVector_Of_AreaLight_Should_Equal(float x, float y, float z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _lightsContext.AreaLight.UVector);
        }

        [Then(@"areaLight\.USteps = (.*)")]
        public void Then_USteps_Of_areaLight_Should_Equal(int expectedUSteps)
        {
            Assert.Equal(expectedUSteps, _lightsContext.AreaLight.USteps);
        }

        [Then(@"areaLight\.VVector = vector\((.*), (.*), (.*)\)")]
        public void Then_VVector_Of_AreaLight_Should_Equal(float x, float y, float z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _lightsContext.AreaLight.VVector);
        }

        [Then(@"areaLight\.VSteps = (.*)")]
        public void Then_VSteps_Of_areaLight_Should_Equal(int expectedVSteps)
        {
            Assert.Equal(expectedVSteps, _lightsContext.AreaLight.VSteps);
        }

        [Then(@"areaLight\.Samples = (.*)")]
        public void Then_Samples_Of_areaLight_Should_Equal(int expectedSamples)
        {
            Assert.Equal(expectedSamples, _lightsContext.AreaLight.Samples);
        }

        [Then(@"areaLight\.Position = point\((.*), (.*), (.*)\)")]
        public void Then_Position_Of_AreaLight_Should_Equal(float x, float y, float z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            Assert.Equal(expectedPoint, _lightsContext.AreaLight.Position);
        }
    }
}
