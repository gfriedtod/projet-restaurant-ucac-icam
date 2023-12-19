using System.Drawing;

namespace mvc;

public class Sprite
{
    private String sprite;
    private Size size;
    public string Sprite1
    {
        get { return sprite; }
        set { sprite = value ?? throw new ArgumentNullException(nameof(value)); }
    }
    public Size Size
    {
        get { return size; }
        set { size = value; }
    }
    public Point Position
    {
        get { return position; }
        set { position = value; }
    }
    private Point position;

    public Sprite( Size size, Point position)
    {
      
        this.size = size;
        this.position = position;
    }
}