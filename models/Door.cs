using mvc;
using System.Drawing;

namespace models;

public class Door  : Sprite
{

    public Door(Size size, Point position) : base(size, position)
    {

        this.Sprite1 = "tile002";
    }
}
