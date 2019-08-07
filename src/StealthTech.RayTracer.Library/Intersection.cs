//-----------------------------------------------------------------------
// <copyright file="Intersection.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace StealthTech.RayTracer.Library
{
    public class Intersection : IEquatable<Intersection>
    {
        public Intersection()
        {
        }

        public Intersection(double time, Shape item)
        {
            Shape = item;
            Time = time;
        }

        public Intersection(double time, Shape shape, double u, double v)
            : this (time, shape)
        {
            U = u;
            V = v;
        }

        public double Time { get; set; }

        public Shape Shape { get; set; }

        public double U { get; set; }

        public double V { get; set; }

        public Computations PrepareComputations(Ray ray, IntersectionList intersections)
        {
            var computations = new Computations()
            {
                Time = Time,
                Shape = Shape,
                Position = ray.Position(Time),
                EyeVector = ray.Direction.Negate(),
            };

            computations.NormalVector = Shape.NormalAt(computations.Position, this);

            if(computations.NormalVector.Dot(computations.EyeVector) < 0)
            {
                computations.Inside = true;
                computations.NormalVector = computations.NormalVector.Negate();
            }
            else
            {
                computations.Inside = false;
            }

            computations.ReflectVector = ray.Direction.Reflect(computations.NormalVector);

            List<Shape> container = new List<Shape>();

            if(intersections != null && intersections.Count > 0)
            {
                foreach (var intersection in intersections.Items)
                {
                    if (intersection == this)
                    {
                        if (container.Count == 0)
                        {
                            computations.n1 = 1.0;
                        }
                        else
                        {
                            computations.n1 = container.Last().Material.RefractiveIndex;
                        }
                    }

                    if (container.Contains(intersection.Shape))
                    {
                        container.Remove(intersection.Shape);
                    }
                    else
                    {
                        container.Add(intersection.Shape);
                    }

                    if (intersection == this)
                    {
                        if (container.Count == 0)
                        {
                            computations.n2 = 1.0;
                        }
                        else
                        {
                            computations.n2 = container.Last().Material.RefractiveIndex;
                        }

                        break;
                    }
                }
            }

            return computations;
        }

        public override string ToString()
        {
            return $"{Shape.Name} : {Time}";
        }

        public override int GetHashCode()
        {
            return Time.GetHashCode() ^ Shape.GetHashCode();
        }

        public bool Equals(Intersection other)
        {
            return Time.Equals(other.Time) &&
                 Shape.Equals(other.Shape);
        }

    }
}
