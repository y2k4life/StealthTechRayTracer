//-----------------------------------------------------------------------
// <copyright file="ShapeGroupsContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class ShapeGroupsContext
    {
        public ShapeGroup ShapeGroup { get; set; }

        public ShapeGroup[] ShapeGroups { get; } = new ShapeGroup[5];
    }
}
