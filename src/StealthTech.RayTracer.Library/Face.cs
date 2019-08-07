//-----------------------------------------------------------------------
// <copyright file="Face.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    internal class Face
    {
        public int VertexIndex { get; set; }

        public int TextureIndex { get; set; }
        
        public int NormalIndex { get; set; }
    }
}