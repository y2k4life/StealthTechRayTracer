//-----------------------------------------------------------------------
// <copyright file="ObjReader.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

namespace StealthTech.RayTracer.Library
{
    public class ObjReader
    {
        public ObjFile ParseFile(string fileName)
        {
            using var fileStream = File.OpenRead(fileName);
            return Parse(fileStream);
        }

        public ObjFile Parse(Stream stringStream)
        {
            var objFile = new ObjFile();
            using (var txtReader = new StreamReader(stringStream))
            {
                string group = "Default";
                int vertexCounter = 1;
                while (!txtReader.EndOfStream)
                {
                    var line = txtReader.ReadLine().Trim();
                    var lineParts = new Span<string>(line.Split(' '));
                    var dataStructure = lineParts[0];
                    var index = lineParts.Length > 1 && lineParts[1] == "" ? 2 : 1;
                    switch (dataStructure)
                    {
                        case "v":
                            double v1 = Convert.ToDouble(lineParts[index]);
                            double v2 = Convert.ToDouble(lineParts[index + 1]);
                            double v3 = Convert.ToDouble(lineParts[index + 2]);
                            objFile.Mesh.AddVertex(v1, v2, v3);
                            vertexCounter++;
                            break;
                        case "vn":
                            double x = Convert.ToDouble(lineParts[index]);
                            double y = Convert.ToDouble(lineParts[index + 1]);
                            double z = Convert.ToDouble(lineParts[index + 2]);
                            objFile.Mesh.AddNormal(x, y, z);
                            vertexCounter++;
                            break;
                        case "f":
                            ParseFaces(lineParts, group, vertexCounter, objFile.Mesh);
                            break;
                        case "g":
                            group = lineParts[1];
                            break;
                        default:
                            objFile.IgnoredLineCount++;
                            break;
                    }
                }
            }

            return objFile;
        }

        private void ParseFaces(Span<string> lineParts, string group, int vertexCounter, TriangleMesh mesh)
        {
            var normalCounter = 0;
            if (lineParts.Length > 4)
            {
                FanTriangulation(lineParts.Slice(1, lineParts.Length - 1), vertexCounter, group, mesh);
            }
            else
            {
                if (lineParts[1].Contains('/'))
                {
                    var faceVertex1 = BuildFace(lineParts[1].Split('/'));
                    var faceVertex2 = BuildFace(lineParts[2].Split('/'));
                    var faceVertex3 = BuildFace(lineParts[3].Split('/'));
                    if (faceVertex1.VertexIndex < 1)
                    {
                        mesh.AddTriangle(BuildTiangle(group, vertexCounter, normalCounter, faceVertex1, faceVertex2, faceVertex3));
                    }
                    else
                    {
                        mesh.AddTriangle(BuildTiangle(group, 0, 0, faceVertex1, faceVertex2, faceVertex3));
                    }
                }
                else
                {
                    if (Convert.ToInt32(lineParts[1]) < 1)
                    {
                        mesh.AddTriangle(
                            vertexCounter + Convert.ToInt32(lineParts[1]),
                            vertexCounter + Convert.ToInt32(lineParts[2]),
                            vertexCounter + Convert.ToInt32(lineParts[3]), group);
                    }
                    else
                    {
                        mesh.AddTriangle(Convert.ToInt32(lineParts[1]), Convert.ToInt32(lineParts[2]), Convert.ToInt32(lineParts[3]), group);
                    }
                }
            }
        }

        private static TriangleGeometry BuildTiangle(string group, int vertexCounter, int normalCounter, Face faceVertex1, Face faceVertex2, Face faceVertex3)
        {
            return new TriangleGeometry
            {
                Vertex1 = vertexCounter + faceVertex1.VertexIndex,
                Vertex2 = vertexCounter + faceVertex2.VertexIndex,
                Vertex3 = vertexCounter + faceVertex3.VertexIndex,
                Normal1 = normalCounter + faceVertex1.NormalIndex,
                Normal2 = normalCounter + faceVertex2.NormalIndex,
                Normal3 = normalCounter + faceVertex3.NormalIndex,
                Group = group
            };
        }

        private void FanTriangulation(Span<string> lineParts, int vertexCounter, string group, TriangleMesh mesh)
        {
            var normalCounter = 0;
            for (int index = 1; index < lineParts.Length - 1; index++)
            {
                if (lineParts[0].Contains('/'))
                {
                    var faceVertex1 = BuildFace(lineParts[0].Split('/'));
                    var faceVertex2 = BuildFace(lineParts[index].Split('/'));
                    var faceVertex3 = BuildFace(lineParts[index + 1].Split('/'));
                    if (faceVertex1.VertexIndex < 1)
                    {
                        mesh.AddTriangle(BuildTiangle(group, vertexCounter, normalCounter, faceVertex1, faceVertex2, faceVertex3));
                    }
                    else
                    {
                        mesh.AddTriangle(BuildTiangle(group, 0, 0, faceVertex1, faceVertex2, faceVertex3));
                    }
                }
                else
                {
                    if (Convert.ToInt32(lineParts[1]) < 1)
                    {
                        mesh.AddTriangle(
                            vertexCounter + Convert.ToInt32(lineParts[0]),
                            vertexCounter + Convert.ToInt32(lineParts[index]),
                            vertexCounter + Convert.ToInt32(lineParts[index + 1]), group);
                    }
                    else
                    {
                        mesh.AddTriangle(Convert.ToInt32(lineParts[0]), Convert.ToInt32(lineParts[index]), Convert.ToInt32(lineParts[index + 1]), group);
                    }
                }
            }
        }

        private static Face BuildFace(string[] facePart)
        {
            return new Face
            {
                VertexIndex = Convert.ToInt32(facePart[0]),
                TextureIndex = facePart[1] == "" ? 0 : Convert.ToInt32(facePart[1]),
                NormalIndex = Convert.ToInt32(facePart[2])
            };
        }
    }
}
