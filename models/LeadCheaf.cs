using models;
using mvc;
using System.Drawing;

namespace model_cuisine;

public class LeadCheaf : Persone  ,IObservable<LeadCheaf>
{
    
    List<IObserver<LeadCheaf>> _observers =new List<IObserver<LeadCheaf>>();
    public List<Cheaf> _cheafs { get; set; }
    public List<Instru> _instrus { get; set; }
    public List<Door> _doors { get; set; }
    public List<Food> _foods = new List<Food>() {
        new Food(), new Food(),
        new Food(),
        new Food(),
        new Food(),
        new Food(),
        new Food()

    };
    
    

    public LeadCheaf(Size size, Point position, Map map) : base(size, position,map)
    {
        this.Sprite1 = "cuisto";
    }

    public void AssignTask( Cheaf cheaf)
    {

        Console.WriteLine("we are there");
        foreach (var f in _foods)
        {
        
                ThreadPool.QueueUserWorkItem((state =>
                {
                    cheaf.move(_instrus[(int)new Random().Next(_cheafs.Count)].Position);
                    Thread.Sleep(1000);
                    cheaf.move(_doors[0].Position);
                    cheaf.move(cheaf.Origin);
                }));
            
        }
        
        
    }

    public IDisposable Subscribe(IObserver<LeadCheaf> observer)
    {
       _observers.Add(observer);
       return null;
    }
}
