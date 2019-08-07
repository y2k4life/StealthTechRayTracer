namespace StealthTech.RayTracer.Library
{
    public class TriangleGeometry
    {
        public string Group { get; set; }
        
        public int Vertex1 { get; set; }

        public int Vertex2 { get; set; }

        public int Vertex3 { get; set; }

        public int Normal1 { get; set; }

        public int Normal2 { get; set; }

        public int Normal3 { get; set; }

        public TriangleGeometry()
        {
            Group = "Default";
        }

        public TriangleGeometry(string group)
        {
            Group = group;
        }
    }
}
