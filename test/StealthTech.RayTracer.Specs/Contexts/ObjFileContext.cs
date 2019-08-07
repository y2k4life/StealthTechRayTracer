using StealthTech.RayTracer.Library;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class ObjFileContext
    {
        public ObjReader ObjReader { get; internal set; }

        public string FileContent { get; internal set; }

        public ObjFile ObjFile { get; set; }
        
        public Triangle[] Triangles { get; } = new Triangle[5];

        public string FileName { get; set; }

        public IEnumerable<Triangle>[] TriangleGroups { get; set; } = new IEnumerable<Triangle>[5];
    }
}
