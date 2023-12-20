using System.Drawing;

namespace mvc;

public class RangeLead : Persone  , Move ,IObservable<RangeLead>
{
    private List<IObserver<RangeLead>> observers = new List<IObserver<RangeLead>>();
    public RangeLead( Size size, Point position, Map map) : base(size, position, map)
    {
        this.Sprite1 = "client2";
    }

    public void DragClient(Client client)
    {
        
      //  this.move();
        
    }

    public void move(Point target)
    {
        while (this.Position != target)
        {
             if (target.Y != this.Position.Y)
                   {
                       if (this.Position.Y -target.Y > 0)
                       {
           
                           for (int i = 0; i <=target.Y ;i++)
                           {
                               this.Position = new Point(this.Position.X, this.Position.Y -1);
                               this.Notify(this);
                               Thread.Sleep(100);
                           }
                           
                       }
                       else
                       {
                           for (int i = 0; i <=target.Y ;i++)
                           {
                               this.Position = new Point(this.Position.X, this.Position.Y + 1);
                               this.Notify(this);
                               Thread.Sleep(100);
                           }  
                       }
                   }
                  if(target.X != this.Position.X)
                   {
                       Console.WriteLine("moveLeftRight");
                       if (target.X - Position.X>0)
                       {
                           Console.WriteLine("moveLeftRight");
                           for (int i = 0; i < target.X; i++)
                           {
                               this.Position = new Point(this.Position.X + 1, this.Position.Y);
                               this.Notify(this);
                               Thread.Sleep(100);
                           }
                       }
                       else
                       {
                           for (int i = 0; i < target.X; i++)
                           {
                               this.Position = new Point(this.Position.X - 1, this.Position.Y);
                               this.Notify(this);
                               Thread.Sleep(100);
                           } 
                       }
                   } 
        }
      
    }

    public void Notify(RangeLead value)
    {
        foreach (var observer in observers)
        {
            if (observer.GetType().GetProperty("IsStopped") == null || !(bool)observer.GetType().GetProperty("IsStopped").GetValue(observer, null))
                observer.OnNext(value);
        }
    }
    public IDisposable Subscribe(IObserver<RangeLead> observer)
    {
        observers.Add(observer);
        return null;
    }
}