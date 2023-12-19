using System.Drawing;

namespace mvc;

public class RangeLead : Persone  , Move
{
    public RangeLead( Size size, Point position, Map map) : base(size, position, map)
    {
        this.Sprite1 = "tile";
    }

    public void DragClient(Client client)
    {
        
      //  this.move();
        
    }

    public void move(Point target)
    {
        throw new NotImplementedException();
    }
}