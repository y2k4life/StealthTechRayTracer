//-----------------------------------------------------------------------
// <copyright file="WorldSteps.cs" company="StealthTech">
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
    public class WorldSteps
    {
        readonly WorldContext _worldContext;
        readonly MaterialsContext _materialsContext;
        readonly SphereContext _sphereContext;
        readonly RayContext _rayContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly ColorContext _colorContext;
        readonly TuplesContext _tuplesContext;

        public WorldSteps(WorldContext worldContext,
            SphereContext sphereContext,
            MaterialsContext materialsContext,
            RayContext rayContext,
            IntersectionsContext intersectionsContext,
            ColorContext colorContext,
            TuplesContext tuplesContext)

        {
            _tuplesContext = tuplesContext;
            _colorContext = colorContext;
            _intersectionsContext = intersectionsContext;
            _rayContext = rayContext;
            _sphereContext = sphereContext;
            _materialsContext = materialsContext;
            _worldContext = worldContext;
        }

        [Given(@"w ← world\(\)")]
        public void Given_w_Is_A_World()
        {
            _worldContext.World = new World();
        }

        [Then(@"w contains no objects")]
        public void Then_w_Contains_No_Objects()
        {
            var expectedShapeCount = 0;
            var actualShapeCount = _worldContext.World.Shapes.Count;

            Assert.Equal(expectedShapeCount, actualShapeCount);
        }

        [Then(@"w has no light source")]
        public void ThenWHasNoLightSource()
        {
            var expectedLightCount = 0;
            var actualLightCount = _worldContext.World.Lights.Count;

            Assert.Equal(expectedLightCount, actualLightCount);
        }

        [When(@"w ← default_world\(\)")]
        public void When_w_Is_Default_World()
        {
            _worldContext.World = World.DefaultWorld();
        }

        [Given(@"w ← default_world\(\)")]
        public void Given_w_Is_Default_World()
        {
            _worldContext.World = World.DefaultWorld();
        }

        [Then(@"w\.light = light")]
        public void Then_w_Light_Equals_Light()
        {
            var expectedLight = _materialsContext.Light;

            var actualLight = _worldContext.World.Lights[0];

            Assert.Equal(expectedLight, actualLight);
        }

        [Then(@"w contains s1")]
        public void Then_w_Contains_s1()
        {
            var expectedSphere = _sphereContext.Sphere1;

            var actualSphere = _worldContext.World.Shapes[0];

            Assert.Equal(expectedSphere, actualSphere);
        }

        [Then(@"w contains s2")]
        public void Then_w_Contains_s2()
        {
            var expectedSphere = _sphereContext.Sphere2;

            var actualSphere = _worldContext.World.Shapes[1];

            Assert.Equal(expectedSphere, actualSphere);
        }

        [Given(@"s ← the first object in w")]
        public void Given_s_Is_The_First_Shape_In_w()
        {
            _sphereContext.Sphere = _worldContext.World.Shapes[0];
        }

        [When(@"c ← shade_hit\(w, comps\)")]
        public void When_c_Shade_Hit_Is_Comps()
        {
            _colorContext.Color1 = _worldContext.World.ShadeHit(_intersectionsContext.Computations);
        }

        [Then(@"c = color\((.*), (.*), (.*)\)")]
        public void Then_c_Color(double red, double green, double blue)
        {
            var expectedColor = new RtColor(red, green, blue);

            var actualColor = _colorContext.Color1;

            Assert.Equal(expectedColor, actualColor);
        }

        [Given(@"w\.light ← point_light\(point\((.*), (.*), (.*)\), color\((.*), (.*), (.*)\)\)")]
        public void Given_w_Light_Is_Point_Light_With_Point_Color(double x, double y, double z, double red, double green, double blue)
        {
            _worldContext.World.Lights.Clear();
            _worldContext.World.Lights.Add(new PointLight(new RtPoint(x, y, z), new RtColor(red, green, blue)));
        }

        [Given(@"s ← the second object in w")]
        public void Given_s_Is_The_Second_Shape_In_w()
        {
            _sphereContext.Sphere = _worldContext.World.Shapes[1];
        }

        [When(@"c ← color_at\(w, r\)")]
        public void When_c_Is_Color_At_r()
        {
            _colorContext.Color1 = _worldContext.World.ColorAt(_rayContext.Ray);
        }


        [Given(@"outer ← the first object in w")]
        public void Given_outer_Is_The_First_Object_In_w()
        {
            _worldContext.Outer = _worldContext.World.Shapes[0];
        }

        [Given(@"outer\.material\.ambient ← (.*)")]
        public void Given_outer_Material_Is_Ambient(double ambient)
        {
            _worldContext.Outer.Material.Ambient = ambient;
        }

        [Given(@"inner ← the second object in w")]
        public void Given_inner_Is_The_Second_Object_In_w()
        {
            _worldContext.Inner = _worldContext.World.Shapes[1];
        }

        [Given(@"inner\.material\.ambient ← (.*)")]
        public void GivenInner_Material_Ambient(double ambient)
        {
            _worldContext.Inner.Material.Ambient = ambient;
        }

        [Then(@"c = inner\.material\.color")]
        public void Then_c_Inner_Material_Color()
        {
            _colorContext.Color1 = _worldContext.Inner.Material.Color;
        }

        [Then(@"is_shadowed\(w, p\) is false")]
        public void Then_Is_Shadowed_Point_Is_False()
        {
            var actualResults = _worldContext.World.IsShadowed(_tuplesContext.Point, _worldContext.World.Lights[0]);

            Assert.False(actualResults);
        }

        [Then(@"is_shadowed\(w, p\) is true")]
        public void Then_Is_Shadowed_Point_Is_True()
        {
            var actualResults = _worldContext.World.IsShadowed(_tuplesContext.Point, _worldContext.World.Lights[0]);

            Assert.True(actualResults);
        }

        [Given(@"s is added to w")]
        public void Given_s_Is_Added_To_w()
        {
            _worldContext.World.Shapes.Add(_sphereContext.Sphere);
        }

        [Given(@"s2 is added to w")]
        public void Given_s2_Is_Added_To_w()
        {
            _worldContext.World.Shapes.Add(_sphereContext.Sphere2);
        }

    }
}
