//-----------------------------------------------------------------------
// <copyright file="ShapeGroups.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace StealthTech.RayTracer.Library
{
    public class ShapeGroup : Shape
    {
        private List<Shape> _shapes = new List<Shape>();
        
        public IEnumerable<Shape> Shapes
        {
            get
            {
                return _shapes;
            }
        }

        public ShapeGroup()
        {
        }

        public override IntersectionList LocalIntersect(Ray ray)
        {
            var intersections = new IntersectionList();
            foreach (var shape in Shapes)
            {
                intersections.AddRange(shape.Intersect(ray));
            }

            return intersections;
        }

        public override RtVector LocalNormalAt(RtPoint point)
        {
            throw new System.NotImplementedException();
        }
        public void AddChild(Shape shape)
        {
            shape.Parent = this;
            _shapes.Add(shape);
        }
    }
}
