//-----------------------------------------------------------------------
// <copyright file="MaterialsSteps.cs" company="StealthTech">
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
    public class MaterialsSteps
    {
        readonly MaterialsContext _materialsContext;
        readonly PointsContext _pointsContext;
        readonly VectorsContext _vectorsContext;
        readonly LightsContext _lightsContext;
        readonly ColorsContext _colorsContext;

        public MaterialsSteps(MaterialsContext materialsContext, 
            PointsContext pointsContext, 
            VectorsContext vectorsContext,
            LightsContext lightsContext,
            ColorsContext colorContext)
        {
            _colorsContext = colorContext;
            _lightsContext = lightsContext;
            _vectorsContext = vectorsContext;
            _pointsContext = pointsContext;
            _materialsContext = materialsContext;
        }

        [Given(@"material\.Ambient ← (.*)")]
        public void Given_Ambient_Of_material(double ambient)
        {
            _materialsContext.Material.Ambient = ambient;
        }

        [Given(@"material\.Diffuse ← (.*)")]
        public void Given_Diffuse_Of_material(double diffuse)
        {
            _materialsContext.Material.Diffuse = diffuse;
        }

        [Given(@"material\.Specular ← (.*)")]
        public void Given_Specular_Of_material(double specular)
        {
            _materialsContext.Material.Specular = specular;
        }

        [Given(@"material ← Material\(\)")]
        public void Given_material_Is_Material()
        {
            _materialsContext.Material = new Material();
        }

        [Given(@"inShadow ← true")]
        public void GivenInShadowTrue()
        {
            _materialsContext.InShadow = true;
        }

        [Given(@"material\.Pattern ← StripePattern\(color\((.*), (.*), (.*)\), color\((.*), (.*), (.*)\)\)")]
        public void Given_Pattern_Of_material_Is_StripePattern(double colorARed, 
            double colorAGreen, double colorABlue, double colorBRed, double colorBGreen, double colorBBlue)
        {
            _materialsContext.Material.Pattern = new StripePattern(
                new RtColor(colorARed, colorAGreen, colorABlue),
                new RtColor(colorBRed, colorBGreen, colorBBlue));
        }

        [When(@"result ← lighting\(m, light, position, eyeVector, normalVector, inShadow\)")]
        public void When_Result_Equals_Lighting_With_Light_Position_EyeVector_NormalVector_InShadow()
        {
            _materialsContext.Results = _materialsContext.Material.Lighting(
                new Sphere(),
                _lightsContext.Light,
                _pointsContext.Position,
                _vectorsContext.EyeVector,
                _vectorsContext.NormalVector,
                _materialsContext.InShadow);
        }

        [When(@"color1 ← lighting\(m, light, Point\((.*), (.*), (.*)\), eyeVector, normalVector, false\)")]
        public void When_color1_Equals_Lighting_With_Light_Position_EyeVector_NormalVector_InShadow(double x, double y, double z)
        {
            _colorsContext.Color1 = _materialsContext.Material.Lighting(
                new Sphere(),
                _lightsContext.Light,
                new RtPoint(x, y, z),
                _vectorsContext.EyeVector,
                _vectorsContext.NormalVector,
                _materialsContext.InShadow);
        }

        [When(@"color2 ← lighting\(m, light, Point\((.*), (.*), (.*)\), eyeVector, normalVector, false\)")]
        public void When_color2_Equals_Lighting_With_Light_Position_EyeVector_NormalVector_InShadow(double x, double y, double z)
        {
            _colorsContext.Color2 = _materialsContext.Material.Lighting(
                new Sphere(),
                _lightsContext.Light,
                new RtPoint(x, y, z),
                _vectorsContext.EyeVector,
                _vectorsContext.NormalVector,
                _materialsContext.InShadow);
        }

        [When(@"result ← lighting\(m, light, position, eyeVector, normalVector\)")]
        public void When_Result_Lighting_Light_Position_EyeV_NormalV()
        {
            _materialsContext.Results = _materialsContext.Material.Lighting(
                new Sphere(),
                _lightsContext.Light,
                _pointsContext.Position,
                _vectorsContext.EyeVector,
                _vectorsContext.NormalVector,
                _materialsContext.InShadow);
        }

        [Then(@"material\.Ambient = (.*)")]
        public void Then_Ambient_Of_material_Should_Equal(double expectedAmbient)
        {
            Assert.Equal(expectedAmbient, _materialsContext.Material.Ambient);
        }

        [Then(@"material\.Color = Color\((.*), (.*), (.*)\)")]
        public void Then_Color_Of_material_Should_Equal_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            Assert.Equal(expectedColor, _materialsContext.Material.Color);
        }

        [Then(@"material\.Diffuse = (.*)")]
        public void Then_Diffuse_Of_Material_Should_Equal(double expectedDiffuse)
        {
            Assert.Equal(expectedDiffuse, _materialsContext.Material.Diffuse);
        }

        [Then(@"material = Material\(\)")]
        public void Then_material_Should_Equal_Material()
        {
            var expectedMaterial = new Material();

            var actualMaterial = _materialsContext.Material;

            Assert.Equal(expectedMaterial, actualMaterial);
        }

        [Then(@"material\.Shininess = (.*)")]
        public void Then_Shininess_Of_Material_Should_Equal(double expectedShininess)
        {
            Assert.Equal(expectedShininess, _materialsContext.Material.Shininess);
        }

        [Then(@"material\.Specular = (.*)")]
        public void Then_Specular_Of_material_Should_Equal(double expectedSpecular)
        {
            Assert.Equal(expectedSpecular, _materialsContext.Material.Specular);
        }

        [Then(@"result = Color\((.*), (.*), (.*)\)")]
        public void Then_result_Should_Equal_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);
            Assert.Equal(expectedColor, _materialsContext.Results);
        }


    }
}
