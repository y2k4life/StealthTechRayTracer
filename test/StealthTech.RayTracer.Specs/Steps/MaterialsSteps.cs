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
        readonly ComputationsContext _computationsContext;

        public MaterialsSteps(MaterialsContext materialsContext, 
            PointsContext pointsContext, 
            VectorsContext vectorsContext,
            LightsContext lightsContext,
            ColorsContext colorContext,
            ComputationsContext computationsContext)
        {
            _computationsContext = computationsContext;
            _colorsContext = colorContext;
            _lightsContext = lightsContext;
            _vectorsContext = vectorsContext;
            _pointsContext = pointsContext;
            _materialsContext = materialsContext;
        }

        [Given(@"material\.Ambient ← (.*)")]
        public void Given_Ambient_Of_material(float ambient)
        {
            _materialsContext.Material.Ambient = ambient;
        }

        [Given(@"material\.Diffuse ← (.*)")]
        public void Given_Diffuse_Of_material(float diffuse)
        {
            _materialsContext.Material.Diffuse = diffuse;
        }

        [Given(@"material\.Specular ← (.*)")]
        public void Given_Specular_Of_material(float specular)
        {
            _materialsContext.Material.Specular = specular;
        }

        [Given(@"material ← Material\(\)")]
        public void Given_material_Is_Material()
        {
            _materialsContext.Material = new Material();
        }

        [Given(@"material\.Color ← Color\((.*), (.*), (.*)\)")]
        public void Given_Color_Of_Material_Of_sphere_Is(float red, float green, float blue)
        {
            _materialsContext.Material.Color = new RtColor(red, green, blue);
        }

        [Given(@"inShadow ← true")]
        public void Given_inShadow_Is_True()
        {
            _materialsContext.Intensity = 0.0;
        }

        [Given(@"material\.Pattern ← StripePattern\(color\((.*), (.*), (.*)\), color\((.*), (.*), (.*)\)\)")]
        public void Given_Pattern_Of_material_Is_StripePattern(float colorARed, 
            float colorAGreen, float colorABlue, float colorBRed, float colorBGreen, float colorBBlue)
        {
            _materialsContext.Material.Pattern = new StripePattern(
                new RtColor(colorARed, colorAGreen, colorABlue),
                new RtColor(colorBRed, colorBGreen, colorBBlue));
        }

        [Then(@"material\.Transparency = (.*)")]
        public void Then_Transparency_Of_Material_Should_Equal(float expectedTransparency)
        {
            Assert.Equal(expectedTransparency, _materialsContext.Material.Transparency);
        }

        [Then(@"material\.RefractiveIndex = (.*)")]
        public void Then_RefractiveIndex_Of_Material_Should_Equal(float expectedRefractiveIndex)
        {
            Assert.Equal(expectedRefractiveIndex, _materialsContext.Material.RefractiveIndex);
        }


        [When(@"result ← lighting\(m, light, position, eyeVector, normalVector, inShadow\)")]
        public void When_Result_Equals_Lighting_With_Light_Position_EyeVector_NormalVector_InShadow()
        {
            _materialsContext.Results = _materialsContext.Material.Lighting(
                _computationsContext.Computations,
                _lightsContext.Light,
                _materialsContext.Intensity);
        }

        [When(@"color1 ← lighting\(m, light, Point\((.*), (.*), (.*)\), eyeVector, normalVector, false\)")]
        public void When_color1_Equals_Lighting_With_Light_Position_EyeVector_NormalVector_InShadow(float x, float y, float z)
        {
            _computationsContext.Computations.Position = new RtPoint(x, y, z);
            _colorsContext.Color1 = _materialsContext.Material.Lighting(
                _computationsContext.Computations,
                _lightsContext.Light,
                _materialsContext.Intensity);
        }

        [When(@"color2 ← lighting\(m, light, Point\((.*), (.*), (.*)\), eyeVector, normalVector, false\)")]
        public void When_color2_Equals_Lighting_With_Light_Position_EyeVector_NormalVector_InShadow(float x, float y, float z)
        {
            _computationsContext.Computations.Position = new RtPoint(x, y, z);
            _colorsContext.Color2 = _materialsContext.Material.Lighting(
                _computationsContext.Computations,
                _lightsContext.Light,
                _materialsContext.Intensity);
        }

        [When(@"result ← lighting\(m, light, position, eyeVector, normalVector\)")]
        public void When_Result_Lighting_Light_Position_EyeV_NormalV()
        {
            _materialsContext.Results = _materialsContext.Material.Lighting(
                _computationsContext.Computations,
                _lightsContext.Light,
                1.0);
        }

        [When(@"result ← material\.lighting\(computations, light, (.*)\)")]
        public void WhenResultSphere_Material_LightingWorld_LightPointEyeVectorNormalVector(float intensity)
        {
            _materialsContext.Results = _materialsContext.Material.Lighting(
                _computationsContext.Computations, 
                _lightsContext.Light,
                intensity);
        }

        [Then(@"material\.Ambient = (.*)")]
        public void Then_Ambient_Of_material_Should_Equal(float expectedAmbient)
        {
            Assert.Equal(expectedAmbient, _materialsContext.Material.Ambient);
        }

        [Then(@"material\.Color = Color\((.*), (.*), (.*)\)")]
        public void Then_Color_Of_material_Should_Equal_Color(float red, float green, float blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            Assert.Equal(expectedColor, _materialsContext.Material.Color);
        }

        [Then(@"material\.Diffuse = (.*)")]
        public void Then_Diffuse_Of_Material_Should_Equal(float expectedDiffuse)
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
        public void Then_Shininess_Of_Material_Should_Equal(float expectedShininess)
        {
            Assert.Equal(expectedShininess, _materialsContext.Material.Shininess);
        }

        [Then(@"material\.Specular = (.*)")]
        public void Then_Specular_Of_material_Should_Equal(float expectedSpecular)
        {
            Assert.Equal(expectedSpecular, _materialsContext.Material.Specular);
        }

        [Then(@"result = Color\((.*), (.*), (.*)\)")]
        public void Then_result_Should_Equal_Color(float red, float green, float blue)
        {
            var expectedColor = new RtColor(red, green, blue);
            Assert.Equal(expectedColor, _materialsContext.Results);
        }

        [Then(@"material\.Reflective = (.*)")]
        public void Then_Reflective_Of_material_Should_Equal(float expectedReflective)
        {
            Assert.Equal(expectedReflective, _materialsContext.Material.Reflective);
        }


    }
}
