using System.Drawing;

namespace mvc;

public class Serveur  : Persone ,Move,IObservable<Serveur>

{
    private List<Sprite> square;
    private List<IObserver<Serveur>> observers = new List<IObserver<Serveur>>();
    public Serveur(Size size, Point position, Map map) : base(size, position, map)
    {
        this.Sprite1 = "serveur";
    }
   


    public void move(Point target)
    {
        if (target.Y != this.Position.Y)
        {
            if (this.Position.Y -target.Y > 0)
            {

                for (int i = 0; i <=target.Y ;i++)
                {
                    this.Position = new Point(this.Position.X, this.Position.Y -Size.Width);
                    this.Notify(this);
                    Thread.Sleep(100);
                }
                
            }
            else
            {
                for (int i = 0; i <=target.Y ;i++)
                {
                    this.Position = new Point(this.Position.X, this.Position.Y + Size.Width);
                    this.Notify(this);
                    Thread.Sleep(100);
                }  
            }
        }
        else  if(target.X != this.Position.X)
        {
            if (target.X - Position.X>0)
            {
                for (int i = 0; i < target.X; i++)
                {
                    this.Position = new Point(this.Position.X + Size.Width, this.Position.Y);
                    this.Notify(this);
                    Thread.Sleep(100);
                }
            }
            else
            {
                for (int i = 0; i < target.X; i++)
                {
                    this.Position = new Point(this.Position.X - Size.Width, this.Position.Y);
                    this.Notify(this);
                    Thread.Sleep(100);
                } 
            }
        }
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
