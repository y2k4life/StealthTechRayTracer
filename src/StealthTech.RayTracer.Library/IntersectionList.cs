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
        private bool _sorted = false;
        
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

        public bool IsEmpty => _intersections.Count == 0;

        public void Add(Intersection intersection)
        {
            _intersections.Add(intersection);
            _sorted = false;
        }

        public void AddRange(IntersectionList intersectionList)
        {
            foreach (var intersection in intersectionList.Intersections)
            {
                _intersections.Add(intersection);
            }
            _sorted = false;
        }

        public Intersection Hit()
        {
            var intersectionsGreaterThanZero = _intersections
                .Where(i => i.Time > 0)
                .ToList();

            if (intersectionsGreaterThanZero == null || intersectionsGreaterThanZero.Count == 0)
            {
                return null;
            }

            var minTime = intersectionsGreaterThanZero.Min(i => i.Time);

            return intersectionsGreaterThanZero.FirstOrDefault(i => i.Time == minTime);
        }

        public Intersection this[int index]
        {
            get
            {
                if(!_sorted)
                {
                    _intersections = _intersections.OrderBy(i => i.Time).ToList();
                }

                return _intersections[index];
            }
        }

        public bool HasHit()
        {
            if (_intersections == null)
                return false;

            return _intersections.Where(i => i.Time > 0).Count() > 0;
        }
    }
}
