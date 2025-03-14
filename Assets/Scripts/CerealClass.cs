using System;
using System.Collections.Generic;
using UnityEngine;

public enum CerealShape
{
    Triangle,
    Square,
    Pentagon,
    Hexagon
}

public enum CerealColor
{
    Red,
    Green,
    Blue
}

public struct CerealClass: IComparable<CerealClass>
{
    public CerealShape shape;
    public CerealColor color;

    public CerealClass(CerealShape shape, CerealColor color)
    {
        this.shape = shape;
        this.color = color;
    }

    public readonly int CompareTo(CerealClass other)
    {
        if (shape == other.shape)
        {
            return (int)color - (int)other.color;
        }
        return (int)shape - (int)other.shape;
    }
}
