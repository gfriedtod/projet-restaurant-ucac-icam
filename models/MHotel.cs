using System.Drawing;

namespace mvc;

public class MHotel : Persone ,IObservable<Client>
{
    public List<Table> Tables
    {
        get { return _tables; }
        set { _tables = value ?? throw new ArgumentNullException(nameof(value)); }
    }
    private List<Table> _tables ;
   
    private List<RangeLead> _rangeLeads;

    
    public List<RangeLead> RangeLeads

   
    {
        get { return _rangeLeads; }
        set { _rangeLeads = value ?? throw new ArgumentNullException(nameof(value)); }
    }

    private List<IObserver<Client>> observers = new List<IObserver<Client>>();
    private delegate void Task();
    private Task task;
    public MHotel( Size size, Point position, Map map) : base( size, position, map)
    {
        this.Sprite1 = "client";

    


    }

    public void AssignedClient(Client client)
    {
        foreach (var table  in _tables)
        {
            if (!table.State && table.Number_clinet > client.NumberClient)
            {
                if ((table.Number_clinet - client.NumberClient)/2 < table.Number_clinet/2)
                {
                    client.TableNumber = table;
                    client.move(table.Position);
                    table.State = true;
                    
                    
                    
                    break;

                }
                 
            }
        }
    }

    public void run()
    {
     
    }



    public IDisposable Subscribe(IObserver<Client> observer)
    {
        observers.Add(observer);
        return null;
    }
    
    public void Notify(Client value)
    {
        foreach (var observer in observers)
        {
            if (observer.GetType().GetProperty("IsStopped") == null || !(bool)observer.GetType().GetProperty("IsStopped").GetValue(observer, null))
                observer.OnNext(value);
        }
    }
}