//-----------------------------------------------------------------------
// <copyright file="ColorSteps.cs" company="StealthTech">
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
    public class ColorSteps
    {
        readonly ColorContext _colorContext;

        public ColorSteps(ColorContext colorContext)
        {
            _colorContext = colorContext;
        }

        [Given(@"c <- Color\((.*), (.*), (.*)\)")]
        public void GivenC_Color(double red, double green, double blue)
        {
            _colorContext.Color1 = new RtColor(red, green, blue);
        }

        [Then(@"c\.Red = (.*)")]
        public void ThenC_Red(double exprectedRed)
        {
            AssertDouble.ApproximateEquals(exprectedRed, _colorContext.Color1.Red);
        }

        [Then(@"c\.Green = (.*)")]
        public void Then_c_Green_Equals(double exprectedGreen)
        {
            AssertDouble.ApproximateEquals(exprectedGreen, _colorContext.Color1.Green);
        }

        [Then(@"c\.Blue = (.*)")]
        public void ThenC_Blue(double exprectedBlue)
        {
            AssertDouble.ApproximateEquals(exprectedBlue, _colorContext.Color1.Blue);
        }

        [Given(@"c1 <- Color\((.*), (.*), (.*)\)")]
        public void Given_c1_Color(double red, double green, double blue)
        {
            _colorContext.Color1 = new RtColor(red, green, blue);
        }

        [Given(@"c2 <- Color\((.*), (.*), (.*)\)")]
        public void Given_c2_Color(double red, double green, double blue)
        {
            _colorContext.Color2 = new RtColor(red, green, blue);
        }

        [Given(@"c3 <- Color\((.*), (.*), (.*)\)")]
        public void Given_c3_Color(double red, double green, double blue)
        {
            _colorContext.Color3 = new RtColor(red, green, blue);
        }


        [Then(@"c1 \+ c2 = Color\((.*), (.*), (.*)\)")]
        public void ThenCCColor(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            Assert.Equal(expectedColor, _colorContext.Color1 + _colorContext.Color2);
        }

        [Then(@"c1 - c2 = Color\((.*), (.*), (.*)\)")]
        public void ThenC_CColor(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            Assert.Equal(expectedColor, _colorContext.Color1 - _colorContext.Color2);
        }

        [Then(@"c \* (.*) = Color\((.*), (.*), (.*)\)")]
        public void Then_c_Multiplied_By_Equals(double multiplier, double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            Assert.Equal(expectedColor, _colorContext.Color1 * multiplier);
        }

        [Then(@"c1 \* c2 = Color\((.*), (.*), (.*)\)")]
        public void Then_c1_Multiplied_By_c2_Equals(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            Assert.Equal(expectedColor, _colorContext.Color1 * _colorContext.Color2);
        }

    }
}
