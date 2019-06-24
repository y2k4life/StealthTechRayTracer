//-----------------------------------------------------------------------
// <copyright file="IntersectionList.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StealthTech.RayTracer.Library
{
    public class IntersectionList
    {
        private readonly List<Intersection> _intersections;

        public IntersectionList()
        {
            _intersections = new List<Intersection>();
        }

        public IntersectionList(List<Intersection> list)
        {
            _intersections = list;
        }

        public int Count => _intersections.Count;

        public void Add(Intersection intersection)
        {
            _intersections.Add(intersection);
        }

        public void AddRange(List<Intersection> intersections)
        {
            _intersections.AddRange(intersections);
        }

        public Intersection Hit()
        {
            var intersectionsGreaterThanZero = _intersections
                .Where(i => i.Time > 0)
                .ToList();

            if (intersectionsGreaterThanZero == null)
            {
                return null;
            }

            return intersectionsGreaterThanZero
                .FirstOrDefault(i => i.Time == intersectionsGreaterThanZero.Min(i1 => i1.Time));
        }

        public Intersection this[int index]
        {
            get
            {
                return _intersections[index];
            }
        }
    }
}
