public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

     public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual/abstract method for area
    public abstract double GetArea();
}
