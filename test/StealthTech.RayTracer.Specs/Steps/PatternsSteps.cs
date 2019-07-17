using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class PatternsSteps
    {
        readonly PatternsContext _patternsContext;
        readonly ColorsContext _colorContext;
        readonly SphereContext _sphereContext;

        public PatternsSteps(PatternsContext patternsContext, ColorsContext colorContext, SphereContext sphereContext)
        {
            _sphereContext = sphereContext;
            _colorContext = colorContext;
            _patternsContext = patternsContext;
        }

        [Given(@"pattern ← StripePattern\(white, black\)")]
        public void Given_pattern_Is_A_Pattern()
        {
            _patternsContext.Pattern = new StripePattern(_colorContext.White, _colorContext.Black);
        }

        [Given(@"stripePattern ← StripePattern\(white, black\)")]
        public void GivenStripePatternStripePatternWhiteBlack()
        {
            _patternsContext.StripePattern = new StripePattern(_colorContext.White, _colorContext.Black);
        }


        [Given(@"pattern\.Transform ← scaling\((.*), (.*), (.*)\)")]
        public void Given_Transform_Of_Pattern_Is_scaling(double x, double y, double z)
        {
            _patternsContext.Pattern.Transform = new Transform()
                .Scaling(x, y, z);
        }

        [Given(@"pattern\.Transform ← translation\((.*), (.*), (.*)\)")]
        public void Given_Transform_Of_Pattern_Is_translation(double x, double y, double z)
        {
            _patternsContext.Pattern.Transform = new Transform()
                .Translation(x, y, z);
        }

        [Given(@"pattern ← TestPattern\(\)")]
        public void GivenPatternTestPattern()
        {
            _patternsContext.Pattern = new TestPattern();
        }

        [Given(@"pattern ← GradientPattern\(white, black\)")]
        public void GivenPatternGradientPatternWhiteBlack()
        {
            _patternsContext.Pattern = new GradientPattern(_colorContext.White, _colorContext.Black);
        }
        
        [Given(@"pattern ← RingPattern\(white, black\)")]
        public void Given_pattern_Is_RingPattern()
        {
            _patternsContext.Pattern = new RingPattern(_colorContext.White, _colorContext.Black);
        }

        [Given(@"pattern ← CheckersPattern\(white, black\)")]
        public void Given_pattern_Is_CheckersPattern()
        {
            _patternsContext.Pattern = new CheckersPattern(_colorContext.White, _colorContext.Black);
        }


        [When(@"color ← pattern\.PatternAtShape\(sphere, Point\((.*), (.*), (.*)\)\)")]
        public void When_color_Is_PatternAtShape_Of_pattern(double x, double y, double z)
        {
            _colorContext.Color = _patternsContext.Pattern.PatternAtShape(_sphereContext.Sphere, new RtPoint(x, y, z));
        }

        [Then(@"pattern\.ColorA = white")]
        public void Then_ColorA_Of_Pattern_Should_Equal_white()
        {
            Assert.Equal(_colorContext.White, _patternsContext.StripePattern.ColorA);
        }

        [Then(@"pattern\.ColorB = black")]
        public void Then_ColorB_Of_Pattern_Should_Equal_black()
        {
            Assert.Equal(_colorContext.Black, _patternsContext.StripePattern.ColorB);
        }

        [Then(@"pattern\.PatternAt\(Point\((.*), (.*), (.*)\)\) = white")]
        public void Then_PatternAt_Of_pattern_Should_Equal_white(double x, double y, double z)
        {
            RtColor actualColor = _patternsContext.Pattern.PatternAt(new RtPoint(x, y, z));

            Assert.Equal(_colorContext.White, actualColor);
        }

        [Then(@"pattern\.PatternAt\(Point\((.*), (.*), (.*)\)\) = color\((.*), (.*), (.*)\)")]
        public void Then_PatternAt_Of_pattern_Should_Be_Color(double x, double y, double z, double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);
            var actualColor = _patternsContext.Pattern.PatternAt(new RtPoint(x, y, z));

            Assert.Equal(expectedColor, actualColor);
        }


        [Then(@"pattern\.PatternAt\(Point\((.*), (.*), (.*)\)\) = black")]
        public void Then_PatternAt_Of_pattern_Should_Equal_black(double x, double y, double z)
        {
            RtColor actualColor = _patternsContext.Pattern.PatternAt(new RtPoint(x, y, z));

            Assert.Equal(_colorContext.Black, actualColor);
        }

        [Then(@"pattern\.Transform = identityMatrix")]
        public void Then_Transform_Of_Pattern_Should_Equal_identityMatrix()
        {
            var expectedMatrix = RtMatrix.Identity;

            Assert.Equal(expectedMatrix, _patternsContext.Pattern.Transform.Matrix);
        }

        [When(@"pattern\.Transform ← translation\((.*), (.*), (.*)\)")]
        public void When_Transform_Of_Pattern_Is_Translation(double x, double y, double z)
        {
            _patternsContext.Pattern.Transform = new Transform().Translation(x, y, z);
        }

        [Then(@"pattern\.Transform = translation\((.*), (.*), (.*)\)")]
        public void Then_Transform_Of_Pattern_Should_Equal_Translation(double x, double y, double z)
        {
            var expectedTransform = new Transform().Translation(x, y, z);

            Assert.Equal(expectedTransform, _patternsContext.Pattern.Transform);
        }



    }
}
