//-----------------------------------------------------------------------
// <copyright file="WorldSteps.cs" company="StealthTech">
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
    public class WorldSteps
    {
        readonly WorldContext _worldContext;
        readonly MaterialsContext _materialsContext;
        readonly SphereContext _sphereContext;
        readonly RayContext _rayContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly ColorsContext _colorContext;
        readonly PointsContext _pointsContext;
        readonly LightsContext _lightsContext;

        public WorldSteps(WorldContext worldContext,
            SphereContext sphereContext,
            MaterialsContext materialsContext,
            RayContext rayContext,
            IntersectionsContext intersectionsContext,
            ColorsContext colorContext,
            PointsContext pointsContext,
            LightsContext lightsContext)

        {
            _lightsContext = lightsContext;
            _pointsContext = pointsContext;
            _colorContext = colorContext;
            _intersectionsContext = intersectionsContext;
            _rayContext = rayContext;
            _sphereContext = sphereContext;
            _materialsContext = materialsContext;
            _worldContext = worldContext;
        }

        [Given(@"world ← World\(\)")]
        public void Given_world_Is_A_World()
        {
            _worldContext.World = new World();
        }

        [Then(@"world contains no shapes")]
        public void Then_w_Contains_No_Objects()
        {
            var expectedShapeCount = 0;
            var actualShapeCount = _worldContext.World.Shapes.Count;

            Assert.Equal(expectedShapeCount, actualShapeCount);
        }

        [Then(@"world has no light source")]
        public void ThenWHasNoLightSource()
        {
            var expectedLightCount = 0;
            var actualLightCount = _worldContext.World.Lights.Count;

            Assert.Equal(expectedLightCount, actualLightCount);
        }

        [When(@"world ← default_world\(\)")]
        public void When_world_Is_Default_World()
        {
            _worldContext.World = World.DefaultWorld();
        }

        [Given(@"world ← default_world\(\)")]
        public void Given_world_Is_Default_World()
        {
            _worldContext.World = World.DefaultWorld();
        }

        [Then(@"world\.Light = light")]
        public void Then_w_Light_Equals_Light()
        {
            var expectedLight = _lightsContext.Light;

            var actualLight = _worldContext.World.Lights[0];

            Assert.Equal(expectedLight, actualLight);
        }

        [Then(@"world contains sphere1")]
        public void Then_w_Contains_s1()
        {
            var expectedSphere = _sphereContext.Sphere1;

            var actualSphere = _worldContext.World.Shapes[0];

            Assert.Equal(expectedSphere, actualSphere);
        }

        [Then(@"world contains sphere2")]
        public void Then_w_Contains_s2()
        {
            var expectedSphere = _sphereContext.Sphere2;

            var actualSphere = _worldContext.World.Shapes[1];

            Assert.Equal(expectedSphere, actualSphere);
        }

        [Given(@"sphere ← the first shape in world")]
        public void Given_sphere_Is_The_First_Shape_In_world()
        {
            _sphereContext.Sphere = (Sphere)_worldContext.World.Shapes[0];
        }

        [When(@"color ← shade_hit\(w, computations\)")]
        public void When_color_Is_Shade_Hit_Of_computations()
        {
            _colorContext.Color = _worldContext.World.ShadeHit(_intersectionsContext.Computations);
        }

        [Given(@"world\.Light ← PointLight\(Point\((.*), (.*), (.*)\), Color\((.*), (.*), (.*)\)\)")]
        public void Given_w_Light_Is_Point_Light_With_Point_Color(double x, double y, double z, double red, double green, double blue)
        {
            _worldContext.World.Lights.Clear();
            _worldContext.World.Lights.Add(new PointLight(new RtPoint(x, y, z), new RtColor(red, green, blue)));
        }

        [Given(@"sphere ← the second shape in world")]
        public void Given_s_Is_The_Second_Shape_In_w()
        {
            _sphereContext.Sphere = (Sphere)_worldContext.World.Shapes[1];
        }

        [When(@"color ← color_at\(w, r\)")]
        public void When_color_Is_Color_At()
        {
            _colorContext.Color = _worldContext.World.ColorAt(_rayContext.Ray);
        }


        [Given(@"outerShape ← the first shape in world")]
        public void Given_outerShape_Is_The_First_Object_In_world()
        {
            _worldContext.OuterShape = (Sphere)_worldContext.World.Shapes[0];
        }

        [Given(@"outerShape\.Material\.Ambient ← (.*)")]
        public void Given_Ambient_Material_Of_outerShape_Is(double ambient)
        {
            _worldContext.OuterShape.Material.Ambient = ambient;
        }

        [Given(@"innerShape ← the second shape in world")]
        public void Given_innerShape_Is_The_Second_Object_In_world()
        {
            _worldContext.Inner = (Sphere)_worldContext.World.Shapes[1];
        }

        [Given(@"inner\.material\.ambient ← (.*)")]
        public void GivenInner_Material_Ambient(double ambient)
        {
            _worldContext.Inner.Material.Ambient = ambient;
        }

        [Then(@"color = inner\.Material\.Color")]
        public void Then_color_Should_Equal_Color_Of_Material_Of_Inner()
        {
            _colorContext.Color1 = _worldContext.Inner.Material.Color;
        }

        [Then(@"is_shadowed\(w, p\) is false")]
        public void Then_Is_Shadowed_Point_Is_False()
        {
            var actualResults = _worldContext.World.IsShadowed(_pointsContext.Point, _worldContext.World.Lights[0]);

            Assert.False(actualResults);
        }

        [Then(@"is_shadowed\(w, p\) is true")]
        public void Then_Is_Shadowed_Point_Is_True()
        {
            var actualResults = _worldContext.World.IsShadowed(_pointsContext.Point, _worldContext.World.Lights[0]);

            Assert.True(actualResults);
        }

        [Given(@"sphere is added to world")]
        public void Given_s_Is_Added_To_w()
        {
            _worldContext.World.Shapes.Add(_sphereContext.Sphere);
        }

        [Given(@"sphere2 is added to world")]
        public void Given_s2_Is_Added_To_w()
        {
            _worldContext.World.Shapes.Add(_sphereContext.Sphere2);
        }

    }
}
