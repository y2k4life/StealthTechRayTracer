//-----------------------------------------------------------------------
// <copyright file="TransformationContext.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

using StealthTech.RayTracer.Library;

namespace StealthTech.RayTracer.Specs
{
    public class TransformationContext
    {
        public Transform Transform { get; set; } = new Transform();
            
        public Transform InverseTransform { get; set; }
        
        public Transform HalfQuarter { get; set; }
        
        public Transform FullQuarter { get; set; }
        
        public Transform A { get; set; }
        
        public Transform B { get; set; }
        
        public Transform C { get; set; }
        
        public Transform T { get; set; }

        public RtPoint From { get; set; }

        public RtPoint To { get; set; }

        public RtVector Up { get; set; }
    }
}
