//-----------------------------------------------------------------------
// <copyright file="ObjFile.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public class ObjFile
    {
        public int IgnoredLineCount { get; set; }

        public TriangleMesh Mesh { get; } = new TriangleMesh();
    }
}