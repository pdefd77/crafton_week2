using UnityEngine;

public enum Shape
{
    Triangle,
    Square,
    pentagon,
    hexagon
}

public enum Color
{
    Red,
    Green,
    Blue
}

public class CerealClass
{
    public Shape shape;
    public Color color;

    public CerealClass(Shape shape, Color color)
    {
        this.shape = shape;
        this.color = color;
    }
}
