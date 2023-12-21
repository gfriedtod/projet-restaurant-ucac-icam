using System.Drawing;

namespace mvc;

public class Client : Persone ,Move,IObservable<Client>
{

    private int number_client;
    private List<IObserver<Client>> observers = new List<IObserver<Client>>(); // <Client>
    private ClientMove _clientMove = ClientMove.Waiting;
   
    public ClientMove ClientMove
    {
        get { return _clientMove; }
        set { _clientMove = value; }
    }
    public int NumberClient
    {
        get { return number_client; }
        set { number_client = value; }
    }
    public bool Type1
    {
        get { return type; }
        set { type = value; }
    }
    public List<Food> Commande
    {
        get { return commande; }
        set { commande = value ?? throw new ArgumentNullException(nameof(value)); }
    }
    
    public bool Type
    {
        get => type;
        set => type = value;
    }

    private bool type;

    public Table TableNumber
    {
        get => tableNumber;
        set => tableNumber = value;
    }

    private List<Food> commande;

    private Table  tableNumber ;
    public Point origin { get; set; }

    public Client(Size size, Point position, Map map, int numberClient, bool type) : base( size, position, map)
    {
        number_client = numberClient;
        this.type = type;
        this.Sprite1 = "client3";
        origin = Position;
        
        new Thread((o =>
        {

            while (tableNumber != null)
            {
                move(tableNumber.Position);
            } 
            
            
        
        })).Start();
            
        
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
        
        this.Notify(this);
      
    }

    public void commandPass()
    
    {
        for (int i = 0; i <= number_client; i++)
        {
            
            this.commande.Add(new Food());
            
        }
        
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

    public void init()
    {
        this.Position = origin;
        this.commande = new List<Food>();
        this.tableNumber = null;
        ClientMove =ClientMove.Waiting;
        Notify(this);
        throw new NotImplementedException();
    }
}