//-----------------------------------------------------------------------
// <copyright file="CanvasSteps.cs" company="StealthTech">
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
    public class CanvasSteps
    {
        private Canvas _canvas;
        readonly ColorsContext _colorContext;
        private string _ppm;

        public CanvasSteps(ColorsContext colorContext)
        {
            _colorContext = colorContext;
        }

        [Given(@"canvas ← Canvas\((.*), (.*)\)")]
        public void Given_canvas_Is_A_Canvas_With_width_height(int width, int height)
        {
            _canvas = new Canvas(width, height);
        }

        [When(@"canvas\[(.*),(.*)\] ← red")]
        public void When_red_Is_Assigned_To_canvas_x_y(int x, int y)
        {
            _canvas[x, y] = _colorContext.Red;
        }

        [When(@"canvas\[(.*), (.*)\] ← color1")]
        public void When_color1_Is_Assigned_To_canvas_x_y(int x, int y)
        {
            _canvas[x, y] = _colorContext.Color1;
        }

        [When(@"canvas\[(.*), (.*)\] ← color2")]
        public void When_color2_Is_Assigned_To_canvas_x_y(int x, int y)
        {
            _canvas[x, y] = _colorContext.Color2;
        }

        [When(@"canvas\[(.*), (.*)\] ← color3")]
        public void When_color3_Is_Assigned_To_canvas_x_y(int x, int y)
        {
            _canvas[x, y] = _colorContext.Color3;
        }

        [When(@"every pixel of canvas is set to Color\((.*), (.*), (.*)\)")]
        public void When_Every_Pixel_Of_canvas_Is_Set_To_Color(double red, double green, double blue)
        {
            for (int i = 0; i < _canvas.Width; i++)
            {
                for (int j = 0; j < _canvas.Height; j++)
                {
                    _canvas[i, j] = new RtColor(red, green, blue);
                }
            }
        }

        [When(@"ppm ← canvas.PPMContent\(\)")]
        public void When_GetPPMContent_Of_canvas_Is_Assigned_To_ppm()
        {
            _ppm = _canvas.GetPPMContent();
        }

        [Then(@"canvas\.Height = (.*)")]
        public void Then_Height_Of_canvas_Should_Equal_height(int height)
        {
            Assert.Equal(height, _canvas.Height);
        }

        [Then(@"canvas\.Width = (.*)")]
        public void Then_Width_Of_canvas_Should_Equal_width(int width)
        {
            Assert.Equal(width, _canvas.Width);
        }

        [Then(@"every pixel of canvas is Color\((.*), (.*), (.*)\)")]
        public void Then_Every_Pixel_Of_canvas_Is_Color(double red, double green, double blue)
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

        [Then(@"lines (.*)-(.*) of ppm are")]
        public void Then_Lines_From_start_To_end_Of_ppm_Should_Equal(int start, int end, string multilineText)
        {
            string[] lines = _ppm.Split("\r\n");
            string[] expectedLines = multilineText.Split("\r\n");
            for (int i = 0; i < end - start; i++)
            {
                Assert.Equal(expectedLines[i], lines[start - 1 + i]);
            }
        }

        [Then(@"canvas\[(.*), (.*)\] = red")]
        public void Then_canvas_At_x_y_Should_Equal_Red(int x, int y)
        {
            var expectedColor = _colorContext.Red;
            var actualColor = _canvas[x, y];

            Assert.Equal(expectedColor, actualColor);
        }

        [Then(@"ppm ends with a newline character")]
        public void Then_ppm_Should_End_With_A_New_Line_Character()
        {
            var last = _ppm.Substring(_ppm.Length - 2);

            Assert.Equal("\r\n", last);
        }
    }
}
