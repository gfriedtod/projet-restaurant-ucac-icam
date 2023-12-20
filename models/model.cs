using System.Drawing;

namespace mvc;

public class Models : IObserver<MHotel> ,IObserver<Client>, IObserver<RangeLead>, IObserver<Serveur>,IObserver<Table>,IObservable<Models>
{

    private List<Sprite> _tables=new List<Sprite>();
    private List<Serveur>_serveurs=new List<Serveur>();
    private List<RangeLead>_rangeLeads=new List<RangeLead>();
    private List<Client> _clients = new List<Client>(); 
    private List<Table> _table=new List<Table>();
    private GeneratedClient GeneratedClient;

 
    
    public List<RangeLead> RangeLeads
    {
        get { return _rangeLeads; }
        set { _rangeLeads = value ?? throw new ArgumentNullException(nameof(value)); }
    }
    public MHotel mHotel { get; set; }
    private List<IObserver<Models>> observers = new List<IObserver<Models>>();
    
    
    private Map _map=new Map(200,200);
    private IObservable<Models> _observableImplementation;
    public List<Sprite> Tables
    {
        get { return _tables; }
        set { _tables = value ?? throw new ArgumentNullException(nameof(value)); }
    }
    public Map Map
    {
        get { return _map; }
        set { _map = value ?? throw new ArgumentNullException(nameof(value)); }
    }

    public List<Client> Clients
    {
        get { return _clients; }
        set { _clients = value ?? throw new ArgumentNullException(nameof(value)); }
    }


    public void DrawingMap()
    {
        
        
        _tables = _map.drawMap("assets/map.txt");
        getSprite();
        
                            
    }

    public void getSprite()
    {
        foreach (Sprite sprite in _tables)
        {
            if (sprite is Client)
            {
                _clients.Add((Client)sprite);
                Console.Write("ok");
                Client client = (Client)sprite;
                client.Subscribe(this);

            }   else if (sprite is Table)
            {
                _table.Add((Table)sprite);
                Table tab = (Table)sprite;
                tab.Subscribe(this);
            }  else if (sprite is Serveur)
            {
                _serveurs.Add((Serveur)sprite);
                Serveur serveur = (Serveur)sprite;
                serveur.Subscribe(this);
            }     else if (sprite is RangeLead)
            {
                _rangeLeads.Add((RangeLead)sprite);
                
            }  else if (sprite is MHotel)
            {
                mHotel = (MHotel)sprite;
                
            }  
        }
        mHotel.Tables = _table;
        mHotel.RangeLeads = _rangeLeads;
        for (int i = 0; i < _table.Count; i++)
        {
            for (int j = 0; j < _serveurs.Count; j++)
            {
                if (j%2==0)
                {
                    
                }
            }
        }
        mHotel.Subscribe(this);





    }
    
    public Models()
    {
        GeneratedClient = new GeneratedClient();
      
    }

    // public void run()
    // {
    //     new Thread((() =>
    //     {
    //         Console.WriteLine("runable");
    //         foreach (var client in Clients)
    //         {
    //             this.mHotel.AssignedClient(client);
    //
    //
    //         }
    //     })).Start();
    // }


    void IObserver<MHotel>.OnCompleted()
    {
        throw new NotImplementedException();
        
    }

    void IObserver<Table>.OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Table value)
    {
        for (int i = 0; i < _table.Count; i++)
        {
            if (_table[i].TableNumber == value.TableNumber)
            {
                _table[i] = value;
            } 
        }
        throw new NotImplementedException();
        
    }

    void IObserver<Table>.OnCompleted()
    {
        throw new NotImplementedException();
    }

    void IObserver<Serveur>.OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Serveur value)
    {
        this.Notify(this);
    }

    void IObserver<Serveur>.OnCompleted()
    {
        throw new NotImplementedException();
    }

    void IObserver<RangeLead>.OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(RangeLead value)
    {
        throw new NotImplementedException();
    }

    void IObserver<RangeLead>.OnCompleted()
    {
        throw new NotImplementedException();
    }

    void IObserver<Client>.OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Client value)
    {

        if (value.ClientMove == ClientMove.Waiting)
        {
           // _clients.Remove(value);
           // _clients.Add(GeneratedClient.GetClient());
            ThreadPool.QueueUserWorkItem( (state => value.move(new Point(value.TableNumber.Position.X, value.TableNumber.Position.Y-5))) );
            value.ClientMove = ClientMove.TableAssigned;
           // this.Map.Map1[value.Position.X, value.Position.Y] = value;
            this.Notify(this);
            // new Thread(o =>
            // {
            //     this.run();
            // } ).Start();

        }
        else if (value.ClientMove == ClientMove.TableAssigned)
        {
            value.ClientMove = ClientMove.CommandePass;
            this.Notify(this);
            
        }
        
        
        Console.WriteLine("modify");

       // _clients.Find((client => client == value)).Position = value.Position;
        //this.Notify(this);
        
    }                                                       

    void IObserver<Client>.OnCompleted()
    {
        throw new NotImplementedException();
    }

    void IObserver<MHotel>.OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(MHotel value)
    {
        throw new NotImplementedException();
    }

    public IDisposable Subscribe(IObserver<Models> observer)
    {
        observers.Add(observer);
        return null;
    }
    
    public void Notify(Models value)
    {
        foreach (var observer in observers)
        {
            if (observer.GetType().GetProperty("IsStopped") == null || !(bool)observer.GetType().GetProperty("IsStopped").GetValue(observer, null))
                observer.OnNext(value);
        }
    }
}
