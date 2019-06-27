//-----------------------------------------------------------------------
// <copyright file="CameraSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs
{
    [Binding]
    public class CameraSteps
    {
        readonly CameraContext _cameraContext;
        readonly TransformationContext _transformationContext;
        readonly WorldContext _worldContext;

        public CameraSteps(CameraContext cameraContext, TransformationContext transformationContext, WorldContext worldContext)
        {
            _worldContext = worldContext;
            _transformationContext = transformationContext;
            _cameraContext = cameraContext;
        }

        [Given(@"hsize ← (.*)")]
        public void Given_hsize_Is(int hsize)
        {
            _cameraContext.HorizontalSize = hsize;
        }

        [Given(@"vsize ← (.*)")]
        public void Given_vsize_Is(int vsize)
        {
            _cameraContext.VerticalSize = vsize;
        }

        [Given(@"field_of_view ← π/2")]
        public void Given_fieldOfView_Is()
        {
            _cameraContext.FieldOfView = Math.PI / 2;
        }

        [When(@"c ← camera\(hsize, vsize, field_of_view\)")]
        public void When_c_Is_Camera_With_hsize_vsize_fieldOfView()
        {
            _cameraContext.Camera = new Camera(_cameraContext.HorizontalSize, _cameraContext.VerticalSize, _cameraContext.FieldOfView);
        }

        [Then(@"c\.hsize = (.*)")]
        public void Then_c_HorizontalSize(int expectedHorizontalSize)
        {
            var actualHorizontalSize = _cameraContext.Camera.HorizontalSize;

            Assert.Equal(expectedHorizontalSize, actualHorizontalSize);
        }

        [Then(@"c\.vsize = (.*)")]
        public void Then_c_VerticalSize_Equals(int expectedVerticalSize)
        {
            var actualVerticalSize = _cameraContext.Camera.VerticalSize;

            Assert.Equal(expectedVerticalSize, actualVerticalSize);
        }

        [Then(@"c\.field_of_view = π/2")]
        public void Then_c_Field_Of_View_Equals_PI_Divided_By_2()
        {
            var expectedFieldOfView = Math.PI / 2;

            var actualFieldOfView = _cameraContext.FieldOfView;

            AssertDouble.ApproximateEquals(expectedFieldOfView, actualFieldOfView);
        }

        [Then(@"c\.transform = identity_matrix")]
        public void Then_c_Transform_Equals_Identity_Matrix()
        {
            var expectedTransform = new RtMatrix(4, 4).Identity();

            var actualTransform = _cameraContext.Camera.ViewTransform.Matrix;

            Assert.Equal(expectedTransform, actualTransform);
        }

        [Given(@"c ← camera\((.*), (.*), π/2\)")]
        public void Given_c_Is_Camera_With(int horizontalSize, int verticalSize)
        {
            _cameraContext.Camera = new Camera(horizontalSize, verticalSize, Math.PI / 2);
        }

        [Then(@"c\.pixel_size = (.*)")]
        public void ThenC_Pixel_Size(double expectedPixelSize)
        {
            var actualPixelSize = _cameraContext.Camera.PixelSize;

            AssertDouble.ApproximateEquals(expectedPixelSize, actualPixelSize);
        }

        [When(@"c\.transform ← rotation_y\(π/4\) \* translation\((.*), (.*), (.*)\)")]
        public void When_c_Transform_Is_Rotation_PI_Divided_By_Four_And_Translation(double x, double y, double z)
        {
            _cameraContext.Camera.ViewTransform = new Transform()
                .Translation(x, y, z)
                .RotateY(Math.PI / 4);

        }

        [Given(@"c\.transform ← view_transform\(from, to, up\)")]
        public void Given_c_TransformView_Is_Transform_From_To_Up()
        {
            _cameraContext.Camera.ViewTransform = new ViewTransform(
                _transformationContext.From,
                _transformationContext.To,
                _transformationContext.Up);
        }

        [When(@"image ← render\(c, w\)")]
        public void When_image_Render_w()
        {
            _cameraContext.Image = _cameraContext.Camera.Render(_worldContext.World);
        }

        [Then(@"pixel_at\(image, (.*), (.*)\) = color\((.*), (.*), (.*)\)")]
        public void Then_pixel_at_Image_Equals_Color(int x, int y, double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actaulColor = _cameraContext.Image[x, y];

            Assert.Equal(expectedColor, actaulColor);
        }

    }
}
