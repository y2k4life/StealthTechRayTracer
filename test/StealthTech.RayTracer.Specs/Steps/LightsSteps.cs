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

        public LightsSteps(LightsContext lightsContext)
        {
            _lightsContext = lightsContext;
        }

        [Given(@"intensity ← color\((.*), (.*), (.*)\)")]
        public void Given_Intensity_Color(double red, double green, double blue)
        {
            _lightsContext.Intensity = new RtColor(red, green, blue);
        }

        [Given(@"light ← PointLight\(Point\((.*), (.*), (.*)\), Color\((.*), (.*), (.*)\)\)")]
        public void Given_light_Is_A_PointLight(double x, double y, double z, double red, double green, double blue)
        {
            _lightsContext.Light = new PointLight(new RtPoint(x, y, z), new RtColor(red, green, blue));
        }

        [When(@"light ← point_light\(position, intensity\)")]
        public void WhenLightPoint_LightPositionIntensity()
        {
            _lightsContext.Light = new PointLight(_lightsContext.Position, _lightsContext.Intensity);
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
    }
}
