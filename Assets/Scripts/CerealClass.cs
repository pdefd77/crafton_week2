using System;

public enum CerealShape
{
    Circle,
    Triangle,
    Square,
    Pentagon,
    Hexagon,
    Star
}

public enum CerealColor
{
    Red,
    Green,
    Blue,
    Pink,
    Yellow
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
