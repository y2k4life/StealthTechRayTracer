//-----------------------------------------------------------------------
// <copyright file="TransformationContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs.Contexts
{
    public class TransformationsContext
    {
        public Transform Transform { get; set; } = new Transform();
            
        public Transform InverseTransform { get; set; }
        
        public Transform HalfQuarter { get; set; }
        
        public Transform FullQuarter { get; set; }
        
        public Transform TransformA { get; set; }
        
        public Transform TransformB { get; set; }
        
        public Transform TransformC { get; set; }

        public Transform TransformT { get; set; }
    }
}
