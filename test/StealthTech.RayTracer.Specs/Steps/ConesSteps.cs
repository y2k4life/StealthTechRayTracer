using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using System;
using TechTalk.SpecFlow;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class ConesSteps
    {
        readonly ConesContext _conesContext;
        readonly IntersectionsContext _intersectionsContext;
        readonly RayContext _rayContext;
        readonly VectorsContext _vectorsContext;

        public ConesSteps(ConesContext conesContext, 
            IntersectionsContext intersectionsContext, 
            RayContext rayContext,
            VectorsContext vectorsContext)
        {
            _vectorsContext = vectorsContext;
            _rayContext = rayContext;
            _intersectionsContext = intersectionsContext;
            _conesContext = conesContext;
        }

        [Given(@"cone ← Cone\(\)")]
        public void Given_cone_Is_Cone()
        {
            _conesContext.Cone = new Cone();
        }

        [Given(@"cone\.Minimum ← (.*)")]
        public void Given_Minimum_Of_Cone_Is(double minimum)
        {
            _conesContext.Cone.Minimum = minimum;
        }

        [Given(@"cone\.Maximum ← (.*)")]
        public void Given_Maximum_Of_Cone_Is(double maximum)
        {
            _conesContext.Cone.Maximum = maximum;
        }

        [Given(@"cone\.IsClosed ← true")]
        public void Given_IsClosed_Of_Cone_Is_True()
        {
            _conesContext.Cone.IsClosed = true;
        }

        [When(@"intersections ← cone\.LocalIntersect\(ray\)")]
        public void When_intersections_Is_LocalIntersect_Of_Cone()
        {
            _intersectionsContext.Intersections = _conesContext.Cone.LocalIntersect(_rayContext.Ray);
        }

        [When(@"normalVector ← cone\.LocalNormalAt\(Point\((.*), (.*), (.*)\)\)")]
        public void When_normalVector_Is_LocalNormalAt_Cone(double x, double y, double z)
        {
            _vectorsContext.Normal = _conesContext.Cone.LocalNormalAt(new RtPoint(x, y, z), null);
        }

    }
}
