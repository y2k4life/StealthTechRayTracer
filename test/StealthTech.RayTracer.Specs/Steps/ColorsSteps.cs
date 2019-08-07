//-----------------------------------------------------------------------
// <copyright file="ColorSteps.cs" company="StealthTech">
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
    public class ColorsSteps
    {
        readonly ColorsContext _colorContext;

        public ColorsSteps(ColorsContext colorContext)
        {
            _colorContext = colorContext;
        }

        [Given(@"color ← Color\((.*), (.*), (.*)\)")]
        public void Given_color_Is_A_Color(double red, double green, double blue)
        {
            _colorContext.Color1 = new RtColor(red, green, blue);
        }

        [Given(@"color1 ← Color\((.*), (.*), (.*)\)")]
        public void Given_color1_Is_A_Color(double red, double green, double blue)
        {
            _colorContext.Color1 = new RtColor(red, green, blue);
        }

        [Given(@"color2 ← Color\((.*), (.*), (.*)\)")]
        public void Given_color2_Is_A_Color(double red, double green, double blue)
        {
            _colorContext.Color2 = new RtColor(red, green, blue);
        }

        [Given(@"color3 ← Color\((.*), (.*), (.*)\)")]
        public void Given_color3_Is_A_Color(double red, double green, double blue)
        {
            _colorContext.Color3 = new RtColor(red, green, blue);
        }

        [Given(@"red ← Color\((.*), (.*), (.*)\)")]
        public void Given_red_Is_A_Color(double red, double green, double blue)
        {
            _colorContext.Red = new RtColor(red, green, blue);
        }

        [Given(@"black ← Color\(0, 0, 0\)")]
        public void Given_black_Is_Color()
        {
            _colorContext.Black = RtColor.Black;
        }

        [Given(@"white ← Color\(1, 1, 1\)")]
        public void Given_white_Is_Color()
        {
            _colorContext.White = RtColor.White;
        }

        [Then(@"color \* (.*) = Color\((.*), (.*), (.*)\)")]
        public void Then_color_Multiplied_By_multiplier_Should_Equal_Color(double multiplier, double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actualColor = _colorContext.Color1 * multiplier;

            Assert.Equal(expectedColor, actualColor);
        }

        [Then(@"color1 \+ color2 = Color\((.*), (.*), (.*)\)")]
        public void Then_color1_Added_To_color2_Should_Equal_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actualColor = _colorContext.Color1 + _colorContext.Color2;

            Assert.Equal(expectedColor, actualColor);
        }

        [Then(@"color1 - color2 = Color\((.*), (.*), (.*)\)")]
        public void Then_color1_Minus_color2_Should_Equals_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actualColor = _colorContext.Color1 - _colorContext.Color2;

            Assert.Equal(expectedColor, actualColor);
        }

        [Then(@"color1 \* color2 = Color\((.*), (.*), (.*)\)")]
        public void Then_color1_Multiplied_By_color2_Should_Equal_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actualColor = _colorContext.Color1 * _colorContext.Color2;

            Assert.Equal(expectedColor, actualColor);
        }

        [Then(@"color\.Red = (.*)")]
        public void Then_Red_Of_color_Should_Equal(double exprectedRed)
        {
            AssertDouble.ApproximateEquals(exprectedRed, _colorContext.Color1.Red);
        }

        [Then(@"color\.Green = (.*)")]
        public void Then_Green_Of_color_Should_Equal(double exprectedGreen)
        {
            AssertDouble.ApproximateEquals(exprectedGreen, _colorContext.Color1.Green);
        }

        [Then(@"color\.Blue = (.*)")]
        public void Then_Blue_Of_color_Should_Equal(double exprectedBlue)
        {
            AssertDouble.ApproximateEquals(exprectedBlue, _colorContext.Color1.Blue);
        }

        [Then(@"color = Color\((.*), (.*), (.*)\)")]
        public void Then_color_Should_Equal_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actualColor = _colorContext.Color;

            Assert.Equal(expectedColor, actualColor);
        }

        [Then(@"color1 = Color\((.*), (.*), (.*)\)")]
        public void Then_color1_Should_Equal_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actualColor = _colorContext.Color1;

            Assert.Equal(expectedColor, actualColor);
        }

        [Then(@"color2 = Color\((.*), (.*), (.*)\)")]
        public void Then_color2_Should_Equal_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actualColor = _colorContext.Color2;

            Assert.Equal(expectedColor, actualColor);
        }

        [Then(@"color = white")]
        public void Then_color_should_equal_white()
        {
            Assert.Equal(_colorContext.White, _colorContext.Color);
        }

    }
}
