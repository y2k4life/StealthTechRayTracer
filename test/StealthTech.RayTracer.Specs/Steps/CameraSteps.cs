//-----------------------------------------------------------------------
// <copyright file="CameraSteps.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class CameraSteps
    {
        readonly CameraContext _cameraContext;
        readonly PointsContext _pointsContext;
        readonly TransformationsContext _transformationContext;
        readonly VectorsContext _vectorsContext;
        readonly WorldContext _worldContext;
        readonly RayContext _rayContext;

        public CameraSteps(CameraContext cameraContext,
            TransformationsContext transformationContext,
            WorldContext worldContext,
            PointsContext pointsContext,
            VectorsContext vectorsContext,
            RayContext rayContext)
        {
            _rayContext = rayContext;
            _vectorsContext = vectorsContext;
            _pointsContext = pointsContext;
            _worldContext = worldContext;
            _transformationContext = transformationContext;
            _cameraContext = cameraContext;
        }

        [Given(@"camera ← Camera\((.*), (.*), π/2\)")]
        public void Given_camera_Is_Camera(int horizontalSize, int verticalSize)
        {
            _cameraContext.Camera = new Camera(horizontalSize, verticalSize, Math.PI / 2);
        }

        [Given(@"camera\.Transform ← ViewTransform\(from, to, up\)")]
        public void Given_Transform_Of_camera_Is_ViewTransform()
        {
            _cameraContext.Camera.ViewTransform = new ViewTransform(
                _pointsContext.From,
                _pointsContext.To,
                _vectorsContext.Up);
        }

        [Given(@"fieldOfView ← π/2")]
        public void Given_fieldOfView_Is()
        {
            _cameraContext.FieldOfView = Math.PI / 2;
        }

        [Given(@"horizontalSize ← (.*)")]
        public void Given_horizontalSize_Is(int hsize)
        {
            _cameraContext.HorizontalSize = hsize;
        }

        [Given(@"verticalSize ← (.*)")]
        public void Given_verticalSize_Is(int vsize)
        {
            _cameraContext.VerticalSize = vsize;
        }

        [When(@"camera ← Camera\(horizontalSize, verticalSize, fieldOfView\)")]
        public void When_camera_Is_A_Camera()
        {
            _cameraContext.Camera = new Camera(_cameraContext.HorizontalSize, 
                                        _cameraContext.VerticalSize, 
                                        _cameraContext.FieldOfView);
        }

        [When(@"camera\.Transform ← translation\((.*), (.*), (.*)\)\.rotation_y\(π/4\)")]
        public void When_Transform_Of_camera_Is_Translation_Then_Rotation_Y(double x, double y, double z)
        {
            _cameraContext.Camera.ViewTransform = new Transform()
                .Translation(x, y, z)
                .RotateY(Math.PI / 4);

        }

        [When(@"ray ← camera\.RayForPixel\((.*), (.*)\)")]
        public void When_ray_Is_RayForPixel_Of_Canvas_At_x_y(double x, double y)
        {
            _rayContext.Ray = _cameraContext.Camera.RayForPixel(x, y);
        }

        [When(@"image ← render\(c, w\)")]
        public void When_image_Is_Assigned_Camera_Render_Of_world()
        {
            _cameraContext.Image = _cameraContext.Camera.Render(_worldContext.World);
        }

        [Then(@"camera\.FieldOfView = π/2")]
        public void Then_FieldOfView_Of_camera_Should_Equal_PI_Divided_By_2()
        {
            var expectedFieldOfView = Math.PI / 2;

            var actualFieldOfView = _cameraContext.FieldOfView;

            AssertDouble.ApproximateEquals(expectedFieldOfView, actualFieldOfView);
        }

        [Then(@"camera\.HorizontalSize = (.*)")]
        public void Then_HorizontalSize_Of_camera_Should_Equal(int expectedHorizontalSize)
        {
            Assert.Equal(expectedHorizontalSize, _cameraContext.Camera.HorizontalSize);
        }

        [Then(@"camera\.Transform = identityMatrix")]
        public void Then_Transform_Of_camera_Should_Equal_identityMatrix()
        {
            Assert.True(_cameraContext.Camera.ViewTransform.Equals(RtMatrix.Identity));
        }

        [Then(@"camera\.VerticalSize = (.*)")]
        public void Then_VerticalSize_Of_Camera_Should_Equal(int expectedVerticalSize)
        {
            Assert.Equal(expectedVerticalSize, _cameraContext.Camera.VerticalSize);
        }

        [Then(@"pixel_at\(image, (.*), (.*)\) = Color\((.*), (.*), (.*)\)")]
        public void Then_pixel_at_Should_Equal_Color(int x, int y, double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actaulColor = _cameraContext.Image[x, y];

            Assert.Equal(expectedColor, actaulColor);
        }

        [Then(@"camera\.PixelSize = (.*)")]
        public void Then_Pixel_Size_Of_camera_Should_Equal(double expectedPixelSize)
        {
            var actualPixelSize = _cameraContext.Camera.PixelSize;

            AssertDouble.ApproximateEquals(expectedPixelSize, actualPixelSize);
        }
    }
}
