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
        private List<Intersection> _intersections;

        public IEnumerable<Intersection> Intersections
        {
            get
            {
                return _intersections;
            }
        }

        public IntersectionList()
        {
            _intersections = new List<Intersection>();
        }

        public int Count => _intersections.Count;

        public void Add(Intersection intersection)
        {
            _intersections.Add(intersection);
            _intersections = _intersections.OrderBy(i => i.Time).ToList();
        }

        public void AddRange(IntersectionList intersectionList)
        {
            foreach (var intersection in intersectionList.Intersections)
            {
                _intersections.Add(intersection);
            }
            _intersections = _intersections.OrderBy(i => i.Time).ToList();
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

        public bool HasHit => _intersections.Where(i => i.Time > 0).Count() > 0;
    }
}
