using System.Drawing;

namespace mvc;

public class Persone : Sprite
{
    private Map map;

    public Persone( Size size, Point position, Map map) : base( size, position)
    {
        this.map = map;
    }
}