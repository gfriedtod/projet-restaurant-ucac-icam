using System.Drawing;

namespace mvc;

public class TIles  : Sprite
{

    public TIles(Size size, Point position) : base(size, position)
    {
        this.Sprite1 = "tile";
    }
}
