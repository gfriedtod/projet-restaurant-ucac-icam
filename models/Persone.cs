using System.Drawing;

namespace mvc;

public class Persone : Sprite
{
    private Map map;
    public string Request
    {
        get { return request; }
        set { request = value ?? throw new ArgumentNullException(nameof(value)); }
    }
    private String request;

    public Persone( Size size, Point position, Map map) : base( size, position)
    {
        this.map = map;
    }
}