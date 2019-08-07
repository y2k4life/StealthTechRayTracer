using StealthTech.RayTracer.Library;
using StealthTech.RayTracer.Specs.Contexts;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace StealthTech.RayTracer.Specs.Steps
{
    [Binding]
    public class ObjFileSteps
    {
        readonly ObjFileContext _objFileContext;

        public ObjFileSteps(ObjFileContext objFileContext)
        {
            _objFileContext = objFileContext;
        }

        [Given(@"objReader ← objReader\(\)")]
        public void Given_objReader_Is_ObjReader()
        {
            _objFileContext.ObjReader = new ObjReader();
        }

        [Given(@"file ← a file containing:")]
        public void Given_gibberish_Is_A_FileContaining(string multilineText)
        {
            _objFileContext.FileContent = multilineText;
        }

        [Given(@"fileName ← ""(.*)""")]
        public void Given_fileName(string fileName)
        {
            _objFileContext.FileName = fileName;
        }

        [When(@"objFile ← objReader\.ParseFile\(file\)")]
        public void When_objFile_Is_ParseFile_Of_objReader()
        {
            _objFileContext.ObjFile = _objFileContext.ObjReader.ParseFile(_objFileContext.FileName);
        }

        [When(@"objFile ← objReader\.Parse\(file\)")]
        public void When_objFile_Is_ObjReader_Parse()
        {
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            writer.Write(_objFileContext.FileContent);
            writer.Flush();
            stream.Position = 0;

            _objFileContext.ObjFile = _objFileContext.ObjReader.Parse(stream);
        }

        [When(@"triangle1 ← first child of objFile\.Triangles")]
        public void When_triangle1_Is_First_Child_Of_Triangles_Of_objFile()
        {
            _objFileContext.Triangles[1] = _objFileContext.ObjFile.Mesh.GetTriangle(1);
        }

        [When(@"triangle2 ← second child of objFile\.Triangles")]
        public void When_triangle2_Is_Second_Child_Triangles_Of_objFile()
        {
            _objFileContext.Triangles[2] = _objFileContext.ObjFile.Mesh.GetTriangle(2);
        }

        [When(@"triangle3 ← third child of objFile\.Triangles")]
        public void When_triangle3_Is_Second_Child_Triangles_Of_objFile()
        {
            _objFileContext.Triangles[3] = _objFileContext.ObjFile.Mesh.GetTriangle(3);
        }

        [Then(@"objFile\.IgnoredLineCount should equal (.*) lines")]
        public void ThenParserShouldHaveIgnoredLines(int linesIgnored)
        {
            Assert.Equal(linesIgnored, _objFileContext.ObjFile.IgnoredLineCount);
        }

        [Then(@"objFile\.Mesh\.Vertices\[(.*)] = Point\((.*), (.*), (.*)\)")]
        public void Then_VertexN_Of_Mesh_Of_objFile_Should_Equal(int indexOfVertex, double x, double y, double z)
        {
            var expectedPoint = new RtPoint(x, y, z);

            var actualPoint = _objFileContext.ObjFile.Mesh.GetVertex(indexOfVertex);

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"triangle(.*)\.Point1 = objFile\.Mesh\.Vertices\[(.*)]")]
        public void Then_point1_Of_triangleN_Should_Equal_Mesh_Of_ObjFile_VertexN(int indexOfTriangle, int indexOfVertex)
        {
            var expectedPoint = _objFileContext.ObjFile.Mesh.GetVertex(indexOfVertex);

            var actualPoint = _objFileContext.Triangles[indexOfTriangle].Point1;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"triangle(.*)\.Point2 = objFile\.Mesh\.Vertices\[(.*)]")]
        public void Then_point2_Of_triangleN_Should_Equal_Mesh_Of_ObjFile_VertexN(int indexOfTriangle, int indexOfVertex)
        {
            var expectedPoint = _objFileContext.ObjFile.Mesh.GetVertex(indexOfVertex);

            var actualPoint = _objFileContext.Triangles[indexOfTriangle].Point2;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [Then(@"triangle(.*)\.Point3 = objFile\.Mesh\.Vertices\[(.*)]")]
        public void Then_point3_Of_triangleN_Should_Equal_Mesh_Of_ObjFile_VertexN(int indexOfTriangle, int indexOfVertex)
        {
            var expectedPoint = _objFileContext.ObjFile.Mesh.GetVertex(indexOfVertex);

            var actualPoint = _objFileContext.Triangles[indexOfTriangle].Point3;

            Assert.Equal(expectedPoint, actualPoint);
        }

        [When(@"group(.*) ← ""(.*)"" from parser")]
        public void WhenGroupFromParser(int indexOfTriangleGroup, string groupName)
        {
            _objFileContext.TriangleGroups[indexOfTriangleGroup] = _objFileContext.ObjFile.Mesh.GetTrianglesForGroup(groupName);
        }

        [When(@"triangle(.*) ← first child of group(.*)")]
        public void WhenTriangleSecondChildOfGroup(int indexOfTraingle, int indexOfTriangleGroup)
        {
            _objFileContext.Triangles[indexOfTraingle] = _objFileContext.TriangleGroups[indexOfTriangleGroup].FirstOrDefault();
        }

        [Then(@"objFile\.Mesh\.Normals\[(.*)] = Vector\((.*), (.*), (.*)\)")]
        public void Then_NormalN_Of_Mesh_Parser_Should_Equal_Vector(int indexOfNormal, double x, double y, double z)
        {
            var expectedVector = new RtVector(x, y, z);

            Assert.Equal(expectedVector, _objFileContext.ObjFile.Mesh.GetNormal(indexOfNormal));
        }
    }
}
