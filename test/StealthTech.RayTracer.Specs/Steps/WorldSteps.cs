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
        readonly ColorsContext _colorContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly LightsContext _lightsContext;
        readonly MaterialsContext _materialsContext;
        readonly PointsContext _pointsContext;
        readonly RayContext _rayContext;
        readonly SphereContext _sphereContext;
        readonly WorldContext _worldContext;
        readonly PlanesContext _planesContext;
        readonly ComputationsContext _computationsContext;

        public WorldSteps(WorldContext worldContext,
            SphereContext sphereContext,
            MaterialsContext materialsContext,
            RayContext rayContext,
            IntersectionsContext intersectionsContext,
            ColorsContext colorContext,
            PointsContext pointsContext,
            LightsContext lightsContext,
            PlanesContext planesContext,
            ComputationsContext computationsContext)
        {
            _computationsContext = computationsContext;
            _planesContext = planesContext;
            _lightsContext = lightsContext;
            _pointsContext = pointsContext;
            _colorContext = colorContext;
            _intersectionsContext = intersectionsContext;
            _rayContext = rayContext;
            _sphereContext = sphereContext;
            _materialsContext = materialsContext;
            _worldContext = worldContext;
        }

        [Given(@"outerShape\.Material\.Ambient ← (.*)")]
        public void Given_Ambient_Material_Of_outerShape_Is(float ambient)
        {
            _worldContext.OuterShape.Material.Ambient = ambient;
        }

        [Given(@"innerShape ← the second shape in world")]
        public void Given_innerShape_Is_The_Second_Object_In_world()
        {
            _worldContext.Inner = (Sphere)_worldContext.World.Shapes[1];
        }

        [Given(@"outerShape ← the first shape in world")]
        public void Given_outerShape_Is_The_First_Object_In_world()
        {
            _worldContext.OuterShape = (Sphere)_worldContext.World.Shapes[0];
        }

        [Given(@"sphere is added to world")]
        public void Given_s_Is_Added_To_w()
        {
            _worldContext.World.Shapes.Add(_sphereContext.Sphere);
        }

        [Given(@"sphere ← the second shape in world")]
        public void Given_s_Is_The_Second_Shape_In_w()
        {
            _sphereContext.Sphere = (Sphere)_worldContext.World.Shapes[1];
        }

        [Given(@"sphere2 is added to world")]
        public void Given_sphere2_Is_Added_To_w()
        {
            _worldContext.World.Shapes.Add(_sphereContext.Sphere2);
        }

        [Given(@"sphere ← the first shape in world")]
        public void Given_sphere_Is_The_First_Shape_In_world()
        {
            _sphereContext.Sphere = (Sphere)_worldContext.World.Shapes[0];
        }

        [Given(@"sphere1 ← the first shape in world")]
        public void Given_sphere1_Is_The_First_Shape_In_world()
        {
            _sphereContext.Spheres[1] = (Sphere)_worldContext.World.Shapes[0];
        }

        [Given(@"sphere2 ← the second shape in world")]
        public void Given_sphere2_Is_The_First_Shape_In_world()
        {
            _sphereContext.Spheres[2] = (Sphere)_worldContext.World.Shapes[1];
        }

        [Given(@"world\.Light ← PointLight\(Point\((.*), (.*), (.*)\), Color\((.*), (.*), (.*)\)\)")]
        public void Given_w_Light_Is_Point_Light_With_Point_Color(float x, float y, float z, float red, float green, float blue)
        {
            _worldContext.World.Lights.Clear();
            _worldContext.World.Lights.Add(new PointLight(new RtPoint(x, y, z), new RtColor(red, green, blue)));
        }

        [Given(@"world ← World\(\)")]
        public void Given_world_Is_A_World()
        {
            _worldContext.World = new World();
        }

        [Given(@"world ← default_world\(\)")]
        public void Given_world_Is_Default_World()
        {
            _worldContext.World = World.DefaultWorld();
        }

        [Given(@"inner\.material\.ambient ← (.*)")]
        public void GivenInner_Material_Ambient(float ambient)
        {
            _worldContext.Inner.Material.Ambient = ambient;
        }

        [Given(@"plane is added to world")]
        public void Given_plane_Is_Added_To_World()
        {
            _worldContext.World.Shapes.Add(_planesContext.Plane);
        }

        [Given(@"lowerPlane is added to world")]
        public void Given_lowerPlane_Is_Added_To_World()
        {
            _worldContext.World.Shapes.Add(_planesContext.lowerPlane);
        }

        [Given(@"upperPlane is added to world")]
        public void Given_upperPlane_Is_Added_To_World()
        {
            _worldContext.World.Shapes.Add(_planesContext.upperPlane);
        }

        [Given(@"floor is added to world")]
        public void Given_floor_Is_Added_To_world()
        {
            _worldContext.World.Shapes.Add(_planesContext.Floor);
        }

        [Given(@"light ← world\.Light")]
        public void Given_light_Is_Light_of_world()
        {
            _lightsContext.Light = _worldContext.World.Lights[0];
        }


        [When(@"color ← world\.RefractedColor\(computations, (.*)\)")]
        public void When_color_Is_The_Results_Of_RefractedColor_Of_World_Using_computations(int remaining)
        {
            _colorContext.Color = _worldContext.World.RefractedColor(_computationsContext.Computations, remaining);
        }

        [When(@"color ← world.ShadeHit\(computations, 5\)")]
        public void When_color_Is_Shade_Hit_Of_world_Using_computations()
        {
            _colorContext.Color = _worldContext.World.ShadeHit(_computationsContext.Computations, 4);
        }

        [When(@"color ← color_at\(w, r\)")]
        public void When_color_Is_Color_At()
        {
            _colorContext.Color = _worldContext.World.ColorAt(_rayContext.Ray, 4);
        }

        [When(@"world ← default_world\(\)")]
        public void When_world_Is_Default_World()
        {
            _worldContext.World = World.DefaultWorld();
        }

        [When(@"color ← world\.ReflectedColor\(computations\)")]
        public void When_color_Is_The_Results_Of_ReflectedColor_Of_World()
        {
            _colorContext.Color = _worldContext.World.ReflectedColor(_computationsContext.Computations, 4);
        }


        [When(@"color ← world\.ReflectedColor\(computations, (.*)\)")]
        public void When_color_Is_The_Results_Of_ReflectedColor_Of_World_With_computations_and_Depth_Of(int remaining)
        {
            _colorContext.Color = _worldContext.World.ReflectedColor(_computationsContext.Computations, remaining);
        }


        [Then(@"color = inner\.Material\.Color")]
        public void Then_color_Should_Equal_Color_Of_Material_Of_Inner()
        {
            _colorContext.Color1 = _worldContext.Inner.Material.Color;
        }

        [Then(@"is_shadowed\(w, light_position, point\) is (.*)")]
        public void Then_Is_Shadowed_Of_world_Should_Be(bool expectedResults)
        {
            var actualResults = _worldContext.World.IsShadowed(_pointsContext.LightPosition, _pointsContext.Point);

            Assert.Equal(expectedResults, actualResults);
        }

        [Then(@"world contains no shapes")]
        public void Then_w_Contains_No_Objects()
        {
            var expectedShapeCount = 0;
            var actualShapeCount = _worldContext.World.Shapes.Count;

            Assert.Equal(expectedShapeCount, actualShapeCount);
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

        [Then(@"world\.Light = light")]
        public void Then_w_Light_Equals_Light()
        {
            var expectedLight = _lightsContext.Light;

            var actualLight = _worldContext.World.Lights[0];

            Assert.Equal(expectedLight, actualLight);
        }

        [Then(@"world has no light source")]
        public void ThenWHasNoLightSource()
        {
            var expectedLightCount = 0;
            var actualLightCount = _worldContext.World.Lights.Count;

            Assert.Equal(expectedLightCount, actualLightCount);
        }

        [Then(@"world\.ColorAt\(ray\) should terminate successfully")]
        public void Then_ColorAt_ray_Of_World_Should_Terminate_Successfully()
        {
            _worldContext.World.ColorAt(_rayContext.Ray, 4);
        }

    }
}
