using mvc;
using System.Drawing;

namespace models;

public class Instru    : Sprite
{

    public Instru(Size size, Point position) : base(size, position)
    {
        this.Sprite1 = "instru";
    }
}
