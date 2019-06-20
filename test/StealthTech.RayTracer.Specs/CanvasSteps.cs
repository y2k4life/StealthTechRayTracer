//-----------------------------------------------------------------------
// <copyright file="CanvasSteps.cs" company="StealthTech">
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
    public class CanvasSteps
    {
        private Canvas _canvas;
        private string _ppm;
        readonly ColorContext _colorContext;
        private RtColor _color1;

        public CanvasSteps(ColorContext colorContext)
        {
            _colorContext = colorContext;
        }

        [Given(@"c <- Canvas\((.*), (.*)\)")]
        public void Given_c_Canvas(int width, int height)
        {
            _canvas = new Canvas(width, height);
        }

        [When(@"write_pixel\(c, (.*), (.*), c1\)")]
        public void WhenWrite_PixelCC(int x, int y)
        {
            _canvas[x, y] = _colorContext.Color1;
        }

        [When(@"write_pixel\(c, (.*), (.*), c2\)")]
        public void When_Write_Pixel_c2(int x, int y)
        {
            _canvas[x, y] = _colorContext.Color2;
        }

        [When(@"write_pixel\(c, (.*), (.*), c3\)")]
        public void When_Write_Pixel_c3(int x, int y)
        {
            _canvas[x, y] = _colorContext.Color2;
        }

        [When(@"ppm <- canvas_to_ppm\(c\)")]
        public void WhenPpm_Canvas_To_PpmC()
        {
            _ppm = _canvas.GetPPMContent();
        }

        [Then(@"lines (.*)-(.*) of ppm are")]
        public void Then_Lines_Of_ppm_Are(int start, int end, string multilineText)
        {
            string[] lines = _ppm.Split("\r\n");
            string[] expectedLines = multilineText.Split("\r\n");
            for (int i = 0; i < end - start; i++)
            {
                Assert.Equal(expectedLines[i], lines[start - 1 + i]);
            }
        }

        [When(@"every pixel of c is set to Color\((.*), (.*), (.*)\)")]
        public void WhenEveryPixelOfCIsSetToColor(double red, double green, double blue)
        {
            for (int i = 0; i < _canvas.Width; i++)
            {
                for (int j = 0; j < _canvas.Height; j++)
                {
                    _canvas[i, j] = new RtColor(red, green, blue);
                }
            }
        }

        [Then(@"c\.Width = (.*)")]
        public void Then_c_Width_Equals(int expectedWidth)
        {
            Assert.Equal(expectedWidth, _canvas.Width);
        }

        [Then(@"c\.Height = (.*)")]
        public void Then_c_Height_Equals(int expectedHeight)
        {
            Assert.Equal(expectedHeight, _canvas.Height);
        }

        [Then(@"Every pixel of c is color\((.*), (.*), (.*)\)")]
        public void Then_Every_Pixel_Of_c_Is_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            for (int x = 0; x < _canvas.Width - 1; x++)
            {
                for (int y = 0; y < _canvas.Height - 1; y++)
                {
                    RtColor actualColor = _canvas[x, y];
                    Assert.Equal(expectedColor, actualColor);
                }
            }
        }

        [Given(@"red ← Color\((.*), (.*), (.*)\)")]
        public void Given_Red_Color(double red, double green, double blue)
        {
            _color1 = new RtColor(red, green, blue);
        }

        [When(@"write_pixel\(c, (.*), (.*), red\)")]
        public void When_Write__Pixel_Red(int x, int y)
        {
            _canvas[x, y] = _color1;
        }

        [Then(@"pixel_at\(c, (.*), (.*)\) = red")]
        public void Then_Pixel_At_Equals_Red(int x, int y)
        {
            var expectedColor = new RtColor(1, 0, 0);
            var actualColor = _canvas[x, y];

            Assert.Equal(expectedColor, actualColor);
        }

        [Then(@"ppm ends with a newline character")]
        public void ThenPpmEndsWithANewlineCharacter()
        {
            var last = _ppm.Substring(_ppm.Length - 2);

            Assert.Equal("\r\n", last);
        }

    }
}
