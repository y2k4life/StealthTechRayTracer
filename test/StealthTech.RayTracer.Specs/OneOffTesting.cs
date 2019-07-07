//-----------------------------------------------------------------------
// <copyright file="OneOffTesting.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;
using Xunit;

namespace StealthTech.RayTracer.Specs
{
    public class OneOffTesting
    {
        [Fact]
        public void TestSomething()
        {
            var world = World.DefaultWorld();
            var A = world.Shapes[0];
            A.Material.Pattern = new TestPattern();
            A.Material.Ambient = 1.0;

            var B = world.Shapes[1];
            B.Material.Transparency = 1.0;
            B.Material.RefractiveIndex = 1.5;

            var ray = new Ray(new RtPoint(0, 0, 0.1), new RtVector(0, 1, 0));
            var intersections = new IntersectionList();
            intersections.Add(new Intersection(-0.9899, A));
            intersections.Add(new Intersection(-0.4899, B));
            intersections.Add(new Intersection(0.4899, B));
            intersections.Add(new Intersection(0.9899, A));
            var computations = intersections[2].PrepareComputations(ray, intersections);
            var color = world.RefractedColor(computations, 5);

            Assert.Equal(new RtColor(0, 0.99888, 0.04725), color);
        }
    }
}
