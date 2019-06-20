using Xunit;
using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs
{
    public class AssertDouble
    {
        public static void ApproximateEquals(double exprected, double actual)
        {
            var resutls = actual.ApproximateEquals(exprected);
            Assert.True(resutls);
        }
    }
}
