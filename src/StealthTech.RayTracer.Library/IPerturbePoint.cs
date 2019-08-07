//-----------------------------------------------------------------------
// <copyright file="IPerturbePoint.cs" company="StealthTech">
//     Author: Guy Boicey
//     Copyright (c) 2019 Guy Boicey
// </copyright>
//-----------------------------------------------------------------------

namespace StealthTech.RayTracer.Library
{
    public interface IPerturbPoint
    {
        RtPoint Perturb(RtPoint localPoint);
    }
}
