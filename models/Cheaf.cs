using mvc;
using System.Drawing;

namespace model_cuisine;

public class Cheaf : Persone ,Move,IObservable<Cheaf>
{

    private Point origin;
    public Point Origin
    {
        get { return origin; }
        set { origin = value; }
    }
    public Cheaf(Size size, Point position, Map map) : base(size, position,map)
    {
        this.Sprite1 = "cuisto";
        this.origin = origin;

    }

    public void move(Point target)
    {
        if(this.Position.X > target.X && this.Position. Y > target. Y)
        {
            while (this.Position. X > target. X)
            {
                this.Position = new Point(this.Position.X-1 , this.Position.Y);
                Thread.Sleep(200);
            }

            while (this.Position. Y > target. Y)
            {
                this.Position = new Point(this.Position.X , this.Position.Y-1);
                Thread.Sleep(200);
            }
        }

        if (this.Position. X < target. X && this.Position. Y > target. Y)
        {
            while (this.Position. X < target. X)
            {
                this.Position = new Point(this.Position.X+1 , this.Position.Y);
                Thread.Sleep(200);
            }

            while (this.Position. Y > target. Y)
            {
                
                this.Position = new Point(this.Position.X , this.Position.Y-1);
                Thread.Sleep(200);
                
            }
        }

        if (this.Position. X > target. X && this.Position. Y < target. Y)
        {
            while (this.Position. X > target. X)
            {
                this.Position = new Point(this.Position.X-1 , this.Position.Y);
                Thread.Sleep(200);
            }

            while (this.Position. Y < target. Y)
            {
                this.Position = new Point(this.Position.X , this.Position.Y-1);
                Thread.Sleep(200);
            }
        }

        if (this.Position. X < target. X && this.Position. Y < target. Y)
        {
            while (this.Position. X <target. X)
            {
                this.Position = new Point(this.Position.X+1 , this.Position.Y);
                Thread.Sleep(200);
            }

            while (this.Position. Y < target. Y)
            {
                this.Position = new Point(this.Position.X , this.Position.Y+1);
                Thread.Sleep(200);
            }
        }
        
       // this.Notify(this);
      
    }

    public IDisposable Subscribe(IObserver<Cheaf> observer)
    {
        return null;
    }
}
