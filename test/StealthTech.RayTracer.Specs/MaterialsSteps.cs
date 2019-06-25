//-----------------------------------------------------------------------
// <copyright file="MaterialsSteps.cs" company="StealthTech">
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
    public class MaterialsSteps
    {
        readonly MaterialsContext _materialsContext;
        readonly TuplesContext _tuplesContext;

        public MaterialsSteps(MaterialsContext materialsContext, TuplesContext tuplesContext)
        {
            _tuplesContext = tuplesContext;
            _materialsContext = materialsContext;
        }

        [Given(@"m ← material\(\)")]
        public void Given_m_Material()
        {
            _materialsContext.Material = new Material();
        }

        [Then(@"m\.color = color\((.*), (.*), (.*)\)")]
        public void Then_m_Color_Equals_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            Assert.Equal(expectedColor, _materialsContext.Material.Color);
        }

        [Then(@"m\.ambient = (.*)")]
        public void Then_m_Ambient_Equals(double expectedAmbient)
        {
            Assert.Equal(expectedAmbient, _materialsContext.Material.Ambient);
        }

        [Then(@"m\.diffuse = (.*)")]
        public void Then_m_Diffuse_Equals(double expectedDiffuse)
        {
            Assert.Equal(expectedDiffuse, _materialsContext.Material.Diffuse);
        }

        [Then(@"m\.specular = (.*)")]
        public void Then_m_Specular_Equals(double expectedSpecular)
        {
            Assert.Equal(expectedSpecular, _materialsContext.Material.Specular);
        }

        [Then(@"m\.shininess = (.*)")]
        public void Then_m_Shininess_Equals(double expectedShininess)
        {
            Assert.Equal(expectedShininess, _materialsContext.Material.Shininess);
        }

        [Given(@"eyeVector ← vector\((.*), (.*), (.*)\)")]
        public void Given_EyeV_Vector(string x, string y, string z)
        {
            
            _materialsContext.EyeVector = RtTuple.Vector(ConvertCoordinate(x), ConvertCoordinate(y), ConvertCoordinate(z));
        }

        [Given(@"normalVector ← vector\((.*), (.*), (.*)\)")]
        public void Given_NormalV_Is_Vector(double x, double y, double z)
        {
            _materialsContext.NormalVector = RtTuple.Vector(x, y, z);
        }

        [Given(@"light ← point_light\(point\((.*), (.*), (.*)\), color\((.*), (.*), (.*)\)\)")]
        public void Given_Light_Is_A_Point_Light_With_Point_Color(double x, double y, double z, double red, double green, double blue)
        {
            _materialsContext.Light = new PointLight(RtTuple.Point(x, y, z), new RtColor(red, green, blue));
        }

        [When(@"result ← lighting\(m, light, position, eyeVector, normalVector\)")]
        public void When_Result_Lighting_Light_Position_EyeV_NormalV()
        {
            _materialsContext.Results = _materialsContext.Material.Lighting(_materialsContext.Light,
                _tuplesContext.Position,
                _materialsContext.EyeVector,
                _materialsContext.NormalVector);
        }

        [Then(@"result = color\((.*), (.*), (.*)\)")]
        public void Then_ResultColor(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);
            Assert.Equal(expectedColor, _materialsContext.Results);
        }


        private double ConvertCoordinate(string coordiante)
        {
            if (coordiante.Length == 5)
            {
                return (Math.Sqrt(2) / 2) * -1;
            }
            else if (coordiante.Length == 4)
            {
                return (Math.Sqrt(2) / 2);
            }

            return Convert.ToInt32(coordiante);
        }
    }
}
