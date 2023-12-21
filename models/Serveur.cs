using System.Drawing;

namespace mvc;

public class Serveur  : Persone ,Move,IObservable<Serveur>

{
    private List<Sprite> square;
    private List<IObserver<Serveur>> observers = new List<IObserver<Serveur>>();
    private Point origin;
    public Point Origin
    {
        get { return origin; }
        set { origin = value; }
    }
    public Serveur(Size size, Point position, Map map) : base(size, position, map)
    {
        this.Sprite1 = "serveur";
        origin = position;
    }
   


    public void move(Point target)
    {
        Console.WriteLine("we movit");
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
        
        //this.Notify(this);
      
    }

    public IDisposable Subscribe(IObserver<Serveur> observer)
    {
        observers.Add(observer);
       return null;
    }
    
    public void Notify(Serveur value)
    {
        foreach (var observer in observers)
        {
            if (observer.GetType().GetProperty("IsStopped") == null || !(bool)observer.GetType().GetProperty("IsStopped").GetValue(observer, null))
                observer.OnNext(value);
        }
    }
}
